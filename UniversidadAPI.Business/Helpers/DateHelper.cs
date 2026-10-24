namespace UniversidadAPI.Business.Helpers;

public static class DateHelper
{
    public static string FormatearFechaParaFrontend(DateTime? fecha)
    {
        if (fecha == null)
            return string.Empty;

        return fecha.Value.ToString("dd/MM/yyyy");
    }

    public static string FormatearFechaISO(DateTime? fecha)
    {
        if (fecha == null)
            return string.Empty;

        return fecha.Value.ToString("yyyy-MM-dd");
    }

    public static string FormatearFechaCompleta(DateTime? fecha)
    {
        if (fecha == null)
            return string.Empty;

        return fecha.Value.ToString("dd/MM/yyyy HH:mm:ss");
    }
}