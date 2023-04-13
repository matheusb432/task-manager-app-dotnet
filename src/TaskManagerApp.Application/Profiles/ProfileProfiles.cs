using TaskManagerApp.Application.ViewModels.Profile;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public sealed class ProfileProfiles : AutoMapper.Profile
    {
        public ProfileProfiles()
        {
            CreateMap<Profile, ProfileViewModel>().ReverseMap();
            CreateMap<ProfilePostViewModel, Profile>();
            CreateMap<ProfilePutViewModel, Profile>();
            CreateMap<ProfilePresetTaskItem, ProfilePresetTaskItemViewModel>().ReverseMap();
            CreateMap<ProfilePresetTaskItemPostViewModel, ProfilePresetTaskItem>();
            CreateMap<ProfilePresetTaskItemPutViewModel, ProfilePresetTaskItem>();
            CreateMap<ProfileType, ProfileTypeViewModel>().ReverseMap();
            CreateMap<ProfileTypePostViewModel, ProfileType>();
            CreateMap<ProfileTypePutViewModel, ProfileType>();
        }
    }
}