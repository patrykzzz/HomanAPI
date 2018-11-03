using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Homan.DAL.Factories
{
    public class HomanContextFactory : IDesignTimeDbContextFactory<HomanContext>
    {
        public HomanContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HomanContext>();
            builder.UseSqlServer(
                "Server=tcp:homan.database.windows.net,1433;Initial Catalog=Homan;Persist Security Info=False;User ID={username};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new HomanContext(builder.Options);
        }
    }
}