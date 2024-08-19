using TPCC.Context;
using TPCC.Entities;

namespace TPCC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using EnterPriseDbContext dbContext = new EnterPriseDbContext();
            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee()
            {
                Name = "yousef",
                Age = 22,
                Address = "Cairo",
                Salary = 10000,
                StartDate=DateTime.Now,
            };
            PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            {
                Name = "mohamed",
                Age = 23,
                Address = "Cairo",
                CountOfHour = 20,
                HourRate = 200,
            };
            //dbContext.FullTimeEmployees.Add(fullTimeEmployee);//Add Localy
            //dbContext.partTimeEmployees.Add(partTimeEmployee);//Add Localy
            //dbContext.SaveChanges();//add remotly
            //Console.WriteLine(dbContext.Entry(fullTimeEmployee).State);

            var result = from fte in dbContext.FullTimeEmployees
                         select fte;
            //var result = from pte in dbContext.partTimeEmployees
            //             select pte;
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name}-{item.Salary}");
                //Console.WriteLine($"{item.Name}-{item.CountOfHour}");

            }

        }
    }
}
