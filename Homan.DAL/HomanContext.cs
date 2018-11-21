using Homan.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homan.DAL
{
    public class HomanContext : DbContext
    {
        public HomanContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInHomeSpace>()
                .HasKey(table => new
                {
                    table.HomeSpaceId,
                    table.UserId
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<HomeSpace> HomeSpaces { get; set; }
        public DbSet<HomeSpaceItem> HomeSpaceItems { get; set; }
        public DbSet<HomeSpaceItemList> HomeSpaceItemLists { get; set; }
        public DbSet<UserInHomeSpace> UserInHomeSpaces { get; set; }
    }
}
