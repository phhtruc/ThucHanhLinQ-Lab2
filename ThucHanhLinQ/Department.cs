using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanhLinQ
{
    class Department
    {
        public int id { get; set; }
        public string name { get; set; }
        public static List<Department> getDepartments() 
        {
            return new List<Department>()
            {
                new Department {id = 1, name ="IT" },
                new Department {id = 2, name ="HR" },
                new Department {id = 3, name ="Marketing" }
            };
        }

    }
}
