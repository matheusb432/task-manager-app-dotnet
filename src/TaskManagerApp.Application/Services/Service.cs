using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using System.Net;
using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.Extensions.ViewModels;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Services
{
    public abstract class Service
    {
        protected readonly IMapper Mapper;

        private ValidationResult? _validationResult;

        protected Service(IMapper mapper) => Mapper = mapper;

        protected OperationResult Error() => new(_validationResult);

        protected OperationResult Error(HttpStatusCode statusCode) => new(_validationResult, statusCode);

        protected static OperationResult Error(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            var failures = new List<ValidationFailure> { new ValidationFailure(string.Empty, errorMessage) };

            return new(new ValidationResult(failures), statusCode);
        }

        protected static OperationResult Success(object? obj = null, HttpStatusCode code = HttpStatusCode.OK) => new(obj, code);

        protected static OperationResult Success(long id, HttpStatusCode code = HttpStatusCode.Created) => new(new PostReturnViewModel(id), code);

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