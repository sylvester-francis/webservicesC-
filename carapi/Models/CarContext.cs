using Microsoft.EntityFrameworkCore;

namespace carapi.Models
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public DbSet<CarItems> CarItems { get; set; }
    }
}