using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entities
{
    public class Department
    {
        public int DeptId { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfCreation { get; set; }
        [InverseProperty("Department")]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();//navigation proberty => من ناحية ال m 
    }
}
