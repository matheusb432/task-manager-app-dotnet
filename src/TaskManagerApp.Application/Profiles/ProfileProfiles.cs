using TaskManagerApp.Application.Utils;
using TaskManagerApp.Application.ViewModels.Profile;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public sealed class ProfileProfiles : AutoMapper.Profile
    {
        public ProfileProfiles()
        {
            CreateMap<ProfileViewModel, Profile>().ReverseMap();
            CreateMap<ProfilePostViewModel, Profile>()
                .ForMember(dest => dest.TimeTarget, opt => opt.MapFrom(src => TimeUtils.ConvertTimeToShort(src.TimeTarget)));
            CreateMap<ProfilePutViewModel, Profile>()
                .ForMember(dest => dest.TimeTarget, opt => opt.MapFrom(src => TimeUtils.ConvertTimeToShort(src.TimeTarget)));
            CreateMap<ProfilePresetTaskItem, ProfilePresetTaskItemViewModel>().ReverseMap();
            CreateMap<ProfilePresetTaskItemPostViewModel, ProfilePresetTaskItem>();
            CreateMap<ProfilePresetTaskItemPutViewModel, ProfilePresetTaskItem>();
            CreateMap<ProfileType, ProfileTypeViewModel>().ReverseMap();
            CreateMap<ProfileTypePostViewModel, ProfileType>();
            CreateMap<ProfileTypePutViewModel, ProfileType>();
        }
    }
}