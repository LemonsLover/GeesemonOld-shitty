using Geesemon.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Geesemon.Database
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
