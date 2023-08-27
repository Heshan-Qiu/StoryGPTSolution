using AutoMapper;
using StoryGPTEntityAPI.Dtos;
using StoryGPTEntityAPI.Models;

namespace StoryGPTEntityAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<StoryDto, Story>()
                .ForMember(dest => dest.GeneratedId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Story, StoryDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GeneratedId));
            CreateMap<MetaDataDto, MetaData>();
            CreateMap<MetaData, MetaDataDto>();
        }
    }
}