using Microsoft.EntityFrameworkCore;

namespace WebCalculator1.Entity
{
  
    public class Context : DbContext
    {
        public Context()
        {
            
        }

        public Context(DbContextOptions options) : base(options)
        {


        }

        public DbSet<Action> Actions { get; set; }

    }
}