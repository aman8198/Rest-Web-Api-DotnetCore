using Microsoft.EntityFrameworkCore;
using RestCorewebapi.Models;

namespace RestCorewebapi.Data
{
    public class TechnologyContext : DbContext
    {
        public TechnologyContext(DbContextOptions<TechnologyContext> opt) : base(opt)
        {
            
        }
         public DbSet<technologies> Technology{get; set;}
    } 
}