using AutoMapper;
using StoryGPTEntityAPI.Data;
using StoryGPTEntityAPI.Dtos;
using StoryGPTEntityAPI.Models;

namespace StoryGPTEntityAPI.Services
{
    public interface IStoryService
    {
        Task<long> CreateStoryAsync(StoryGPTDbContext context, IMapper mapper, Story story);
        StoryDTO GetStoryById(int id);
    }
}