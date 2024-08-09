using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using VerticalCQRS.Entities;

namespace VerticalCQRS.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
            
        }
        public DbSet<Article> Articles { get; set; }
    }
}
