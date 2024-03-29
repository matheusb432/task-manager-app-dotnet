﻿using TaskManagerApp.Application.Common.Dtos.Profile;
using TaskManagerApp.Application.Utils;
using TaskManagerApp.Domain.Models;

namespace TaskManagerApp.Application.Profiles
{
    public sealed class ProfileProfiles : AutoMapper.Profile
    {
        public ProfileProfiles()
        {
            CreateMap<ProfileDto, Profile>()
                .ReverseMap()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserCreatedId));
            CreateMap<ProfilePostDto, Profile>()
                .ForMember(
                    dest => dest.TimeTarget,
                    opt => opt.MapFrom(src => TimeUtils.ConvertTimeToShort(src.TimeTarget))
                );
            CreateMap<ProfilePutDto, Profile>()
                .ForMember(
                    dest => dest.TimeTarget,
                    opt => opt.MapFrom(src => TimeUtils.ConvertTimeToShort(src.TimeTarget))
                );
            CreateMap<ProfilePresetTaskItem, ProfilePresetTaskItemDto>().ReverseMap();
            CreateMap<ProfilePresetTaskItemPostDto, ProfilePresetTaskItem>();
            CreateMap<ProfilePresetTaskItemPutDto, ProfilePresetTaskItem>();
            CreateMap<ProfileType, ProfileTypeDto>().ReverseMap();
            CreateMap<ProfileTypePostDto, ProfileType>();
            CreateMap<ProfileTypePutDto, ProfileType>();
        }
    }
}
