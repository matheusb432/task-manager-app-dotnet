﻿namespace TaskManagerApp.Application.ViewModels.Timesheet
{
    public class TimesheetNotePutViewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int TimesheetId { get; set; }
    }
}