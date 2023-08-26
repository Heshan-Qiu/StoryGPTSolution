namespace StoriesGPTEntities.Models
{
    public class Story
    {
        public int Id { get; set; }
        public int GeneratedId { get; set; }
        public string StoryTitle { get; set; } = null!;
        public string StoryText { get; set; } = null!;
        public MetaData MetaData { get; set; } = null!;
    }
}