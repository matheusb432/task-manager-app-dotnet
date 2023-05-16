namespace TaskManagerApp.Tests.E2E.Utils
{
    public static class PageUrls
    {
        public static readonly string BaseUrl = "http://localhost:4200";
        public static readonly string HomeUrl = $"{BaseUrl}/home";
        public static readonly string LoginUrl = $"{BaseUrl}/auth/login";
        public static readonly string SignupUrl = $"{BaseUrl}/auth/signup";
        public static readonly string ProfilesUrl = $"{BaseUrl}/profiles";
        public static readonly string TimesheetsUrl = $"{BaseUrl}/timesheets";
        public static readonly string TimesheetsCreateUrl = $"{BaseUrl}/timesheets/create";
        public static readonly string TimesheetDetailsUrl = $"{BaseUrl}/timesheets/details";
        public static readonly string MetricsUrl = $"{BaseUrl}/metrics";
    }
}
