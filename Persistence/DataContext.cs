using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    /*
        Uses EntityFramework core to create migrations and push to the database as well as create the database.
    */
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
    }
}
