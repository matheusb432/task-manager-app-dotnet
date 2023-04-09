using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp.Domain.Models
{
    public class TaskItem : Entity
    {
		public TaskItem()
		{
			TaskItemNotes = new();
			GoalTaskItems = new();
		}

		public string Title { get; set; }
		public short Hours { get; set; }
		public int TimesheetId { get; set; }
		public Timesheet? Timesheet { get; set; }
		public List<TaskItemNote> TaskItemNotes { get; set; }
		public List<GoalTaskItem> GoalTaskItems { get; set; }
	}
}
