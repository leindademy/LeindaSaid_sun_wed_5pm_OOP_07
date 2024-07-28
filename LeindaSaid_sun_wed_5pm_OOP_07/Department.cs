using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeindaSaid_sun_wed_5pm_OOP_07
{
    internal class Department {
        public int DeptID { get; set; }
        public string DeptName { get; set; }

        public string Location { get; set; }


        List<Employee> Staff = new List <Employee> ();

        public void AddStaff(Employee E)
        {
            Staff.Add(E);
        }

        public void RemoveStaff (object sender, EmployeeLayOffEventArgs e)
        {
            if (sender is Employee)
            {
                Employee emp = (Employee)sender;
                Console.WriteLine("Staff with ID " + " is being laid off due to: " + e.Cause); 
            }
        }
    }
}
    

