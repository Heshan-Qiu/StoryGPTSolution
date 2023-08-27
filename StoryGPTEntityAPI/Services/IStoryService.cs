using StoryGPTEntityAPI.Dtos;

namespace StoryGPTEntityAPI.Services
{
    public interface IStoryService
    {
        void CreateStory(StoryDTO story);
        StoryDTO GetStoryById(int id);
    }
}