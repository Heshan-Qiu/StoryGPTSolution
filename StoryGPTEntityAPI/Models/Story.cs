namespace StoryGPTEntityAPI.Models
{
    public class Story
    {
        public int Id { get; set; }
        public int GeneratedId { get; set; }
        public string StoryText { get; set; } = null!;
        public MetaData MetaData { get; set; } = null!;
    }
}