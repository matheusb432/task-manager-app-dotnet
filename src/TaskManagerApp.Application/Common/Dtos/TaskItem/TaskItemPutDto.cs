﻿namespace TaskManagerApp.Application.Common.Dtos.TaskItem
{
    public sealed class TaskItemPutDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Time { get; set; }
        public short? Rating { get; set; }
        public string? Comment { get; set; }
        public int TimesheetId { get; set; }
        public int? PresetTaskItemId { get; set; }
    }
}
