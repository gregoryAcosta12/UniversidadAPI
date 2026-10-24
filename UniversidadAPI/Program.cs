using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UniversidadAPI.Business.Services;
using UniversidadAPI.DataAccess.Dbcontext;
using UniversidadAPI.DataAccess.Repositories;
using UniversidadAPI.Infraestructura.Middleware;
using UniversidadAPI.Infraestructura.Configuracion;

// IMPORTANTE: Agrega esta referencia a tu capa de presentación
using UniversidadAPI.Presentation.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Especifica los ensamblados donde buscar controladores
builder.Services.AddControllers()
    .AddApplicationPart(typeof(AuthController).Assembly) // Registra los controladores de la capa Presentation
    .AddControllersAsServices(); // Opcional: registra los controladores como servicios

// ========== OBTENER CONFIGURACIONES ==========
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
var corsSettings = builder.Configuration.GetSection("Cors").Get<CorsSettings>();

// ========== REGISTRAR CONFIGURACIONES ==========
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<CorsSettings>(builder.Configuration.GetSection("Cors"));

// ========== CONFIGURACIÓN DE BD ==========
builder.Services.AddDbContext<UniversidadDbContext>(
    options =>
        options.UseMySql(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(8, 0, 36))
        )
);

// ========== CONFIGURACIÓN DE AUTENTICACIÓN JWT ==========
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Key)),
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    });

// ========== CONFIGURACIÓN DE CORS ==========
builder.Services.AddCors(options =>
{
    options.AddPolicy("MiPoliticaCors", policy =>
    {
        policy.WithOrigins(corsSettings.AllowedOrigins)
              .WithMethods(corsSettings.AllowedMethods)
              .WithHeaders(corsSettings.AllowedHeaders)
              .AllowCredentials();
    });
});

// ========== REGISTRAR REPOSITORIOS Y SERVICIOS ==========
builder.Services.AddScoped<IFacultadRepository, FacultadRepository>();
builder.Services.AddScoped<IFacultadService, FacultadService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ICarreraRepository, CarreraRepository>();
builder.Services.AddScoped<ICarreraService, CarreraService>();
builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IMateriaRepository, MateriaRepository>();
builder.Services.AddScoped<IMateriaService, MateriaService>();
builder.Services.AddScoped<IProfesorRepository, ProfesorRepository>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();
builder.Services.AddScoped<IPeriodoAcademicoRepository, PeriodoAcademicoRepository>();
builder.Services.AddScoped<IPeriodoAcademicoService, PeriodoAcademicoService>();
builder.Services.AddScoped<IInscripcionRepository, InscripcionRepository>();
builder.Services.AddScoped<IInscripcionService, InscripcionService>();
builder.Services.AddScoped<ICalificacionRepository, CalificacionRepository>();
builder.Services.AddScoped<ICalificacionService, CalificacionService>();

// ========== REGISTRAR SERVICIO DE AUTENTICACIÓN ==========
builder.Services.AddScoped<IAuthService, AuthService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "UniversidadAPI",
        Version = "v1",
        Description = "API para la gestión universitaria"
    });

    // Configurar autenticación JWT para Swagger
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ========== MIDDLEWARES (ORDEN IMPORTANTE) ==========
app.UseCors("MiPoliticaCors");      // 1. CORS usando la política
app.UseAuthentication();            // 2. Autenticación (¿quién eres?)
app.UseAuthorization();             // 3. Autorización (¿qué puedes hacer?)
app.UseJwtAuthentication();         // 4. Tu middleware JWT personalizado

app.MapControllers();

app.Run();