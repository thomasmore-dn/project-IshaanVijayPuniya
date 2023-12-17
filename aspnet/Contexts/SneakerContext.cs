using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet.Contexts
{
    //A DbContext instance represents a combination of the Unit Of Work and Repository patterns such that it can be used to query from a database 
    //and group together changes that will then be written back to the store as a unit. DbContext is conceptually similar to ObjectContext.
    public class SneakerContext : DbContext
    {
        public SneakerContext(DbContextOptions<SneakerContext> opt) : base(opt)
        {
            
        }
        
        public DbSet<Sneaker> Sneakers {get; set;}
    }
}