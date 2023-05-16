using AutoMapper;
using Moq;
using TaskManagerApp.Application.Dtos.Profile;
using TaskManagerApp.Application.Profiles;
using TaskManagerApp.Application.Services;
using TaskManagerApp.Application.ViewModels;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Domain.Utils;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Tests.Unit.Services
{
    public sealed class ProfileServiceTests
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

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new ProfileProfiles()));

            _mapper = mappingConfig.CreateMapper();

            _profileTypes = GetProfileTypes();
            _profiles = GetProfiles();

            SetupMocks();

            _service = new ProfileService(_repo.Object, _mapper, _profileTypeRepo.Object);
        }

        [Fact]
        public void TypesQuery_ShouldReturnSuccess()
        {
            var result = _service.TypesQuery();

            Assert.True(result.IsValid);
            Assert.IsAssignableFrom<IQueryable<ProfileTypeDto>>(result.Content);
            Assert.Equal(
                _profileTypes.Count,
                (result.Content as IQueryable<ProfileTypeDto>)?.Count()
            );
        }

        [Fact]
        public async Task Insert_WithValidProfile_ShouldReturnSuccess()
        {
            var profile = new ProfilePostDto
            {
                Name = "Personal Weekdays Profile",
                TimeTarget = "10:00",
                TasksTarget = 4,
                Priority = 0,
                ProfileTypeId = 1
            };

            var result = await _service.Insert(profile);

            Assert.NotNull(result.Content);

            var created = _profiles.Find(p => p.Id == ((PostReturnViewModel)result.Content).Id);

            Assert.True(result.IsValid);
            Assert.NotNull(created);
        }

        [Fact]
        public async Task Insert_WithInvalidProfile_ShouldReturnBadRequest()
        {
            var profile = new ProfilePostDto
            {
                TimeTarget = "10:00",
                TasksTarget = 4,
                ProfileTypeId = 1
            };

            var result = await _service.Insert(profile);

            Assert.False(result.IsValid);
            Assert.Equal(400, (int)result.StatusCode);
        }

        [Fact]
        public async Task Update_WithValidProfile_ShouldReturnSuccess()
        {
            const int id = 1;
            var profile = new ProfilePutDto
            {
                Id = id,
                Name = "Personal Weekdays Profile -- edit",
                TimeTarget = "07:00",
                TasksTarget = 4,
                Priority = 0,
                ProfileTypeId = 1
            };

            var result = await _service.Update(profile.Id, profile);
            var updated = _profiles.Find(p => p.Id == id);

            Assert.True(result.IsValid);
            Assert.NotNull(updated);
        }

        [Fact]
        public async Task Update_WithInvalidProfile_ShouldReturnBadRequest()
        {
            const int id = 1;
            var profile = new ProfilePutDto
            {
                Id = id,
                TimeTarget = "10:00",
                TasksTarget = 4,
                ProfileTypeId = 1
            };

            var result = await _service.Update(profile.Id, profile);

            Assert.False(result.IsValid);
            Assert.Equal(400, (int)result.StatusCode);
        }

        [Fact]
        public async Task Delete_WithValidId_ShouldDeleteItem()
        {
            const int id = 1;

            var result = await _service.Delete(id);

            Assert.True(result.IsValid);
            Assert.Equal(200, (int)result.StatusCode);
        }

        [Fact]
        public async Task Delete_WithInvalidId_ShouldReturnNotFound()
        {
            const int id = 999;

            var result = await _service.Delete(id);

            Assert.False(result.IsValid);
            Assert.Equal(404, (int)result.StatusCode);
        }

        private void SetupMocks()
        {
            _repo
                .Setup(x => x.InsertAsync(It.IsAny<Domain.Models.Profile>(), true))
                .Callback(
                    (Domain.Models.Profile p, bool _) =>
                    {
                        p.Id = _profiles.Max(x => x.Id) + 1;
                        _profiles.Add(p);
                    }
                );
            _repo
                .Setup(x => x.UpdateAsync(It.IsAny<Domain.Models.Profile>(), true))
                .Callback(
                    (Domain.Models.Profile p, bool _) =>
                    {
                        var toUpdate = _profiles.Find(x => x.Id == p.Id);

                        if (toUpdate == null)
                            return;

                        _profiles.Remove(toUpdate);
                        _profiles.Add(p);
                    }
                );
            _repo
                .Setup(x => x.GetByIdMinimalAsync(It.IsAny<long>()))
                .ReturnsAsync((long id) => _profiles.Find((x) => x.Id == id));
            _repo
                .Setup(x => x.DeleteAsync(It.IsAny<Domain.Models.Profile>(), It.IsAny<bool>()))
                .Callback((Domain.Models.Profile p, bool _) => _profiles.Remove(p));

            _profileTypeRepo.Setup(x => x.Query()).Returns(_profileTypes.AsQueryable());
            _profileTypeRepo.Setup(x => x.GetAllAsync()).ReturnsAsync(_profileTypes);
        }

        public static List<ProfileType> GetProfileTypes() =>
            new()
            {
                new ProfileType
                {
                    Id = 1,
                    Name = "Weekdays",
                    Type = ProfileTypes.Weekday
                },
                new ProfileType
                {
                    Id = 2,
                    Name = "Weekends",
                    Type = ProfileTypes.Weekend
                },
                new ProfileType
                {
                    Id = 3,
                    Name = "Holidays",
                    Type = ProfileTypes.Holiday
                },
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

        public static List<Domain.Models.Profile> GetProfiles() =>
            new()
            {
                new Domain.Models.Profile
                {
                    Id = 1,
                    Name = "Personal Weekdays Profile",
                    TimeTarget = 1030,
                    TasksTarget = 4,
                    Priority = 0,
                    UserCreatedId = 123,
                    ProfileTypeId = 1,
                },
                new Domain.Models.Profile
                {
                    Id = 2,
                    Name = "Personal Weekends Profile",
                    TimeTarget = 400,
                    TasksTarget = 3,
                    Priority = 0,
                    UserCreatedId = 123,
                    ProfileTypeId = 2,
                },
                new Domain.Models.Profile
                {
                    Id = 3,
                    Name = "Personal Holidays Profile",
                    TimeTarget = 330,
                    Priority = 1,
                    UserCreatedId = 323,
                    ProfileTypeId = 3,
                },
                new Domain.Models.Profile
                {
                    Id = 4,
                    Name = "Personal Custom Profile",
                    TimeTarget = 430,
                    Priority = 2,
                    UserCreatedId = 423,
                    ProfileTypeId = 4,
                },
                new Domain.Models.Profile
                {
                    Id = 5,
                    Name = "Personal Custom Profile",
                    TimeTarget = 5,
                    Priority = 2,
                    UserCreatedId = 523,
                    ProfileTypeId = 5,
                },
            };
    }
}
