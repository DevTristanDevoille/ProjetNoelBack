using Microsoft.EntityFrameworkCore;
using ProjetNoelAPI.Models;

namespace ProjetNoelAPI.DataAccess.DbContextNoel
{
    public class NoelDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Liste>? Listes { get; set; }
        public DbSet<Idea>? Ideas { get; set; }
        public DbSet<Squad>? Squades { get; set; }

        public NoelDbContext(DbContextOptions<NoelDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasMany(u => u.Squades);
            modelBuilder.Entity<User>().HasMany(u => u.Listes).WithOne(l => l.User).HasForeignKey(l => l.IdCreator);
            modelBuilder.Entity<Squad>().HasMany(s => s.Listes).WithOne(l => l.Squad).HasForeignKey(l => l.IdSquad);
            modelBuilder.Entity<Liste>().HasMany(l => l.Ideas).WithOne(i => i.Liste).HasForeignKey(i => i.IdListe);

        }
    }
}
