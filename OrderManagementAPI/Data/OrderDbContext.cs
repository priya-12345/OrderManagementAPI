using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Data
{
    public class OrderDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public OrderDbContext(DbContextOptions<OrderDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
