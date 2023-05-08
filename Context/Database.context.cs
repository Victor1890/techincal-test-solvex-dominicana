using Microsoft.EntityFrameworkCore;
using solvex_dominicana.Models;

namespace solvex_dominicana.Context
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<ProductModel> Product { get; set; }
        public DbSet<BrandModel> Brand { get; set; }
        public DbSet<SuperMarketModel> SuperMarket { get; set; }
        public DbSet<BrandProductModel> BrandProductRelaction { get; set; }
        public DbSet<SuperMarketBrandModel> SuperMarketBrandRelaction { get; set; }
    }
}
