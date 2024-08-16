using Demo.Configration;
using Demo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Context
{
    //DbContext is a container of database deal with database 
    //App can have more than one DbContext 
    internal class EnterPriseDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data source =JOO; Initial Catalog = Enterprise; UserId = yousef; Password = 123;");
            optionsBuilder.UseSqlServer("Server = JOO;Database = Enterprise;Trusted_Connection = true;TrustServerCertificate = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(p => p.EmpName).HasDefaultValue("test").IsRequired(false);
            //------------------------------------------------------------------------------
            //modelBuilder.Entity<Department>().ToTable("Departments");//مش بنستخدمها دلوقتي -- بنستخدمها لما نيجي نعمل فيو
            #region DepartmentConfigrations
            //modelBuilder.Entity<Department>()
            //    .HasKey(p => p.DeptId);//هي دي اللي بنستخدمها 
            //                           //.HasKey("DeptId")مش بنستخدمها علي اي غلط ف الاسم هيبوظ الدنيا 
            //                           //.HasKey(nameof(Department.DeptId)
            //modelBuilder.Entity<Department>().Property(p => p.DeptId).UseIdentityColumn(10, 10);
            //modelBuilder.Entity<Department>().Property(p => p.Name).HasColumnName("DeptName")
            //            .HasColumnType("Varchar").HasMaxLength(50);
            //-----------------------------------
            //EFcore 3.1 Feature//ممكن نكتبهم كدا
            //modelBuilder.Entity<Department>(d =>
            //{
            //    d.HasKey(p => p.DeptId);
            //    d.Property(p => p.DeptId).UseIdentityColumn(10, 10);
            //    d.Property(p => p.Name).HasColumnName("DeptName")
            //                .HasColumnType("Varchar").HasMaxLength(50);
            //});
            #endregion
            modelBuilder.ApplyConfiguration(new DepartmentConfigration());//كدا بنستخدم الطريقة الربعة اللي هي تنظيم لل fluent api
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
