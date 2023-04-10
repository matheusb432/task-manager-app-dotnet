using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.API.Configurations;
using TaskManagerApp.Application.Extensions.ViewModels;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.ViewModels.Profile;

namespace TaskManagerApp.API.Controllers
{
    [ApiController]
    public sealed class ProfilesController : Controller
    {
        private readonly IProfileService _service;

        public ProfilesController(IProfileService service)
            => _service = service;

        [HttpGet("odata")]
        [ODataQuery]
        public ActionResult<IQueryable<ProfileViewModel>> Query() => CustomResponse(_service.Query());

        [HttpGet("types")]
        public async Task<ActionResult<List<ProfileTypeViewModel>>> GetTypes() 
            => CustomResponse(await _service.FindTypes());

        [HttpPost]
        public async Task<ActionResult<PostReturnViewModel>> Post(ProfilePostViewModel viewModel)
            => CustomResponse(await _service.Insert(viewModel));

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ProfilePutViewModel viewModel)
            => CustomResponse(await _service.Update(id, viewModel));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
            => CustomResponse(await _service.Delete(id));
    }
}