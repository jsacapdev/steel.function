using Microsoft.ApplicationInsights;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ConfigFunctionApi.Startup))]

namespace ConfigFunctionApi
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<TelemetryClient>();
        }
    }
}
