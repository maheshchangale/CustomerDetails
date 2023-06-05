using Customer.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Data
{
    public class CustomerContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public CustomerContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<customer_details> customer_details { get; set; }
        public DbSet<customer_login> customer_login { get; set; }
    }
}
