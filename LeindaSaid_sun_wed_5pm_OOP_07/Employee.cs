using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeindaSaid_sun_wed_5pm_OOP_07
{
    public enum LayOffCause
    {
        Illness,
        Retirement
    }

    public class EmployeeLayOffEventArgs
    {
        public LayOffCause Cause { get; set; }
    }

    public class Employee
    {
        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

        protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            throw new NotImplementedException();
        }

        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        private int _vacationStock;
        public int VacationStock
        {
            get { return _vacationStock; }
            set { _vacationStock = value; }
        }

        public bool IsVacationStockWithinRange(int vacationStock)
        {
            return vacationStock <= this.VacationStock;
        }

        public bool RequestVacation(DateTime from, DateTime to)
        {
            // Number of vacation days required
            int vacationDaysRequested = (to - from).Days;

            // Check if the vacation days requested are within the vacation stock range
            if (IsVacationStockWithinRange(VacationStock) && vacationDaysRequested <= VacationStock)
            {
                VacationStock -= vacationDaysRequested; // Deduct the vacation days from the vacation stock

                return true; // Consent
            }
            else
            {
                return false; // rejection
            }
        }

        public void EndOfYearOperation()
        {
            // Check if the employee is over 60 years old based on birthdate
            if ((DateTime.Now - this.BirthDate).Days > 60 * 365) // 60 years
            {
                if (this.EmployeeLayOff != null)
                {
                    EmployeeLayOffEventArgs e = new EmployeeLayOffEventArgs();
                    e.Cause = LayOffCause.Retirement;
                    this.OnEmployeeLayOff(e);
                }
            }
        }
    }
}