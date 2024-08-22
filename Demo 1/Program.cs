using Demo.Context;
using Demo.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Session 1
            EntryPointNotFoundException DbContext = new EntryPointNotFoundException();
            //DbContext.Database.EnsureCreated(); not recommended
            #endregion
            #region Session 2
            #region Connection
            //EnterPriseDbContext dbContext = new EnterPriseDbContext();
            //try
            //{
            //    //Crud => Guery Object Model
            //}
            //finally
            //{
            //    //Release||free||Deallocate||close||Dispose unManagedResources
            //    dbContext.Dispose();
            //}
            //Syntax suger=> try finally
            //using (EnterPriseDbContext dbContext1 = new EnterPriseDbContext()) 
            //{

            //}
            //Syntax suger
            //using EnterPriseDbContext dbContext = new EnterPriseDbContext();
            #endregion
            //using EnterPriseDbContext dbContext = new EnterPriseDbContext();
            #region CRUD Operations
            //Employee employee1 = new Employee()
            //{
            //    //EmpId=1; is invalid because the column has identity
            //    EmpName = "yousef",
            //    Age = 22,
            //    Email = "yousefsayed366@gmail.com",
            //    Password = "password",
            //    Phone = "1234567890",
            //    Salary = 10000
            //};
            //Employee employee2 = new Employee()
            //{
            //    EmpName = "mohamed",
            //    Age = 23,
            //    Email = "mohamedadel366@gmail.com",
            //    Password = "password",
            //    Phone = "1234567890",
            //    Salary = 100000
            //};
            #region Insert
            //Console.WriteLine(dbContext.Entry(employee1).State);//Detached
            //Console.WriteLine(dbContext.Entry(employee2).State);//Detached
            //dbContext.Employees.Add(employee1);//add locally
            //dbContext.Employees.Add(employee2);//add locally
            ////dbContext.Set<Employee>().Add(employee2);//دي بنستخدمعا لو مش عاملين سيت اللي موجودة ف الانتربرايزديبيكونتيكست
            ////dbContext.Add(employee1);
            ////dbContext.Entry(employee2).State = EntityState.Added;
            //Console.WriteLine(dbContext.Entry(employee1).State);//Added
            //Console.WriteLine(dbContext.Entry(employee2).State);//Added
            //dbContext.SaveChanges();//Add remote
            //Console.WriteLine(dbContext.Entry(employee1).State);//Unchanged
            //Console.WriteLine(dbContext.Entry(employee2).State);//Unchanged
            ////--------------------------------------
            //Console.WriteLine(employee1.EmpId);
            //Console.WriteLine(employee2.EmpId);
            #endregion
            #region Read/retrive
            //var result = (from e in dbContext.Employees
            //             where e.EmpId == 3
            //             select e).FirstOrDefault();
            //Console.WriteLine(result?.EmpName??"not found");
            #endregion
            #region update
            //var result = (from e in dbContext.Employees
            //              where e.EmpId == 1
            //              select e).FirstOrDefault();
            //Console.WriteLine(dbContext.Entry(result).State);//unchanged
            //result.EmpName = "Aya";//update localy
            //Console.WriteLine(dbContext.Entry(result).State);//modifyed
            //dbContext.SaveChanges();
            #endregion
            #region delete
            //var result = (from e in dbContext.Employees
            //              where e.EmpId == 2
            //              select e).FirstOrDefault();
            //Console.WriteLine(dbContext.Entry(result).State);//
            //dbContext.Employees.Remove(result);//remove localy
            //Console.WriteLine(dbContext.Entry(result).State);//
            //dbContext.SaveChanges();
            #endregion
            #endregion
            #endregion
            #region Session 3
            using EnterPriseDbContext dbContext = new EnterPriseDbContext();
            #region With Out Loading
            //var result = (from emp in dbContext.Employees
            //              where emp.EmpId==1
            //              select emp).FirstOrDefault();
            //Console.WriteLine($"{result?.EmpName??"not found"}--{result?.Department?.Name??"not found"}");
            //by defualt navigational property will not be loadded the department name
            #endregion
            #region Explicit Loading
            //var Eresult = (from emp in dbContext.Employees
            //              where emp.EmpId == 1
            //              select emp).FirstOrDefault();
            //dbContext.Entry(Eresult).Reference(r=>r.Department).Load();
            //Console.WriteLine($"{Eresult?.EmpName ?? "not found"}--{Eresult?.Department?.Name ?? "not found"}");

            //var Dresult = (from dept in dbContext.Departments
            //              where dept.DeptId == 20
            //              select dept).FirstOrDefault();
            //dbContext.Entry(Dresult).Collection(d=>d.Employees).Load();
            //Console.WriteLine($"{Dresult?.Name ?? "not found"}");
            //foreach (var item in Dresult.Employees)
            //{
            //    Console.WriteLine(item.EmpName);
            //}
            #endregion
            #region Eager Loading
            var Eresult = (from emp in dbContext.Employees.Include(e=>e.Department)//.ThenInclude(p=>p.)
                           where emp.EmpId == 1
                           select emp).FirstOrDefault();
            Console.WriteLine($"{Eresult?.EmpName ?? "not found"}--{Eresult?.Department?.Name ?? "not found"}");

            var Dresult = (from dept in dbContext.Departments.Include(e => e.Employees)
                           where dept.DeptId == 20
                           select dept).FirstOrDefault();
            Console.WriteLine($"{Dresult?.Name ?? "not found"}");
            foreach (var item in Dresult.Employees)
            {
                Console.WriteLine(item.EmpName);
            }
            #endregion
            #endregion
        }
    }
}
