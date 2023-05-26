namespace TaskManagerApp.Application.Common.Dtos.Profile
{
    public sealed class ProfilePresetTaskItemPutDto
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int PresetTaskItemId { get; set; }
    }
}
