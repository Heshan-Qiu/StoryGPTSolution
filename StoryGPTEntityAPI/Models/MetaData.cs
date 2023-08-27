namespace StoryGPTEntityAPI.Models
{
    public class MetaData
    {
        public long Id { get; set; }
        public long StoryId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Author { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Prompt { get; set; } = null!;
        public ICollection<Tag> Tags { get; set; } = null!;
    }
}