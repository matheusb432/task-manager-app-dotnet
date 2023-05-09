using AutoMapper;
using TaskManagerApp.Application.Dtos.Profile;
using TaskManagerApp.Application.Extensions;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;
using Profile = TaskManagerApp.Domain.Models.Profile;

namespace TaskManagerApp.Application.Services
{
    public sealed class ProfileService : EntityService<
        Profile,
        ProfileDto,
        ProfilePostDto,
        ProfilePutDto,
        ProfileValidator,
        IProfileRepository>, IProfileService
    {
        private readonly IProfileTypeRepository _profileTypeRepo;

        public ProfileService(IProfileRepository repo, IMapper mapper, IProfileTypeRepository profileTypeRepo)
            : base(mapper, repo)
        {
            _profileTypeRepo = profileTypeRepo;
        }

        public OperationResult TypesQuery() => Success(Mapper.ProjectTo<ProfileTypeDto>(_profileTypeRepo.Query()));
    }
}