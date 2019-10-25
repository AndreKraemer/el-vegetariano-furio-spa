using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ElVegetarianoFurio.Models
{
    public class VegiContext : DbContext
    {
        public VegiContext(DbContextOptions<VegiContext> options): base(options)
        {
            
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
