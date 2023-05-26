namespace TaskManagerApp.Application.Common.ViewModels
{
    public sealed class HealthCheckResponse
    {
        public HealthCheckResponse()
        {
            HealthChecks = new List<IndividualHealthCheckResponse>();
        }

        public string Status { get; set; } = string.Empty;
        public IEnumerable<IndividualHealthCheckResponse> HealthChecks { get; set; }
        public TimeSpan HealthCheckDuration { get; set; }
    }

    public sealed class IndividualHealthCheckResponse
    {
        public string Status { get; set; } = string.Empty;
        public string Component { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
