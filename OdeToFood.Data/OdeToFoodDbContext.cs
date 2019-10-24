using Microsoft.EntityFrameworkCore;
using VarorLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
   public class OdeToFoodDbContext : DbContext
    {
        //Migration
        public DbSet<VarorModel> VarorModel { get; set; }

        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options)
        {

        }
        

    }
}
