using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.ViewModels.Card;

namespace TaskManagerApp.Application.Interfaces
{
    public interface ICardService
    {
        OperationResult Query();

        Task<OperationResult> Insert(CardPostViewModel viewModel);

        Task<OperationResult> Update(int id, CardPutViewModel viewModel);

        Task<OperationResult> Delete(int id);
    }
}