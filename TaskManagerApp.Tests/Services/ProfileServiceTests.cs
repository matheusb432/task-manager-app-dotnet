using AutoMapper;
using Moq;
using TaskManagerApp.Application.Extensions.ViewModels;
using TaskManagerApp.Application.Profiles;
using TaskManagerApp.Application.Services;
using TaskManagerApp.Application.ViewModels.Profile;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Utils;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Tests.Services
{
    public class ProfileServiceTests
    {
        private readonly ProfileService _service;

        private readonly IMapper _mapper;

        private readonly Mock<IProfileRepository> _repo;
        private readonly Mock<IProfileTypeRepository> _profileTypeRepo;

        private readonly List<ProfileType> _profileTypes;
        private readonly List<Domain.Models.Profile> _profiles;

        public ProfileServiceTests()
        {
            _repo = new();
            _profileTypeRepo = new();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProfileProfiles());
            });

            _mapper = mappingConfig.CreateMapper();

            _profileTypes = GetProfileTypes();
            _profiles = GetProfiles();

            SetupMocks();

            _service = new ProfileService(
                _repo.Object,
                _mapper,
                _profileTypeRepo.Object
            );
        }

        [Fact]
        public async Task FindTypes_ShouldReturnSuccess()
        {
            var result = await _service.FindTypes();

            Assert.True(result.IsValid);
            Assert.IsType<List<ProfileTypeViewModel>>(result.Content);
            Assert.Equal(_profileTypes.Count, ((List<ProfileTypeViewModel>)result.Content).Count);
        }

        [Fact]
        public async Task Insert_WithValidProfile_ShouldReturnSuccess()
        {
            var profile = new ProfilePostViewModel
            {
                Name = "Personal Weekdays Profile",
                HoursTarget = 10,
                TasksTarget = 4,
                UserId = 123,
                ProfileTypeId = 1
            };

            var result = await _service.Insert(profile);

            Assert.NotNull(result.Content);

            var created = _profiles.FirstOrDefault(p => p.Id == ((PostReturnViewModel)result.Content).Id);

            Assert.True(result.IsValid);
            Assert.NotNull(created);
            Assert.Equal(profile.Name, created.Name);
            Assert.Equal(profile.HoursTarget, created.HoursTarget);
            Assert.Equal(profile.TasksTarget, created.TasksTarget);
            Assert.Equal(profile.UserId, created.UserId);
            Assert.Equal(profile.ProfileTypeId, created.ProfileTypeId);
        }

        private void SetupMocks()
        {
            _repo
                .Setup(x => x.InsertAsync(It.IsAny<Domain.Models.Profile>(), true))
                .Callback((Domain.Models.Profile p, bool save) => {
                    p.Id = _profiles.Max(x => x.Id) + 1;
                    _profiles.Add(p);
                });

            _profileTypeRepo
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(_profileTypes);
        }

        public static List<ProfileType> GetProfileTypes()
            => new() {
                  new ProfileType { Id = 1, Name = "Weekdays", Type = ProfileTypes.Weekday },
                  new ProfileType { Id = 2, Name = "Weekends", Type = ProfileTypes.Weekend },
                  new ProfileType { Id = 3, Name = "Holidays", Type = ProfileTypes.Holiday },
                  new ProfileType
                  {
                      Id = 4,
                      Name = "January 2023",
                      Type = ProfileTypes.Custom,
                      DateRangeStart = new DateTime(2023, 1, 1),
                      DateRangeEnd = new DateTime(2023, 2, 1)
                  },
                  new ProfileType
                  {
                      Id = 5,
                      Name = "2022",
                      Type = ProfileTypes.Custom,
                      DateRangeStart = new DateTime(2022, 1, 1),
                      DateRangeEnd = new DateTime(2022, 12, 31)
                  }
            };

        public static List<Domain.Models.Profile> GetProfiles()
            => new()
            {
                new Domain.Models.Profile
                {
                        Id= 1,
                        Name= "Personal Weekdays Profile",
                        HoursTarget= 10,
                        TasksTarget= 4,
                        UserId= 123,
                        ProfileTypeId= 1,
                },
                new Domain.Models.Profile
                {
                        Id= 2,
                        Name= "Personal Weekends Profile",
                        HoursTarget= 4,
                        TasksTarget= 3,
                        UserId= 123,
                        ProfileTypeId= 2,
                },
                new Domain.Models.Profile
                {
                        Id= 3,
                        Name= "Personal Holidays Profile",
                        HoursTarget= 3,
                        UserId= 323,
                        ProfileTypeId= 3,
                },
                new Domain.Models.Profile
                {
                        Id= 4,
                        Name= "Personal Custom Profile",
                        HoursTarget= 4,
                        UserId= 423,
                        ProfileTypeId= 4,
                },
                new Domain.Models.Profile
                {
                        Id= 5,
                        Name= "Personal Custom Profile",
                        HoursTarget= 5,
                        UserId= 523,
                        ProfileTypeId= 5,
                },
            };
    }
}