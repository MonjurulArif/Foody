using Foody.Models;
using Microsoft.EntityFrameworkCore;

namespace Foody.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Receiving DbContextOptions on ApplicationDbContext as options and pass to base class of DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
    }
}
