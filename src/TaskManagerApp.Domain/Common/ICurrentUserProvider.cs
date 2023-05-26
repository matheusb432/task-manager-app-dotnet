namespace TaskManagerApp.Application.Common.Interfaces
{
    public interface ICurrentUserProvider
    {
        int UserId { get; }
        bool IsAdmin { get; }
    }
}
