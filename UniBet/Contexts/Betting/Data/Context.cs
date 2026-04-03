using Microsoft.EntityFrameworkCore;
using UniBet.Contexts.Billing.DTOs.Entities;
using UniBet.Contexts.Billing.Entities;

namespace UniBet.Contexts.Billing.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(usr => usr.Id);

            modelBuilder.Entity<Game>()
                .HasKey(game => game.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
