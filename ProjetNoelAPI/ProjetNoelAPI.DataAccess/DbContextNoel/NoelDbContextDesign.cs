using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ProjetNoelAPI.DataAccess.DbContextNoel
{
    public class NoelDbContextDesign : IDesignTimeDbContextFactory<NoelDbContext>
    {
        public NoelDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NoelDbContext>();

            string connectionString = "Server=tcp:projetnoelsql.database.windows.net,1433;Initial Catalog=ProjetNoelDb;Persist Security Info=False;User ID=superadmin;Password=Azerty@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            optionsBuilder.UseSqlServer(connectionString);
            return new NoelDbContext(optionsBuilder.Options);
        }
    }
}
