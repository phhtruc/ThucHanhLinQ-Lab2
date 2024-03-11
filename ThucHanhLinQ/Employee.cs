using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanhLinQ
{
    class Employee
    {
        public string name { get; set; }
        public int age { get; set; }
        public double salary { get; set; }
        public DateTime birthday { get; set; }
        public int id { get; set; }
        public int departmentID { get; set; }

        public static List<Employee> getEmployees()
        {
            return new List<Employee>()
            {
                new Employee{id = 1, salary = 10000000, name = "A", departmentID = 1, birthday = DateTime.Parse("2012-11-11")},
                new Employee{id = 2, salary = 20000000, name = "B", departmentID = 2, birthday = DateTime.Parse("2003-11-11")},
                new Employee{id = 3, salary = 30000000, name = "C", departmentID = 3, birthday = DateTime.Parse("2005-11-11")},
                new Employee{id = 4, salary = 15000000, name = "D", departmentID = 4, birthday = DateTime.Parse("2001-11-11")},
                new Employee{id = 5, salary = 70000000, name = "E", departmentID = 5, birthday = DateTime.Parse("2000-11-11")},
            };
        }
    }
}
