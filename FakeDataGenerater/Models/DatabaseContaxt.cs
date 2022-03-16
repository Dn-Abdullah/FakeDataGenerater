using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace FakeDataGenerater.Models
{
    public class DatabaseContaxt : IdentityDbContext
    
    {
        public DatabaseContaxt(DbContextOptions<DatabaseContaxt> options) :
           base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //}
        public DbSet<ProductModel> ProductModels { get; set; }
    }
}
