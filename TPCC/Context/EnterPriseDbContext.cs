using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPCC.Entities;

namespace TPCC.Context
{
    internal class EnterPriseDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = JOO;Database = TPCC;Trusted_Connection = true;TrustServerCertificate = True;");
        }
        //public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        //public DbSet<PartTimeEmployee> partTimeEmployees { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TPH
            //Fluent api
            //TPH map fulltimeemployee and parttimeemployee to one table employee
            //adding new column Nvarchar named discriminator
            //مشكلتها الوحيدة انها بيبقي فيها نلااات كتيير 
            modelBuilder.Entity<FullTimeEmployee>().HasBaseType<Employee>();
            modelBuilder.Entity<PartTimeEmployee>().HasBaseType<Employee>();
            #endregion
        }
    }
}
