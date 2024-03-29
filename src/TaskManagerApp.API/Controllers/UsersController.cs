﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagerApp.API.Configurations;
using TaskManagerApp.Application.Common.Dtos.User;
using TaskManagerApp.Application.Common.Interfaces;
using TaskManagerApp.Application.Common.ViewModels;
using TaskManagerApp.Application.Utils;

namespace TaskManagerApp.API.Controllers
{
    public sealed class UsersController : Controller
    {
        private readonly IUserService _service;

        public UsersController(IUserService service) => _service = service;

        [HttpGet("odata")]
        [ODataQuery]
        public ActionResult<IQueryable<UserDto>> Query() => CustomResponse(_service.Query());

        [HttpGet("roles/odata")]
        [ODataQuery]
        public ActionResult<IQueryable<RoleDto>> QueryRoles() =>
            CustomResponse(_service.RolesQuery());

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult<PostReturnViewModel>> Post(UserPostDto viewModel) =>
            CustomResponse(await _service.Insert(viewModel));

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> Put(int id, UserPutDto viewModel) =>
            CustomResponse(await _service.Update(id, viewModel));

        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<ActionResult> Delete(int id) => CustomResponse(await _service.Delete(id));
    }
}
