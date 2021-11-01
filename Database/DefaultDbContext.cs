using Microsoft.EntityFrameworkCore;
using Football.Models;
using Microsoft.Extensions.Options;

namespace Football.Database
{
    public class DefaultDbContext : DbContext
    {
        private readonly DbSettings settings;
        public DbSet<FootballerRecord> Footballers { get; set; }
        public DbSet<TeamRecord> Teams { get; set; }


        public DefaultDbContext(IOptions<DbSettings> dbOptions)
        {
            settings = dbOptions.Value;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={settings.Hostname};Port={settings.Port};Database={settings.DbName};" +
                $"Username={settings.Username};Password={settings.Password}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
