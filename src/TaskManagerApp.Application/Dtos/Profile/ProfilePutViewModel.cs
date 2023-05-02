namespace TaskManagerApp.Application.Dtos.Profile
{
    public sealed class ProfilePutDto
    {
        public ProfilePutDto()
        {
            ProfilePresetTaskItems = new();
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TimeTarget { get; set; } = string.Empty;
        public short? TasksTarget { get; set; }
        public short Priority { get; set; }
        public int UserId { get; set; }
        public int ProfileTypeId { get; set; }
        public ProfileTypePutDto? ProfileType { get; set; }
        public List<ProfilePresetTaskItemPutDto> ProfilePresetTaskItems { get; set; }
    }
}