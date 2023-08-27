using Microsoft.EntityFrameworkCore;
using StoryGPTProducer.Models;

namespace StoryGPTProducer.Helpers
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }

        public DbSet<Story> Stories { get; set; } = null!;
        public DbSet<MetaData> MetaData { get; set; } = null!;
    }
}