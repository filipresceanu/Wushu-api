using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wushu_api.Models;

namespace Wushu_api.Data
{
    public class DataContext: IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=wushudb;Trusted_Connection=true");
        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Round> Rounds { get; set; }

        public DbSet<AgeCategory> AgeCategories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(m => m.CompetitorFirst)
                .WithMany(p => p.MatchesAsFirstCompetitor)
                .HasForeignKey(m => m.CompetitorFirstId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.CompetitorSecond)
                .WithMany(p => p.MatchesAsSecondCompetitor)
                .HasForeignKey(m => m.CompetitorSecondId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.ParticipantWinner)
                .WithMany(p => p.MatchesAsWinner)
                .HasForeignKey(m => m.ParticipantWinnerId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Name = "Referee", NormalizedName = "REFEREE" },
                    new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" }
                );
        }
       

    }
}
