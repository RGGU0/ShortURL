using Microsoft.EntityFrameworkCore;
using ShortURL.Models;

namespace ShortURL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        {
            
        }
        
        public DbSet<Links> Links { get; set; }
    }
}
