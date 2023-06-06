using AutoMapper;
using System.Net;
using TaskManagerApp.Application.Common.Dtos.Profile;
using TaskManagerApp.Application.Common.Dtos.Timesheet;
using TaskManagerApp.Application.Common.Interfaces;
using TaskManagerApp.Application.Common.ViewModels;
using TaskManagerApp.Application.Services.Base;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;
using Profile = TaskManagerApp.Domain.Models.Profile;

namespace TaskManagerApp.Application.Services
{
    public sealed class ProfileService
        : EntityService<
            Profile,
            ProfileDto,
            ProfilePostDto,
            ProfilePutDto,
            ProfileValidator,
            IProfileRepository
        >,
            IProfileService
    {
        private readonly IProfileTypeRepository _profileTypeRepo;

        public ProfileService(
            IProfileRepository repo,
            IMapper mapper,
            IProfileTypeRepository profileTypeRepo
        ) : base(mapper, repo)
        {
            _profileTypeRepo = profileTypeRepo;
        }

        public OperationResult TypesQuery() =>
            Success(Mapper.ProjectTo<ProfileTypeDto>(_profileTypeRepo.Query()));

        public override async Task<OperationResult> Update(int id, ProfilePutDto dto)
        {
            var entity = Mapper.Map<Profile>(dto);

            if (!EntityIsValid(new ProfileValidator(), entity))
                return Error(HttpStatusCode.BadRequest);

            entity.Id = id;

            if (!await _repo.ExistsAsync(id))
                return Error(HttpStatusCode.NotFound);

            await _repo.DeleteMissingRelationsFromRequestAsync(entity, false);
            await _repo.UpdateAsync(entity);

            return Success();
        }
    }
}
