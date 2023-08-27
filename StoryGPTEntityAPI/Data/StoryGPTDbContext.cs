using Microsoft.EntityFrameworkCore;
using StoryGPTEntityAPI.Models;

namespace StoryGPTEntityAPI.Data
{
    public class StoryGPTDbContext : DbContext
    {
        public DbSet<Story> Story { get; set; } = null!;
        public DbSet<MetaData> MetaData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=StoriesGPT.db");
        }
    }
}