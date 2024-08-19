using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPCC.Entities
{
    internal class PartTimeEmployee :Employee
    {
        public int CountOfHour { get; set; }
        public decimal HourRate { get; set; }
    }
}
