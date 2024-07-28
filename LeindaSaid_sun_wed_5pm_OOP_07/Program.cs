namespace LeindaSaid_sun_wed_5pm_OOP_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee EmpName = new Employee();
            EmpName.BirthDate = DateTime.Now;
            EmpName.VacationStock = 40;
            bool isRequestVacation = EmpName.RequestVacation(DateTime.Now, DateTime.Now+TimeSpan.FromDays(25));
            if (isRequestVacation)
            {
                Console.WriteLine("Yes");

            }
            else
            {
                Console.WriteLine("No");
            }
            EmpName.EmployeeLayOff += LayOfCause;
            EmpName.EndOfYearOperation();

            Department Dept = new Department();
            Dept.DeptID = 1;
            Dept.DeptName = "java";
            Dept.Location="London";
            Dept.AddStaff(EmpName);
        }
        private static void LayOfCause(object sender, EmployeeLayOffEventArgs e)
        {
            Console.WriteLine($"Cause: {e.Cause}");
        }

    }
}
