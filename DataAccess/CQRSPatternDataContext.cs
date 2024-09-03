using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{

    public class CQRSPatternDataContext : DbContext
    {

        private readonly IConfiguration _configuration;

        public CQRSPatternDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        
        public  DbSet<Product> Product { get; set; }

    }

}