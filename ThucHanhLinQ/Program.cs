using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanhLinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = Employee.getEmployees();

            List<Department> departments = Department.getDepartments();

            var maxSalary = employees.Max(emp => emp.salary);

            Console.WriteLine($"Max salary: {maxSalary}");
            Console.WriteLine("--------------------------");

            var minSalary = employees.Min(emp => emp.salary);

            Console.WriteLine($"Min salary: {minSalary}");
            Console.WriteLine("--------------------------");

            var averageSalary = employees.Average(emp => emp.salary);

            Console.WriteLine($"Average salary: {averageSalary}");
            Console.WriteLine("--------------------------");

            var innerJoin = departments.Join(employees,
                                             d => d.id,
                                             e => e.departmentID,
                                             (department, employee) => new
                                             {
                                                 DepartmentName = department.name,
                                                 EmployeenName = employee.name
                                             });

            Console.WriteLine("InnerJoin");
            foreach (var item in innerJoin)
            {
                Console.WriteLine(item.EmployeenName +" - "+ item.DepartmentName);
            }

            var leftJoin = departments.GroupJoin(employees,
                                                d => d.id,
                                                e => e.departmentID,
                                                (department, employee) => new
                                                {
                                                    DepartmentName = department.name,
                                                    Employee = employees.DefaultIfEmpty()
                                                })
                                                .SelectMany(x => x.Employee.Select(y => new
                                                {
                                                    DepartmentName = x.DepartmentName,
                                                    EmployeeName = y != null ? y.name : "Khong tim thay"
                                                }));

            Console.WriteLine("--------------------------");
            Console.WriteLine("LeftJoin");
            foreach (var item in leftJoin)
            {
                Console.WriteLine(item.EmployeeName + " - " + item.DepartmentName);
            }


            Console.WriteLine("--------------------------");
            Console.WriteLine("RightJoin");
            var rightJoin = employees.GroupJoin(departments,
                                     e => e.departmentID,
                                     d => d.id,
                                     (employee, departmentGroup) => new
                                     {
                                         EmployeeName = employee.name,
                                         Departments = departmentGroup.DefaultIfEmpty()
                                     })
                           .SelectMany(x => x.Departments.Select(y => new
                           {
                               EmployeeName = x.EmployeeName,
                               DepartmentName = y != null ? y.name : "Khong tim thay"
                           }));

            foreach (var item in rightJoin)
            {
                Console.WriteLine(item.EmployeeName + " - " + item.DepartmentName);
            }

            var maxAge = employees.Max(e => (DateTime.Now - e.birthday).Days/365);

            Console.WriteLine("--------------------------");
            Console.WriteLine($"Max age: {maxAge} years");
            
            var minAge = employees.Min(e => (DateTime.Now - e.birthday).Days/356);

            Console.WriteLine("--------------------------");
            Console.WriteLine($"Min age: {minAge} years");

            Console.ReadKey();
        }
    }
}
