using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerApp.Domain.Models
{
    public class Profile : Entity
    {
        public Profile()
        {
            PresetTaskItems = new();
        }
        public string Name { get; set; } = string.Empty;
        public short? HoursTarget { get; set; }
        public short? TasksTarget { get; set; }
        public int UserId { get; set; }
        public int ProfileTypeId { get; set; }
        public User? User { get; set; }
        public ProfileType? ProfileType { get; set; }
        public List<PresetTaskItem> PresetTaskItems { get; set; }

    }
}
