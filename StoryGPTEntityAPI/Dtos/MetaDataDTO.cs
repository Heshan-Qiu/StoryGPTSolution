using AutoMapper;
using StoryGPTEntityAPI.Models;

namespace StoryGPTEntityAPI.Dtos
{
    public class MetaDataDTO
    {
        public int Id { get; set; }
        public int StoryId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Author { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Prompt { get; set; } = null!;
    }
}