using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementApp.DTO
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public decimal? Salary { get; set; }
        public string Dept { get; set; }
        public string Password { get; set; }
    }
}
