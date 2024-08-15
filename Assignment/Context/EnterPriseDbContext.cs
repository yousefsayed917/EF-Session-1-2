using Assignment.Intities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Context
{
    internal class EnterPriseDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = JOO; database = Company; Trusted_connection = true; TrustServerCertificate = True;");
        }
        public DbSet<Employee>Employees { get; set; }
        public DbSet<Department>Departments { get; set; }
        public DbSet<Product>Products { get; set; }
        public DbSet<Project>Projects { get; set; }

    }
}
