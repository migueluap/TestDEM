using hey_url_challenge_code_dotnet.Data.Mappings;
using hey_url_challenge_code_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace HeyUrlChallengeCodeDotnet.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Url> Urls { get; set; }
        public DbSet<Click> Clicks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UrlMap());
            modelBuilder.ApplyConfiguration(new ClickMap());
        }
    }
}