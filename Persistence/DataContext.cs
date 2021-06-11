using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {

        public DbSet<Person> Persons { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(key => key.PersonID);
            modelBuilder.Entity<League>().HasKey(key => key.LeagueID);
            modelBuilder.Entity<Country>().HasKey(key => key.CountryID);
            modelBuilder.Entity<Team>().HasKey(key => key.TeamID);
            modelBuilder.Entity<User>().HasKey(key => key.UserID);

            modelBuilder.Entity<Person>().HasOne(b => b.Team).WithOne(b => b.Person).HasForeignKey<Team>(b => b.TeamID);
            modelBuilder.Entity<Person>().HasOne(b => b.Country).WithOne(b => b.Person).HasForeignKey<Country>(b => b.CountryID);
            modelBuilder.Entity<Person>().HasOne(b => b.User).WithOne(b => b.Person).HasForeignKey<User>(b => b.UserID);

            modelBuilder.Entity<League>().HasOne(b => b.Country).WithOne(b => b.League).HasForeignKey<Country>(b => b.CountryID);

            modelBuilder.Entity<Team>().HasOne(b => b.League).WithOne(b => b.Team).HasForeignKey<League>(b => b.LeagueID);
        }

    }
}
