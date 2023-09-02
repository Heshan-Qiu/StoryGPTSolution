namespace StoryGPTWebAPI.Models
{
    public class Story
    {
        public long Id { get; set; }
        public long GeneratedId { get; set; }
        public string StoryText { get; set; } = null!;

        // navigation properties
        public MetaData MetaData { get; set; } = null!;
    }
}