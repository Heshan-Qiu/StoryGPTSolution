using AutoMapper;
using StoryGPTEntityAPI.Data;
using StoryGPTEntityAPI.Models;

namespace StoryGPTEntityAPI.Services
{
    public interface IStoryService
    {
        Task<long> CreateStoryAsync(StoryGPTDbContext context, Story story);
        Story GetStoryById(StoryGPTDbContext context, long id);
    }
}