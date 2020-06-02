using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.ApplicationInsights;

namespace ConfigFunctionApi
{
    public class SimpleSampleHttpTrigger
    {
        private readonly TelemetryClient _telemetry;

        public SimpleSampleHttpTrigger(TelemetryClient telemetryClient)
        {
            _telemetry = telemetryClient;
        }

        [FunctionName(Constants.SimpleSampleHttpTrigger)]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            await Task.Run(() => { });

            _telemetry.LogEvent("some event");

            return new OkObjectResult(DateTime.UtcNow.ToString());
        }
    }
}
