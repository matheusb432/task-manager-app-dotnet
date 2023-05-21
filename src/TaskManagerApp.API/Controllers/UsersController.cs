using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.API.Configurations;
using TaskManagerApp.Application.Dtos.User;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Utils;
using TaskManagerApp.Application.ViewModels;

namespace TaskManagerApp.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public sealed class UsersController : Controller
    {
        private readonly IUserService _service;

        public UsersController(IUserService service) => _service = service;

        [HttpGet("odata")]
        [ODataQuery]
        public ActionResult<IQueryable<UserDto>> Query() => CustomResponse(_service.Query());

        [HttpPost]
        public async Task<ActionResult<PostReturnViewModel>> Post(UserPostDto viewModel) =>
            CustomResponse(await _service.Insert(viewModel));

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UserPutDto viewModel) =>
            CustomResponse(await _service.Update(id, viewModel));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) => CustomResponse(await _service.Delete(id));
    }
}
