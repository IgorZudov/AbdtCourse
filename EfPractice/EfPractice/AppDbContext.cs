using EfPractice.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfPractice
{
    public class AppDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(a =>
            {
                a.HasOne(x => x.Card)
                    .WithOne();
                a.Property(x => x.Number).HasMaxLength(30);
                a.HasKey(x => x.Id);
            });
            
            modelBuilder.Entity<Card>(a =>
            {
                a.Property(x => x.Number).HasMaxLength(20);
                a.HasKey(x => x.Id);
            });
        }
    }
}