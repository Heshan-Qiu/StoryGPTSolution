using AutoMapper;
using IdGen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using StoryGPTEntityAPI.Data;
using StoryGPTEntityAPI.Dtos;
using StoryGPTEntityAPI.Models;

namespace StoryGPTEntityAPI.Services
{
    public sealed class StoryServiceImplement : IStoryService
    {
        private static StoryServiceImplement? instance = null;
        private static readonly object padlock = new object();

        private StoryServiceImplement()
        {
            // Private constructor to prevent instantiation from outside
        }

        public static StoryServiceImplement Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new StoryServiceImplement();
                    }
                    return instance;
                }
            }
        }

        public async Task<long> CreateStoryAsync(StoryGPTDbContext context, IMapper mapper, Story story)
        {
            story.GeneratedId = new IdGenerator(0).CreateId();
            context.Story.Add(story);
            await context.SaveChangesAsync();
            return story.GeneratedId;
        }

        public StoryDTO GetStoryById(int id)
        {
            throw new System.NotImplementedException();
            // return _mapper.Map<StoryDTO>(_context.Story.FirstOrDefault(s => s.GeneratedId == id));
        }
    }
}