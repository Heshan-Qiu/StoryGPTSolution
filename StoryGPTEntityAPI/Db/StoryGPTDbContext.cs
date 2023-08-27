using Microsoft.EntityFrameworkCore;
using StoryGPTEntityAPI.Models;

namespace StoryGPTEntityAPI.Db
{
    public class StoryGPTDbContext : DbContext
    {
        public DbSet<Story> Story { get; set; } = null!;
        public DbSet<MetaData> MetaData { get; set; } = null!;

        public StoryGPTDbContext(DbContextOptions<StoryGPTDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("StoryGPT");
        }
    }
}