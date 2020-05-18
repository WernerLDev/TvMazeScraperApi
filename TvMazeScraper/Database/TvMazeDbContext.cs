using Microsoft.EntityFrameworkCore;
using TvMazeScraper.Database.Models;

namespace TvMazeScraper.Database
{
    public class TvMazeDbContext : DbContext
    {
        public DbSet<Show> Shows { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<ShowPerson> ShowPersons { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ShowPerson>().HasKey(sp => new { sp.ShowId, sp.PersonId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=TvMazeScraperData.db");
    }
}
