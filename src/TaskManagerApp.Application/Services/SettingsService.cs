using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Application.Common.Interfaces;
using TaskManagerApp.Application.Common.ViewModels;
using TaskManagerApp.Application.Common.ViewModels.Validators;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Extensions;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Application.Services
{
    public interface ISettingsService
    {
        Task<OperationResult> UpdateMyProfile(int id, MyProfileViewModel vm);
    }

    public sealed class SettingsService : Service, ISettingsService
    {
        private readonly IUserRepository _userRepo;
        private readonly ICurrentUserProvider _currentUserProvider;

        public SettingsService(
            IMapper mapper,
            IUserRepository userRepo,
            ICurrentUserProvider currentUserProvider
        ) : base(mapper)
        {
            _userRepo = userRepo;
            _currentUserProvider = currentUserProvider;
        }

        public async Task<OperationResult> UpdateMyProfile(int id, MyProfileViewModel vm)
        {
            if (!_currentUserProvider.IsUserOrAdmin(id))
                return Error(
                    "You are not authorized to update this user's profile",
                    HttpStatusCode.Forbidden
                );

            if (!IsValid(new MyProfileViewModelValidator(), vm))
                return Error(HttpStatusCode.BadRequest);

            var entity = await _userRepo
                .Query()
                // TODO refactor with a `SelectQuery()` extension method
                .Select(
                    u =>
                        new User()
                        {
                            Id = u.Id,
                            UserName = u.UserName,
                            Name = u.Name
                        }
                )
                .RunFirstOrDefaultAsync(u => u.Id == id);

            if (entity == null)
                return Error(HttpStatusCode.NotFound);

            if (!string.IsNullOrEmpty(vm.Name))
                entity.Name = vm.Name;
            if (!string.IsNullOrEmpty(vm.UserName))
            {
                var isNewUserName = vm.UserName.ToLower() != entity.UserName.ToLower();
                if (isNewUserName && await _userRepo.UserNameExists(vm.UserName))
                {
                    return Error(
                        $"User name {entity.UserName} is already in use",
                        HttpStatusCode.Conflict
                    );
                }
                entity.UserName = vm.UserName;
            }

            await _userRepo.PatchPropsAsync(entity, x => x.UserName, x => x.Name);

            return Success();
        }
    }
}
