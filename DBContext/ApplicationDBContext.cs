using Fuela.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fuela.DBContext
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<Station_Owners> Station_owners { get; set; }
        public DbSet<Station_reg> Station_reg { get; set; }
        public string ConnectionString { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options) {
        
        }
        public ApplicationDBContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
