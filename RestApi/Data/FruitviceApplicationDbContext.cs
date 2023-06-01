using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.DataLayer
{
    public class FruitviceApplicationDbContext : DbContext
    {
        public FruitviceApplicationDbContext(DbContextOptions<FruitviceApplicationDbContext> options) : base(options) { } //get the connectionstring and pass to base class DBcontext
        public DbSet<fruit> Fruit { get; set; }
        public DbSet<nutrition> Nutrition { get; set; }
    }
}
