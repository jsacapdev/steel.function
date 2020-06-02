using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;

namespace ConfigFunctionApi
{
    public static class LoggerExtensions
    {
        public static void LogEvent(this TelemetryClient client, string message)
        {
            var customDimensions = new Dictionary<string, string>
            {
                { "ConfigFunctionApi ", "e928180b-8ac3-4ecf-8212-a2c8b624893a" },
                { "Message ", message }
            };

            client.TrackEvent(message, customDimensions);
        }

        public static void LogException(this TelemetryClient client, Exception ex)
        {
            var customDimensions = new Dictionary<string, string>
            {
                { "ConfigFunctionApi ", "e928180b-8ac3-4ecf-8212-a2c8b624893a" }
            };

            client.TrackException(ex, customDimensions);
        }
    }
}