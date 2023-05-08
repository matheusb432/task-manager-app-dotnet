using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.API.Configurations;
using TaskManagerApp.Application.Dtos.Profile;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Utils;
using TaskManagerApp.Application.ViewModels;

namespace TaskManagerApp.API.Controllers
{
    public sealed class ProfilesController : Controller
    {
        private readonly IProfileService _service;

        public ProfilesController(IProfileService service)
            => _service = service;

        [HttpGet("odata")]
        [ODataQuery]
        public ActionResult<IQueryable<ProfileDto>> Query() => CustomResponse(_service.Query());

        [HttpGet("types/odata")]
        [ResponseCache(Duration = 86400)]
        [ODataQuery]
        [AllowAnonymous]
        public ActionResult<List<ProfileTypeDto>> TypesQuery()
            => CustomResponse(_service.TypesQuery());

        [HttpPost]
        public async Task<ActionResult<PostReturnViewModel>> Post(ProfilePostDto viewModel)
            => CustomResponse(await _service.Insert(viewModel));

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ProfilePutDto viewModel)
            => CustomResponse(await _service.Update(id, viewModel));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
            => CustomResponse(await _service.Delete(id));
    }
}