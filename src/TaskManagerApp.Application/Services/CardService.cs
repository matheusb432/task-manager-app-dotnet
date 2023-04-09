using System.Net;
using AutoMapper;
using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.ViewModels.Card;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    public sealed class CardService : Service, ICardService
    {
        private readonly ICardRepository _repo;

        public CardService(ICardRepository repo, IMapper mapper) : base(mapper)
        {
            _repo = repo;
        }

        public OperationResult Query() => Success(Mapper.ProjectTo<CardViewModel>(_repo.Query()));

        public async Task<OperationResult> Insert(CardPostViewModel viewModel)
        {
            var entity = Mapper.Map<Card>(viewModel);
            if (!EntityIsValid(new CardValidator(), entity))
                return Error();

            await _repo.InsertAsync(entity);
            return Success(entity.Id);
        }

        public async Task<OperationResult> Update(int id, CardPutViewModel viewModel)
        {
            var entity = Mapper.Map<Card>(viewModel);

            if (!EntityIsValid(new CardValidator(), entity))
                return Error(HttpStatusCode.BadRequest);

            entity.Id = id;

            var entityFromDb = await _repo.GetByIdAsNoTrackingAsync(entity.Id);

            if (entityFromDb is null)
                return Error(HttpStatusCode.NotFound);

            await _repo.UpdateAsync(entity);
            return Success();
        }

        public async Task<OperationResult> Delete(int id)
        {
            var entity = await _repo.GetByIdAsNoTrackingAsync(id);

            if (entity is null)
                return Error(HttpStatusCode.NotFound);

            await _repo.DeleteAsync(entity);
            return Success();
        }
    }
}
