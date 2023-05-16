using AutoMapper;
using FluentValidation;
using System.Net;
using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services.Base
{
    public abstract class EntityService<T, TVM, TPostVM, TPutVM, TValidator, TRepository> : Service
        where T : Entity
        where TVM : class
        where TPostVM : class
        where TPutVM : class
        where TValidator : AbstractValidator<T>, new()
        where TRepository : IRepository<T>
    {
        protected readonly TRepository _repo;

        protected EntityService(IMapper mapper, TRepository repo) : base(mapper)
        {
            _repo = repo;
        }

        public virtual OperationResult Query() => Success(Mapper.ProjectTo<TVM>(_repo.Query()));

        public virtual async Task<OperationResult> Insert(TPostVM dto)
        {
            var entity = Mapper.Map<T>(dto);
            if (!EntityIsValid(new TValidator(), entity))
                return Error(HttpStatusCode.BadRequest);

            await _repo.InsertAsync(entity);
            return Success(entity.Id);
        }

        public virtual async Task<OperationResult> Update(int id, TPutVM dto)
        {
            var entity = Mapper.Map<T>(dto);

            if (!EntityIsValid(new TValidator(), entity))
                return Error(HttpStatusCode.BadRequest);

            entity.Id = id;

            if (!await _repo.ExistsAsync(entity.Id))
                return Error(HttpStatusCode.NotFound);

            await _repo.UpdateAsync(entity);
            return Success();
        }

        public virtual async Task<OperationResult> Delete(int id)
        {
            var entity = await _repo.GetByIdMinimalAsync(id);

            if (entity is null)
                return Error(HttpStatusCode.NotFound);

            await _repo.DeleteAsync(entity);
            return Success();
        }
    }
}
