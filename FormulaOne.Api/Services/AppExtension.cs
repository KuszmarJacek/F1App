using Serilog;

namespace FormulaOne.Api.Services
{
    public static class AppExtension
    {
        public static void SerilogConfiguration(this IHostBuilder host)
        {
            host.UseSerilog((context, config) =>
            {
                // Read from appsettings.json
                config.ReadFrom.Configuration(context.Configuration);
            });
        }
    }
}
