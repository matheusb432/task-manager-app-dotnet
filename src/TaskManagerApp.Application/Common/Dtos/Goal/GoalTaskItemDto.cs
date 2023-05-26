﻿using TaskManagerApp.Application.Common.Dtos.TaskItem;

namespace TaskManagerApp.Application.Common.Dtos.Goal
{
    public sealed class GoalTaskItemDto
    {
        public int Id { get; set; }
        public int GoalId { get; set; }
        public int TaskItemId { get; set; }
        public TaskItemDto? TaskItem { get; set; }
    }
}