using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.Application.Common.ViewModels;
using TaskManagerApp.Application.Services;

namespace TaskManagerApp.API.Controllers
{
    public sealed class SettingsController : Controller
    {
        private readonly ISettingsService _service;

        public SettingsController(ISettingsService service) => _service = service;

        [HttpPatch("me/{id}")]
        public async Task<ActionResult> UpdateMyProfile(int id, MyProfileViewModel vm)
        {
            return CustomResponse(await _service.UpdateMyProfile(id, vm));
        }
    }
}
