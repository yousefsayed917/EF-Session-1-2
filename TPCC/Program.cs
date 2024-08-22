using TPCC.Context;
using TPCC.Entities;

namespace TPCC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using EnterPriseDbContext dbContext = new EnterPriseDbContext();
            #region TPCC
            //FullTimeEmployee fullTimeEmployee = new FullTimeEmployee()
            //{
            //    Name = "yousef",
            //    Age = 22,
            //    Address = "Cairo",
            //    Salary = 10000,
            //    StartDate = DateTime.Now,
            //};
            //PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            //{
            //    Name = "mohamed",
            //    Age = 23,
            //    Address = "Cairo",
            //    CountOfHour = 20,
            //    HourRate = 200,
            //};
            ////dbContext.FullTimeEmployees.Add(fullTimeEmployee);//Add Localy
            ////dbContext.partTimeEmployees.Add(partTimeEmployee);//Add Localy
            ////dbContext.SaveChanges();//add remotly
            ////Console.WriteLine(dbContext.Entry(fullTimeEmployee).State);

            //var result = from fte in dbContext.FullTimeEmployees
            //             select fte;
            ////var result = from pte in dbContext.partTimeEmployees
            ////             select pte;
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"{item.Name}-{item.Salary}");
            //    //Console.WriteLine($"{item.Name}-{item.CountOfHour}");

            //}

            #endregion
            #region TPH
            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee()
            {
                Name = "yousef",
                Age = 22,
                Address = "Cairo",
                Salary = 10000,
                StartDate = DateTime.Now,
            };
            PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            {
                Name = "ahmed",
                Age = 24,
                Address = "Cairo",
                CountOfHour = 30,
                HourRate = 200
            };
            //dbContext.Employees.Add(fullTimeEmployee);
            //dbContext.Employees.Add(partTimeEmployee);
            //dbContext.SaveChanges();
            var Femployee = from fn in dbContext.Employees
                            select fn;
            var pemployee = from pn in dbContext.Employees
                            select pn;
            foreach (var item in Femployee.OfType<FullTimeEmployee>())
            {
                Console.WriteLine($"{item.Name}--{item.Salary}");
            }
            foreach (var item in pemployee.OfType<PartTimeEmployee>())
            {
                Console.WriteLine($"{item.Name}--{item.CountOfHour}");
            }
            #endregion
        }
    }
}
