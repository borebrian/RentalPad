
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using RentalPad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fuela.DBContext
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<Rental_Owners> Rental_owners { get; set; }
   
     
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options) {
        
        }
   
     
        public DbSet<RentalPad.Models.Rentals_reg> Rentals_reg { get; set; }
   
     
        public DbSet<RentalPad.Models.Rooms_reg> Rooms_reg { get; set; }
   
     
        public DbSet<RentalPad.Models.Room_Category> Room_Category { get; set; }
   
     
        public DbSet<RentalPad.Models.Tenants> Tenants { get; set; }
     
    }
}
