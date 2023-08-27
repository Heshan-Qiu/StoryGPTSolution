using AutoMapper;
using StoryGPTEntityAPI.Data;
using StoryGPTEntityAPI.Dtos;
using StoryGPTEntityAPI.Models;

namespace StoryGPTEntityAPI.Services
{
    public class StoryServiceImplement : IStoryService
    {
        private readonly StoryGPTContext _context;
        private readonly IMapper _mapper;

        public StoryServiceImplement(StoryGPTContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateStory(StoryDTO story)
        {
            _context.Story.Add(_mapper.Map<Story>(story));
        }

        public StoryDTO GetStoryById(int id)
        {
            return _mapper.Map<StoryDTO>(_context.Story.FirstOrDefault(s => s.GeneratedId == id));
        }
    }
}