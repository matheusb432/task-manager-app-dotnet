using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.API.Configurations;
using TaskManagerApp.Application.Extensions.ViewModels;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.ViewModels.User;

namespace TaskManagerApp.API.Controllers
{
    // TODO add admin role auth
    [Authorize]
    public sealed class UsersController : Controller
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
            => _service = service;

        [HttpGet("odata")]
        [ODataQuery]
        public ActionResult<IQueryable<UserViewModel>> Query() => CustomResponse(_service.Query());

        [HttpPost]
        public async Task<ActionResult<PostReturnViewModel>> Post(UserPostViewModel viewModel)
            => CustomResponse(await _service.Insert(viewModel));

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UserPutViewModel viewModel)
            => CustomResponse(await _service.Update(id, viewModel));

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
            => CustomResponse(await _service.Delete(id));
    }
}