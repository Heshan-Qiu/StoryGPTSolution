namespace StoryGPTEntityAPI.Models
{
    public class Tag
    {
        public long Id { get; set; }
        public long MetaDataId { get; set; }
        public string TagName { get; set; } = null!;
    }
}