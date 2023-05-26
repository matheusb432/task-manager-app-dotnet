using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TaskManagerApp.Application.Common.ViewModels;

namespace TaskManagerApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public abstract class Controller : ControllerBase
    {
        protected ActionResult CustomResponse(OperationResult result)
        {
            if (!result.IsValid)
                return ErrorResponse(result);

            return Ok(result.Content ?? string.Empty);
        }

        private ActionResult ErrorResponse(OperationResult result)
        {
            if ((int)result.StatusCode < 400)
                return StatusCode(500, result.Result);

            return result.StatusCode switch
            {
                HttpStatusCode.NotFound => NotFound(MapErrorsToResponse(result.Result)),
                HttpStatusCode.Conflict => Conflict(MapErrorsToResponse(result.Result)),
                _ => StatusCode((int)result.StatusCode, MapErrorsToResponse(result.Result))
            };
        }

        private static ErrorViewModel MapErrorsToResponse(ValidationResult? validationResult) =>
            validationResult is not null
                ? new ErrorViewModel(validationResult.Errors.ConvertAll(e => e.ErrorMessage))
                : new ErrorViewModel();
    }
}
