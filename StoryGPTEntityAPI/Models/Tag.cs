namespace StoryGPTEntityAPI.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public int GeneratedId { get; set; }
        public MetaData MetaData { get; set; } = null!;
        public string TagName { get; set; } = null!;
    }
}