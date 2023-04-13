using AutoMapper;
using FluentValidation;
using System.Net;
using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    public abstract class EntityService<T, TVM, TPostVM, TPutVM, TV> : Service
        where T : Entity
        where TVM : class
        where TPostVM : class
        where TPutVM : class
        where TV : AbstractValidator<T>, new()
    {
        protected readonly IRepository<T> _repo;

        public EntityService(IMapper mapper, IRepository<T> repo) 
            : base(mapper)
        {
            _repo = repo;
        }

        public virtual OperationResult Query() => Success(Mapper.ProjectTo<TVM>(_repo.Query()));

        public virtual async Task<OperationResult> Insert(TPostVM viewModel)
        {
            var entity = Mapper.Map<T>(viewModel);
            if (!EntityIsValid(new TV(), entity))
                return Error(HttpStatusCode.BadRequest);

            await _repo.InsertAsync(entity);
            return Success(entity.Id);
        }

        public virtual async Task<OperationResult> Update(int id, TPutVM viewModel)
        {
            var entity = Mapper.Map<T>(viewModel);

            if (!EntityIsValid(new TV(), entity))
                return Error(HttpStatusCode.BadRequest);

            entity.Id = id;

            var entityFromDb = await _repo.GetByIdAsNoTrackingAsync(entity.Id);

            if (entityFromDb is null)
                return Error(HttpStatusCode.NotFound);

            await _repo.UpdateAsync(entity);
            return Success();
        }

        public virtual async Task<OperationResult> Delete(int id)
        {
            var entity = await _repo.GetByIdAsNoTrackingAsync(id);

            if (entity is null)
                return Error(HttpStatusCode.NotFound);

            await _repo.DeleteAsync(entity);
            return Success();
        }
    }
}