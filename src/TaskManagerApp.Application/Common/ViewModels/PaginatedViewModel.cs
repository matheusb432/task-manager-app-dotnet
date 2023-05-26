namespace TaskManagerApp.Application.Common.ViewModels
{
    public sealed class PaginatedViewModel
    {
        public long? Total { get; }

        public IEnumerable<object> Items { get; }

        public PaginatedViewModel(long? total, IEnumerable<object> items) =>
            (Total, Items) = (total, items);
    }
}
