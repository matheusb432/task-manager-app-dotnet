using System.Net;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.Extensions.ViewModels;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Services
{
    /// <summary>
    /// Serviço abstrato que permite o tratamento operações de resposta, erro e validação de endpoints da API
    /// </summary>
    public abstract class Service
    {
        protected readonly IMapper Mapper;

        private ValidationResult? _validationResult;

        protected Service(IMapper mapper) => Mapper = mapper;

        protected OperationResult Error() => new(_validationResult);

        protected OperationResult Error(HttpStatusCode statusCode) => new(_validationResult, statusCode);

        protected OperationResult Error(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            var failures = new List<ValidationFailure> { new ValidationFailure(string.Empty, errorMessage) };

            return new(new ValidationResult(failures), statusCode);
        }

        protected OperationResult Success(object? obj = null) => new(obj);

        protected OperationResult Success(long id) => new(new PostReturnViewModel(id));

        protected void NotifyError(string errorMessage)
        {
            var failures = new List<ValidationFailure> { new ValidationFailure(string.Empty, errorMessage) };
            _validationResult = new ValidationResult(failures);
        }

        protected bool EntityIsValid<TV, TE>(TV validator, TE entity)
            where TV : AbstractValidator<TE>
            where TE : Entity
        {
            var result = validator.Validate(entity);
            if (result.IsValid) return true;

            _validationResult = result;

            return false;
        }

        protected bool EntityIsValid<TV, TE>(TV validator, IEnumerable<TE> entities)
            where TV : AbstractValidator<TE>
            where TE : Entity
        {
            foreach (var entity in entities)
            {
                var result = validator.Validate(entity);
                if (result.IsValid) continue;

                _validationResult = result;
                return false;
            }

            return true;
        }
    }
}
