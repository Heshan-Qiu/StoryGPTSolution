using Microsoft.EntityFrameworkCore;

namespace StoriesGPTEntities.Data
{
    public class StoriesGPTContext : DbContext
    {
        public DbSet<Models.Story> Story { get; set; } = null!;
        public DbSet<Models.MetaData> MetaData { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=StoriesGPT.db");
        }
    }
}