using AutoMapper;
using StoryGPTEntityAPI.Dtos;
using StoryGPTEntityAPI.Models;

namespace StoryGPTEntityAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<StoryDTO, Story>()
                .ForMember(dest => dest.GeneratedId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Story, StoryDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GeneratedId));
            CreateMap<MetaDataDTO, MetaData>();
            CreateMap<MetaData, MetaDataDTO>();
        }
    }
}