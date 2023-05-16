namespace TaskManagerApp.Application.Dtos.Profile
{
    public sealed class ProfileDto
    {
        public ProfileDto()
        {
            ProfilePresetTaskItems = new();
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public short? TimeTarget { get; set; }
        public short? TasksTarget { get; set; }
        public short Priority { get; set; }
        public int UserId { get; set; }
        public int ProfileTypeId { get; set; }
        public ProfileTypeDto? ProfileType { get; set; }
        public List<ProfilePresetTaskItemDto> ProfilePresetTaskItems { get; set; }
    }
}
