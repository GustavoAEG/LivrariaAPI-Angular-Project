using Microsoft.EntityFrameworkCore;

namespace LivrariaAPIs.Model
{
    public class ToDbContext : DbContext
    {
        public ToDbContext(DbContextOptions<ToDbContext> options) : base(options)
        { 
        
        
        
        
        }

        public DbSet<Livro> todoProducts { get; set; }
    }
}
