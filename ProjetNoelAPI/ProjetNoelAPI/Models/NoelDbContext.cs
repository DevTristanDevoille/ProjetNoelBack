using Microsoft.EntityFrameworkCore;

namespace ProjetNoelAPI.Models
{
    public class NoelDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        public DbSet<Liste>? Listes { get; set; }
        public DbSet<Idea>? Ideas { get; set; }

        public NoelDbContext(DbContextOptions<NoelDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Idea>().HasOne(i => i.Liste).WithMany(l => l.Ideas).HasForeignKey(t => t.IdListe);
            modelBuilder.Entity<User>().HasMany(u => u.Listes);
        }
    }
}
