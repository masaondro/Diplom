using AutoMapper;
using VKR.Contracts.Comment;
using VKR.Contracts.Mission;
using VKR.Contracts.Section;
using VKR.Contracts.User;
using VKR.Contracts.UserProfile;
using VKR.Domain.Entities;

namespace VKR.Mapper.Mapping
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<Mission, MissionDto>()
                .ForMember(destination => destination.Comment,
                    source => source.MapFrom(m => m.Comment));
            CreateMap<MissionDto, Mission>();
            
            CreateMap<Comment, CommentDto>()
                .ForMember(destination => destination.UserName,
                    source => source.MapFrom(c => c.User.User.UserName));
            CreateMap<CommentDto, Comment>();
            
            CreateMap<Section, SectionDto>();
            CreateMap<SectionDto, Section>();

            CreateMap<UserProfile, UserProfileDto>();
            CreateMap<UserProfileDto, UserProfile>();

            CreateMap<UserProfileMission, UserProfileMissionDto>();
            CreateMap<UserProfileMissionDto, UserProfileMission>();
            
            CreateMap<UserProfileSection, UserProfileSectionDto>();
            CreateMap<UserProfileSectionDto, UserProfileSection>();
            
            CreateMap<RegisterUserDto, ApplicationUser>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(dto => dto.Login))
                .ForMember(dest => dest.Email, src => src.MapFrom(dto => dto.Email));
        }
    }
}