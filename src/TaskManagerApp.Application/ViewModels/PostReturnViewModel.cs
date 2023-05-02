namespace TaskManagerApp.Application.ViewModels
{
    public sealed class PostReturnViewModel
    {
        public long Id { get; set; }

        public PostReturnViewModel(long id) => Id = id;
    }
}