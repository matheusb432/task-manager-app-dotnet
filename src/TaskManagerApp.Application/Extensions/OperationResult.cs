using FluentValidation.Results;
using System.Net;

namespace TaskManagerApp.Application.Extensions
{
    public sealed class OperationResult
    {
        public object? Content { get; private set; }
        public ValidationResult? Result { get; private set; }
        public bool IsValid => Result?.IsValid ?? false;
        public HttpStatusCode StatusCode { get; private set; }

        public OperationResult(ValidationResult? result, HttpStatusCode statusCode)
        {
            Result = result;
            StatusCode = statusCode;
        }

        public OperationResult(ValidationResult? result) => Result = result;

        public OperationResult(object? content, HttpStatusCode statusCode)
        {
            Result = new ValidationResult();
            Content = content;
            StatusCode = statusCode;
        }
    }
}