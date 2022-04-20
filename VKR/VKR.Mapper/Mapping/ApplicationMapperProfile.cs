using AutoMapper;
using VKR.Contracts.Comment;
using VKR.Contracts.Mission;
using VKR.Contracts.Section;
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
                    source => source.MapFrom(c => c.User.FIO));
            CreateMap<CommentDto, Comment>();
            
            CreateMap<Section, SectionDto>();
            CreateMap<SectionDto, Section>();
        }
    }
}