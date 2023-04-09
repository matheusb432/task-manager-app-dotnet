using TaskManagerApp.Application.ViewModels.Profile;
using TaskManagerApp.Application.ViewModels.TaskItem;

namespace TaskManagerApp.Application.ViewModels.User
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Profiles = new();
            PresetTaskItems = new();
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<ProfileViewModel> Profiles { get; set; }
        public List<PresetTaskItemViewModel> PresetTaskItems { get; set; }
    }
}