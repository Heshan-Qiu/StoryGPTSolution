using AutoMapper;
using StoryGPTEntityAPI.Dtos;
using StoryGPTEntityAPI.Models;

namespace StoryGPTEntityAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<MetaDataDTO, MetaData>()
                .ForMember(dest => dest.GeneratedId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<MetaData, MetaDataDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GeneratedId));
            CreateMap<StoryDTO, Story>()
                .ForMember(dest => dest.GeneratedId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Story, StoryDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GeneratedId));
        }
    }
}