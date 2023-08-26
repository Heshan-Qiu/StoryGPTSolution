namespace StoriesGPTEntities.Models
{
    public class MetaData
    {
        public int Id { get; set; }
        public int GeneratedId { get; set; }
        public int StoryId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Author { get; set; } = null!;
        public string Prompt { get; set; } = null!;
        public ICollection<Tag> Tags { get; set; } = null!;
    }
}