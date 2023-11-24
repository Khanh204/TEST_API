using Microsoft.EntityFrameworkCore;

namespace TEST_API.Entities
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }
    }
}
