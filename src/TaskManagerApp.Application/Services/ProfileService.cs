using AutoMapper;
using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.ViewModels.Profile;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;
using Profile = TaskManagerApp.Domain.Models.Profile;

namespace TaskManagerApp.Application.Services
{
    public sealed class ProfileService : EntityService<
        Profile,
        ProfileViewModel,
        ProfilePostViewModel,
        ProfilePutViewModel,
        ProfileValidator>, IProfileService
    {
        private readonly IProfileTypeRepository _profileTypeRepo;

        public ProfileService(IProfileRepository repo, IMapper mapper, IProfileTypeRepository profileTypeRepo)
            : base(mapper, repo)
        {
            _profileTypeRepo = profileTypeRepo;
        }

        public async Task<OperationResult> FindTypes()
            => Success(Mapper.Map<List<ProfileTypeViewModel>>(await _profileTypeRepo.GetAllAsync()));
    }
}