namespace TaskManagerApp.Application.Extensions.ViewModels
{
    public sealed class ErrorViewModel
    {
        public ErrorViewModel(List<string> errors) => Errors = errors;

        public ErrorViewModel() => Errors = new List<string> { "Something went wrong!" };

        public List<string> Errors { get; set; }
    }
}