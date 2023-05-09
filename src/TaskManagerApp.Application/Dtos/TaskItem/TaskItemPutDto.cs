﻿namespace TaskManagerApp.Application.Dtos.TaskItem
{
    public sealed class TaskItemPutDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Time { get; set; }
        public short? Rating { get; set; }
        public short Importance { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int TimesheetId { get; set; }
    }
}