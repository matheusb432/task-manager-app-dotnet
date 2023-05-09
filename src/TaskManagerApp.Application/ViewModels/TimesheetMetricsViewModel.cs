namespace TaskManagerApp.Application.ViewModels
{
    public class TimesheetMetricsViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalTasks { get; set; }
        public double WorkedHours { get; set; }
        public double AverageRating { get; set; }
    }
}