using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ProjetNoelAPI.Models
{
    public class NoelDbContextDesign : IDesignTimeDbContextFactory<NoelDbContext>
    {
        public NoelDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NoelDbContext>();

            string connectionString = @"";

            optionsBuilder.UseSqlServer(connectionString);
            return new NoelDbContext(optionsBuilder.Options);
        }
    }
}
