using FoodieOnline.Interface;
using Microsoft.EntityFrameworkCore;

namespace FoodieOnline.Context
{
    public class FoodieContext:DbContext
    {
        public FoodieContext(DbContextOptions<FoodieContext> options):base(options)
        {
            
        }
        public DbSet<RegisterModel> Register { get; set; }
        public DbSet<Catagoery> Catagoery { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
