using FoodyWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace FoodyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Receiving DbContextOptions on ApplicationDbContext as options and pass to base class of DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Category> Category { get; set; }
    }
}
