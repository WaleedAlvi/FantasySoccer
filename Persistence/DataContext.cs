using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<FantasyLeague> FantasyLeagues { get; set; }
        public DbSet<FantasyLeagueAdmin> FantasyLeaguesAdmins { get; set; }
        public DbSet<FantasyLeagueTeams> FantasyLeagueTeams { get; set; }
        public DbSet<FantasyTeam> FantasyTeams { get; set; }
        public DbSet<Formation> Formations { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Matchday> Matchdays { get; set; }
        public DbSet<MatchdayTeam> MatchdayTeams { get; set; }
        public DbSet<MatchdayTeamConfiguration> MatchdayTeamConfigurations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Country
            modelBuilder.Entity<Country>().HasKey(key => key.CountryID);
            modelBuilder.Entity<Country>().Property(p => p.APIFootballID).IsRequired();
            modelBuilder.Entity<Country>().Property(p => p.CountryName).IsRequired();
            modelBuilder.Entity<Country>().Property(p => p.Flag).IsRequired();
            modelBuilder.Entity<Country>().Property(p => p.DateCreated).IsRequired();
            modelBuilder.Entity<Country>().Property(p => p.DateUpdated).IsRequired();
            #endregion

            #region Person
            modelBuilder.Entity<Person>().HasKey(key => key.PersonID);
            modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.LastName).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.DateOfBirth).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.CountryID).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.TeamID).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.DateCreated).IsRequired();
            modelBuilder.Entity<Person>().Property(p => p.DateUpdated).IsRequired();
            modelBuilder.Entity<Person>().HasOne(b => b.Team).WithMany(b => b.Person).HasForeignKey(b => b.TeamID);
            modelBuilder.Entity<Person>().HasOne(b => b.Country).WithMany(b => b.Person).HasForeignKey(b => b.CountryID).OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region User
            modelBuilder.Entity<User>().HasKey(key => key.UserID);
            modelBuilder.Entity<User>().Property(p => p.FirebaseID).IsRequired().HasMaxLength(28);
            modelBuilder.Entity<User>().Property(p => p.PersonID).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.DateCreated).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.DateUpdated).IsRequired();
            modelBuilder.Entity<User>().HasOne(b => b.Person).WithOne(b => b.User).HasForeignKey<User>(b => b.PersonID);
            #endregion

            #region Formation
            modelBuilder.Entity<Formation>().HasKey(key => key.FormationID);
            modelBuilder.Entity<Formation>().Property(p => p.FormationName).IsRequired();
            modelBuilder.Entity<Formation>().Property(p => p.DefenderCount).IsRequired();
            modelBuilder.Entity<Formation>().Property(p => p.MidfielderCount).IsRequired();
            modelBuilder.Entity<Formation>().Property(p => p.ForwardCount).IsRequired();
            modelBuilder.Entity<Formation>().Property(p => p.DateCreated).IsRequired();
            modelBuilder.Entity<Formation>().Property(p => p.DateUpdated).IsRequired();
            #endregion

            #region League
            modelBuilder.Entity<League>().HasKey(key => key.LeagueID);
            modelBuilder.Entity<League>().Property(p => p.APIFootballID).IsRequired();
            modelBuilder.Entity<League>().Property(p => p.LeagueName).IsRequired();
            modelBuilder.Entity<League>().Property(p => p.LeagueLogo).IsRequired();
            modelBuilder.Entity<League>().Property(p => p.CountryID).IsRequired();
            modelBuilder.Entity<League>().Property(p => p.DateCreated).IsRequired();
            modelBuilder.Entity<League>().Property(p => p.DateUpdated).IsRequired();
            modelBuilder.Entity<League>().HasOne(b => b.Country).WithMany(b => b.League).HasForeignKey(b => b.CountryID);
            #endregion

            #region Team
            modelBuilder.Entity<Team>().HasKey(key => key.TeamID);
            modelBuilder.Entity<Team>().Property(p => p.APIFootballID).IsRequired();
            modelBuilder.Entity<Team>().Property(p => p.TeamName).IsRequired();
            modelBuilder.Entity<Team>().Property(p => p.TeamLogo).IsRequired();
            modelBuilder.Entity<Team>().Property(p => p.LeagueID).IsRequired();
            modelBuilder.Entity<Team>().Property(p => p.DateCreated).IsRequired();
            modelBuilder.Entity<Team>().Property(p => p.DateUpdated).IsRequired();
            modelBuilder.Entity<Team>().HasOne(b => b.League).WithOne(b => b.Team).HasForeignKey<Team>(b => b.LeagueID);
            #endregion

            #region Player
            modelBuilder.Entity<Player>().HasKey(key => key.PlayerID);
            modelBuilder.Entity<Player>().Property(p => p.APIFootballID).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.FirstName).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.LastName).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.PreferredName).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.DateOfBirth).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.CountryID).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.TeamID).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.Position).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.Height).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.Weight).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.Injured).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.Value).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.DateCreated).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.DateUpdated).IsRequired();
            modelBuilder.Entity<Player>().HasOne(b => b.Team).WithMany(b => b.Player).HasForeignKey(b => b.TeamID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Player>().HasOne(b => b.Country).WithMany(b => b.Player).HasForeignKey(b => b.CountryID).OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region Matchday
            modelBuilder.Entity<Matchday>().HasKey(key => key.MatchdayID);
            modelBuilder.Entity<Matchday>().Property(p => p.LeagueID).IsRequired();
            modelBuilder.Entity<Matchday>().Property(p => p.Season).IsRequired();
            modelBuilder.Entity<Matchday>().Property(p => p.MatchdayCount).IsRequired();
            modelBuilder.Entity<Matchday>().Property(p => p.StartDate).IsRequired();
            modelBuilder.Entity<Matchday>().Property(p => p.EndDate).IsRequired();
            modelBuilder.Entity<Matchday>().Property(p => p.DateCreated).IsRequired();
            modelBuilder.Entity<Matchday>().Property(p => p.DateUpdated).IsRequired();
            modelBuilder.Entity<Matchday>().HasOne(b => b.League).WithMany(b => b.MatchDays).HasForeignKey(f => f.LeagueID);
            #endregion

            #region FantasyTeam
            modelBuilder.Entity<FantasyTeam>().HasKey(key => key.FantasyTeamID);
            modelBuilder.Entity<FantasyTeam>().Property(p => p.FantasyTeamName).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.FantasyTeamLogo).HasDefaultValue("Hello World, This  is an image");
            modelBuilder.Entity<FantasyTeam>().Property(p => p.PersonID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.MoneyBalance).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.GoalieOneID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.GoalieTwoID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.DefenderOneID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.DefenderTwoID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.DefenderThreeID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.DefenderFourID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.DefenderFiveID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.MidfielderOneID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.MidfielderTwoID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.MidfielderThreeID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.MidfielderFourID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.MidfielderFiveID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.ForwardOneID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.ForwardTwoID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.ForwardThreeID).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.DateCreated).IsRequired();
            modelBuilder.Entity<FantasyTeam>().Property(p => p.DateUpdated).IsRequired();
            modelBuilder.Entity<FantasyTeam>().HasOne(b => b.Person).WithMany(b => b.FantasyTeams).HasForeignKey(b => b.PersonID);
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.GoalieOne).WithMany(p => p.GoalieOneFantasyTeams).HasForeignKey(t => t.GoalieOneID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.GoalieTwo).WithMany(p => p.GoalieTwoFantasyTeams).HasForeignKey(t => t.GoalieTwoID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.DefenderOne).WithMany(p => p.DefenderOneFantasyTeams).HasForeignKey(t => t.DefenderOneID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.DefenderTwo).WithMany(p => p.DefenderTwoFantasyTeams).HasForeignKey(t => t.DefenderTwoID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.DefenderThree).WithMany(p => p.DefenderThreeFantasyTeams).HasForeignKey(t => t.DefenderThreeID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.DefenderFour).WithMany(p => p.DefenderFourFantasyTeams).HasForeignKey(t => t.DefenderFourID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.DefenderFive).WithMany(p => p.DefenderFiveFantasyTeams).HasForeignKey(t => t.DefenderFiveID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.MidfielderOne).WithMany(p => p.MidfielderOneFantasyTeams).HasForeignKey(t => t.MidfielderOneID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.MidfielderTwo).WithMany(p => p.MidfielderTwoFantasyTeams).HasForeignKey(t => t.MidfielderTwoID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.MidfielderThree).WithMany(p => p.MidfielderThreeFantasyTeams).HasForeignKey(t => t.MidfielderThreeID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.MidfielderFour).WithMany(p => p.MidfielderFourFantasyTeams).HasForeignKey(t => t.MidfielderFourID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.MidfielderFive).WithMany(p => p.MidfielderFiveFantasyTeams).HasForeignKey(t => t.MidfielderFiveID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.ForwardOne).WithMany(p => p.ForwardOneFantasyTeams).HasForeignKey(t => t.ForwardOneID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.ForwardTwo).WithMany(p => p.ForwardTwoFantasyTeams).HasForeignKey(t => t.ForwardTwoID).OnDelete(DeleteBehavior.NoAction); ;
            modelBuilder.Entity<FantasyTeam>().HasOne(m => m.ForwardThree).WithMany(p => p.ForwardThreeFantasyTeams).HasForeignKey(t => t.ForwardThreeID).OnDelete(DeleteBehavior.NoAction);

            // Constraints for Players not equaling others players in the team
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_GoalieOne_Unique", @"GoalieOneID <> GoalieTwoID AND 
									                                                                       GoalieOneID <> DefenderOneID AND
										                                                                   GoalieOneID <> DefenderTwoID AND
										                                                                   GoalieOneID <> DefenderThreeID AND
										                                                                   GoalieOneID <> DefenderFourID AND
										                                                                   GoalieOneID <> DefenderFiveID AND
										                                                                   GoalieOneID <> MidfielderOneID AND
										                                                                   GoalieOneID <> MidfielderTwoID AND
										                                                                   GoalieOneID <> MidfielderThreeID AND
										                                                                   GoalieOneID <> MidfielderFourID AND
										                                                                   GoalieOneID <> MidfielderFiveID AND
										                                                                   GoalieOneID <> ForwardOneID AND
										                                                                   GoalieOneID <> ForwardTwoID AND
										                                                                   GoalieOneID <> ForwardThreeID"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_GoalieTwo_Unique", @"GoalieTwoID <> GoalieOneID AND 
                                                                                                           GoalieTwoID <> DefenderOneID AND
                                                                                                           GoalieTwoID <> DefenderTwoID AND
                                                                                                           GoalieTwoID <> DefenderThreeID AND
                                                                                                           GoalieTwoID <> DefenderFourID AND
                                                                                                           GoalieTwoID <> DefenderFiveID AND
                                                                                                           GoalieTwoID <> MidfielderOneID AND
                                                                                                           GoalieTwoID <> MidfielderTwoID AND
                                                                                                           GoalieTwoID <> MidfielderThreeID AND
                                                                                                           GoalieTwoID <> MidfielderFourID AND
                                                                                                           GoalieTwoID <> MidfielderFiveID AND
                                                                                                           GoalieTwoID <> ForwardOneID AND
                                                                                                           GoalieTwoID <> ForwardTwoID AND
                                                                                                           GoalieTwoID <> ForwardThreeID"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_DefenderOne_Unique", @"DefenderOneID <> GoalieTwoID AND 
                                                                                                             DefenderOneID <> GoallieOneID AND
                                                                                                             DefenderOneID <> DefenderTwoID AND
                                                                                                             DefenderOneID <> DefenderThreeID AND
                                                                                                             DefenderOneID <> DefenderFourID AND
                                                                                                             DefenderOneID <> DefenderFiveID AND
                                                                                                             DefenderOneID <> MidfielderOneID AND
                                                                                                             DefenderOneID <> MidfielderTwoID AND
                                                                                                             DefenderOneID <> MidfielderThreeID AND
                                                                                                             DefenderOneID <> MidfielderFourID AND
                                                                                                             DefenderOneID <> MidfielderFiveID AND
                                                                                                             DefenderOneID <> ForwardOneID AND
                                                                                                             DefenderOneID <> ForwardTwoID AND
                                                                                                             DefenderOneID <> ForwardThreeID"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_DefenderTwo_Unique", @"DefenderTwoID <> GoalieTwoID AND 
                                                                                                             DefenderTwoID <> DefenderOneID AND
                                                                                                             DefenderTwoID <> GoalieOneID AND
                                                                                                             DefenderTwoID <> DefenderThreeID AND
                                                                                                             DefenderTwoID <> DefenderFourID AND
                                                                                                             DefenderTwoID <> DefenderFiveID AND
                                                                                                             DefenderTwoID <> MidfielderOneID AND
                                                                                                             DefenderTwoID <> MidfielderTwoID AND
                                                                                                             DefenderTwoID <> MidfielderThreeID AND
                                                                                                             DefenderTwoID <> MidfielderFourID AND
                                                                                                             DefenderTwoID <> MidfielderFiveID AND
                                                                                                             DefenderTwoID <> ForwardOneID AND
                                                                                                             DefenderTwoID <> ForwardTwoID AND
                                                                                                             DefenderTwoID <> ForwardThreeID"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_DefenderThree_Unique", @"DefenderThreeID <> GoalieTwoID AND 
                                                                                                               DefenderThreeID <> DefenderOneID AND
                                                                                                               DefenderThreeID <> DefenderTwoID AND
                                                                                                               DefenderThreeID <> GoalieOneID AND
                                                                                                               DefenderThreeID <> DefenderFourID AND
                                                                                                               DefenderThreeID <> DefenderFiveID AND
                                                                                                               DefenderThreeID <> MidfielderOneID AND
                                                                                                               DefenderThreeID <> MidfielderTwoID AND
                                                                                                               DefenderThreeID <> MidfielderThreeID AND
                                                                                                               DefenderThreeID <> MidfielderFourID AND
                                                                                                               DefenderThreeID <> MidfielderFiveID AND
                                                                                                               DefenderThreeID <> ForwardOneID AND
                                                                                                               DefenderThreeID <> ForwardTwoID AND
                                                                                                               DefenderThreeID <> ForwardThreeID"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_DefenderFour_Unique", @"DefenderFourID <> GoalieTwoID AND 
                                                                                                              DefenderFourID <> DefenderOneID AND
                                                                                                              DefenderFourID <> DefenderTwoID AND
                                                                                                              DefenderFourID <> GoalieOneID AND
                                                                                                              DefenderFourID <> DefenderThreeID AND
                                                                                                              DefenderFourID <> DefenderFiveID AND
                                                                                                              DefenderFourID <> MidfielderOneID AND
                                                                                                              DefenderFourID <> MidfielderTwoID AND
                                                                                                              DefenderFourID <> MidfielderThreeID AND
                                                                                                              DefenderFourID <> MidfielderFourID AND
                                                                                                              DefenderFourID <> MidfielderFiveID AND
                                                                                                              DefenderFourID <> ForwardOneID AND
                                                                                                              DefenderFourID <> ForwardTwoID AND
                                                                                                              DefenderFourID <> ForwardThreeID"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_DefenderFive_Unique", @"DefenderFiveID <> GoalieTwoID AND 
                                                                                                              DefenderFiveID <> DefenderOneID AND
                                                                                                              DefenderFiveID <> DefenderTwoID AND
                                                                                                              DefenderFiveID <> DefenderThreeID AND
                                                                                                              DefenderFiveID <> DefenderFourID AND
                                                                                                              DefenderFiveID <> GoalieOneID AND
                                                                                                              DefenderFiveID <> MidfielderOneID AND
                                                                                                              DefenderFiveID <> MidfielderTwoID AND
                                                                                                              DefenderFiveID <> MidfielderThreeID AND
                                                                                                              DefenderFiveID <> MidfielderFourID AND
                                                                                                              DefenderFiveID <> MidfielderFiveID AND
                                                                                                              DefenderFiveID <> ForwardOneID AND
                                                                                                              DefenderFiveID <> ForwardTwoID AND
                                                                                                              DefenderFiveID <> ForwardThreeID"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_MidfielderOne_Unique", @"MidfielderOneID <> GoalieOneID AND 
                                                                                                               MidfielderOneID <> DefenderOneID AND
                                                                                                               MidfielderOneID <> DefenderTwoID AND
                                                                                                               MidfielderOneID <> DefenderThreeID AND
                                                                                                               MidfielderOneID <> DefenderFourID AND
                                                                                                               MidfielderOneID <> DefenderFiveID AND
                                                                                                               MidfielderOneID <> GoalieTwoID AND
                                                                                                               MidfielderOneID <> MidfielderTwoID AND
                                                                                                               MidfielderOneID <> MidfielderThreeID AND
                                                                                                               MidfielderOneID <> MidfielderFourID AND
                                                                                                               MidfielderOneID <> MidfielderFiveID AND
                                                                                                               MidfielderOneID <> ForwardOneID AND
                                                                                                               MidfielderOneID <> ForwardTwoID AND
                                                                                                               MidfielderOneID <> ForwardThreeID"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_MidfielderTwo_Unique", @"MidfielderTwoID <> GoalieTwoID AND 
                                                                                                               MidfielderTwoID <> GoallieOneID AND
                                                                                                               MidfielderTwoID <> DefenderTwoID AND
                                                                                                               MidfielderTwoID <> DefenderThreeID AND
                                                                                                               MidfielderTwoID <> DefenderFourID AND
                                                                                                               MidfielderTwoID <> DefenderFiveID AND
                                                                                                               MidfielderTwoID <> MidfielderOneID AND
                                                                                                               MidfielderTwoID <> DefenderOneID AND
                                                                                                               MidfielderTwoID <> MidfielderThreeID AND
                                                                                                               MidfielderTwoID <> MidfielderFourID AND
                                                                                                               MidfielderTwoID <> MidfielderFiveID AND
                                                                                                               MidfielderTwoID <> ForwardOneID AND
                                                                                                               MidfielderTwoID <> ForwardTwoID AND
                                                                                                               MidfielderTwoID <> ForwardThreeID)"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_MidfielderThree_Unique", @"MidfielderThreeID <> GoalieOneID AND 
                                                                                                               MidfielderThreeID <> DefenderOneID AND
                                                                                                               MidfielderThreeID <> DefenderTwoID AND
                                                                                                               MidfielderThreeID <> DefenderThreeID AND
                                                                                                               MidfielderThreeID <> DefenderFourID AND
                                                                                                               MidfielderThreeID <> DefenderFiveID AND
                                                                                                               MidfielderThreeID <> GoalieTwoID AND
                                                                                                               MidfielderThreeID <> MidfielderTwoID AND
                                                                                                               MidfielderThreeID <> MidfielderOneID AND
                                                                                                               MidfielderThreeID <> MidfielderFourID AND
                                                                                                               MidfielderThreeID <> MidfielderFiveID AND
                                                                                                               MidfielderThreeID <> ForwardOneID AND
                                                                                                               MidfielderThreeID <> ForwardTwoID AND
                                                                                                               MidfielderThreeID <> ForwardThreeID"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_MidfielderFour_Unique", @"MidfielderFourID <> GoalieTwoID AND 
                                                                                                                MidfielderFourID <> DefenderOneID AND
                                                                                                                MidfielderFourID <> DefenderTwoID AND
                                                                                                                MidfielderFourID <> GoalieOneID AND
                                                                                                                MidfielderFourID <> DefenderFourID AND
                                                                                                                MidfielderFourID <> DefenderFiveID AND
                                                                                                                MidfielderFourID <> MidfielderOneID AND
                                                                                                                MidfielderFourID <> MidfielderTwoID AND
                                                                                                                MidfielderFourID <> MidfielderThreeID AND
                                                                                                                MidfielderFourID <> DefenderThreeID AND
                                                                                                                MidfielderFourID <> MidfielderFiveID AND
                                                                                                                MidfielderFourID <> ForwardOneID AND
                                                                                                                MidfielderFourID <> ForwardTwoID AND
                                                                                                                MidfielderFourID <> ForwardThreeID"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_MidfielderFive_Unique", @"MidfielderFiveID <> GoalieTwoID AND 
                                                                                                                MidfielderFiveID <> DefenderOneID AND
                                                                                                                MidfielderFiveID <> DefenderTwoID AND
                                                                                                                MidfielderFiveID <> GoalieOneID AND
                                                                                                                MidfielderFiveID <> DefenderFourID AND
                                                                                                                MidfielderFiveID <> DefenderFiveID AND
                                                                                                                MidfielderFiveID <> MidfielderOneID AND
                                                                                                                MidfielderFiveID <> MidfielderTwoID AND
                                                                                                                MidfielderFiveID <> MidfielderThreeID AND
                                                                                                                MidfielderFiveID <> MidfielderFourID AND
                                                                                                                MidfielderFiveID <> DefenderThreeID AND
                                                                                                                MidfielderFiveID <> ForwardOneID AND
                                                                                                                MidfielderFiveID <> ForwardTwoID AND
                                                                                                                MidfielderFiveID <> ForwardThreeID"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_ForwardOne_Unique", @"ForwardOneID <> GoalieTwoID AND 
                                                                                                            ForwardOneID <> DefenderOneID AND
                                                                                                            ForwardOneID <> DefenderTwoID AND
                                                                                                            ForwardOneID <> DefenderThreeID AND
                                                                                                            ForwardOneID <> DefenderFourID AND
                                                                                                            ForwardOneID <> DefenderFiveID AND
                                                                                                            ForwardOneID <> MidfielderOneID AND
                                                                                                            ForwardOneID <> MidfielderTwoID AND
                                                                                                            ForwardOneID <> MidfielderThreeID AND
                                                                                                            ForwardOneID <> MidfielderFourID AND
                                                                                                            ForwardOneID <> MidfielderFiveID AND
                                                                                                            ForwardOneID <> GoalieOneID AND
                                                                                                            ForwardOneID <> ForwardTwoID AND
                                                                                                            ForwardOneID <> ForwardThreeID"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_ForwardTwo_Unique", @"ForwardTwoID <> GoalieOneID AND 
                                                                                                            ForwardTwoID <> DefenderOneID AND
                                                                                                            ForwardTwoID <> DefenderTwoID AND
                                                                                                            ForwardTwoID <> DefenderThreeID AND
                                                                                                            ForwardTwoID <> DefenderFourID AND
                                                                                                            ForwardTwoID <> DefenderFiveID AND
                                                                                                            ForwardTwoID <> MidfielderOneID AND
                                                                                                            ForwardTwoID <> MidfielderTwoID AND
                                                                                                            ForwardTwoID <> MidfielderThreeID AND
                                                                                                            ForwardTwoID <> MidfielderFourID AND
                                                                                                            ForwardTwoID <> MidfielderFiveID AND
                                                                                                            ForwardTwoID <> ForwardOneID AND
                                                                                                            ForwardTwoID <> GoalieTwoID AND
                                                                                                            ForwardTwoID <> ForwardThreeID"));
            modelBuilder.Entity<FantasyTeam>(entity => entity.HasCheckConstraint("CHK_ForwardThree_Unique", @"ForwardThreeID <> GoalieTwoID AND 
                                                                                                              ForwardThreeID <> GoallieOneID AND
                                                                                                              ForwardThreeID <> DefenderTwoID AND
                                                                                                              ForwardThreeID <> DefenderThreeID AND
                                                                                                              ForwardThreeID <> DefenderFourID AND
                                                                                                              ForwardThreeID <> DefenderFiveID AND
                                                                                                              ForwardThreeID <> MidfielderOneID AND
                                                                                                              ForwardThreeID <> MidfielderTwoID AND
                                                                                                              ForwardThreeID <> MidfielderThreeID AND
                                                                                                              ForwardThreeID <> MidfielderFourID AND
                                                                                                              ForwardThreeID <> MidfielderFiveID AND
                                                                                                              ForwardThreeID <> ForwardOneID AND
                                                                                                              ForwardThreeID <> ForwardTwoID AND
                                                                                                              ForwardThreeID <> DefenderOneID"));

            #endregion

            #region FantasyLeague
            modelBuilder.Entity<FantasyLeague>().HasKey(key => key.FantasyLeagueID);
            modelBuilder.Entity<FantasyLeague>().Property(p => p.LeagueName).IsRequired();
            modelBuilder.Entity<FantasyLeague>().Property(p => p.LeagueLogo).HasDefaultValue("Default League Logo");
            modelBuilder.Entity<FantasyLeague>().Property(p => p.IsPublic).HasDefaultValue(true);
            modelBuilder.Entity<FantasyLeague>().Property(p => p.NumberOfTeams).IsRequired().HasDefaultValue(10);
            modelBuilder.Entity<FantasyLeague>().Property(p => p.DateCreated).IsRequired();
            modelBuilder.Entity<FantasyLeague>().Property(p => p.DateUpdated).IsRequired();
            #endregion

            #region FantasyLeagueAdmin
            modelBuilder.Entity<FantasyLeagueAdmin>().HasKey(key => new { key.FantasyLeagueID, key.PersonID });
            modelBuilder.Entity<FantasyLeagueAdmin>().HasOne(b => b.FantasyLeague).WithMany(b => b.FantasyLeagueAdmins).HasForeignKey(b => b.FantasyLeagueID);
            modelBuilder.Entity<FantasyLeagueAdmin>().HasOne(b => b.Person).WithMany(b => b.FantasyLeagueAdmins).HasForeignKey(b => b.PersonID);
            #endregion

            #region FantasyLeagueTeams
            modelBuilder.Entity<FantasyLeagueTeams>().HasKey(key => new { key.FantasyLeagueID, key.FantasyTeamID });
            modelBuilder.Entity<FantasyLeagueTeams>().HasOne(b => b.FantasyLeague).WithMany(b => b.FantasyLeagueTeams).HasForeignKey(b => b.FantasyLeagueID);
            modelBuilder.Entity<FantasyLeagueTeams>().HasOne(b => b.FantasyTeam).WithMany(b => b.FantasyLeagueTeams).HasForeignKey(b => b.FantasyTeamID);
            #endregion

            #region MatchdayTeam
            modelBuilder.Entity<MatchdayTeam>().HasKey(key => key.MatchdayTeamID);
            modelBuilder.Entity<MatchdayTeam>().Property(p => p.DateCreated).IsRequired();
            modelBuilder.Entity<MatchdayTeam>().Property(p => p.DateUpdated).IsRequired();
            modelBuilder.Entity<MatchdayTeam>().HasOne(b => b.MatchdayTeamConfiguration).WithOne(b => b.MatchdayTeam).HasForeignKey<MatchdayTeam>(b => b.MatchdayTeamConfigurationID);
            modelBuilder.Entity<MatchdayTeam>().HasOne(m => m.Goalie).WithMany(p => p.GoalieMatchdayTeams).HasForeignKey(t => t.GoalieID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeam>().HasOne(m => m.PlayerOne).WithMany(p => p.PlayerOneMatchdayTeams).HasForeignKey(t => t.PlayerOneID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeam>().HasOne(m => m.PlayerTwo).WithMany(p => p.PlayerTwoMatchdayTeams).HasForeignKey(t => t.PlayerTwoID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeam>().HasOne(m => m.PlayerThree).WithMany(p => p.PlayerThreeMatchdayTeams).HasForeignKey(t => t.PlayerThreeID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeam>().HasOne(m => m.PlayerFour).WithMany(p => p.PlayerFourMatchdayTeams).HasForeignKey(t => t.PlayerFourID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeam>().HasOne(m => m.PlayerFive).WithMany(p => p.PlayerFiveMatchdayTeams).HasForeignKey(t => t.PlayerFiveID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeam>().HasOne(m => m.PlayerSix).WithMany(p => p.PlayerSixMatchdayTeams).HasForeignKey(t => t.PlayerSixID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeam>().HasOne(m => m.PlayerSeven).WithMany(p => p.PlayerSevenMatchdayTeams).HasForeignKey(t => t.PlayerSevenID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeam>().HasOne(m => m.PlayerEight).WithMany(p => p.PlayerEightMatchdayTeams).HasForeignKey(t => t.PlayerNineID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeam>().HasOne(m => m.PlayerTen).WithMany(p => p.PlayerTenMatchdayTeams).HasForeignKey(t => t.PlayerTenID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeam>().HasOne(m => m.BenchOne).WithMany(p => p.BenchOneMatchdayTeams).HasForeignKey(t => t.BenchOneID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeam>().HasOne(m => m.BenchTwo).WithMany(p => p.BenchTwoMatchdayTeams).HasForeignKey(t => t.BenchTwoID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeam>().HasOne(m => m.BenchThree).WithMany(p => p.BenchThreeMatchdayTeams).HasForeignKey(t => t.BenchThreeID).OnDelete(DeleteBehavior.NoAction);
            #endregion

            #region MatchdayTeamConfiguration
            modelBuilder.Entity<MatchdayTeamConfiguration>().HasKey(key => key.MatchdayTeamConfigurationID);
            modelBuilder.Entity<MatchdayTeamConfiguration>().Property(p => p.DateCreated).IsRequired();
            modelBuilder.Entity<MatchdayTeamConfiguration>().Property(p => p.DateUpdated).IsRequired();
            modelBuilder.Entity<MatchdayTeamConfiguration>().HasOne(b => b.FantasyTeam).WithMany(b => b.MatchdayTeamConfiguration).HasForeignKey(b => b.FantasyTeamID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeamConfiguration>().HasOne(b => b.Matchday).WithMany(b => b.MatchdayTeamConfiguration).HasForeignKey(b => b.MatchdayID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeamConfiguration>().HasOne(b => b.Formation).WithMany(b => b.MatchdayTeamConfiguration).HasForeignKey(b => b.FormationID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeamConfiguration>().HasOne(b => b.Player).WithMany(b => b.MatchdayTeamConfiguration).HasForeignKey(b => b.CaptainID).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MatchdayTeamConfiguration>().HasOne(b => b.MatchdayTeam).WithOne(b => b.MatchdayTeamConfiguration).HasForeignKey<MatchdayTeamConfiguration>(b => b.MatchdayTeamID);
            #endregion













        }

    }
}
