using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimesheetWeb.Models
{
    public class EmployeeTimesheetRepository : IEmployeeTimesheetRepository
    {

        public IList<EmployeeTimesheetViewModel> GetEmpTimesheet()
        {
            List<EmployeeTimesheetViewModel> empTimesheets = new List<EmployeeTimesheetViewModel>();
            List<TimesheetViewModel> e1timesheet = new List<TimesheetViewModel>();
            List<TimesheetViewModel> e2timesheet = new List<TimesheetViewModel>();
            List<TimesheetViewModel> e3timesheet = new List<TimesheetViewModel>();

            EmployeeTimesheetViewModel e1 = new EmployeeTimesheetViewModel { Id = 1, FirstName = "Lionel", LastName = "Messi", ProjectName = "Teleshop", JobTyp = "Part Time", Image = "0px 0px", Timesheet = e1timesheet };
            EmployeeTimesheetViewModel e2 = new EmployeeTimesheetViewModel { Id = 2, FirstName = "Cristiano", LastName = "Ronaldo", ProjectName = "eComm", JobTyp = "Full Time", Image = "0px -196px", Timesheet = e2timesheet };
            EmployeeTimesheetViewModel e3 = new EmployeeTimesheetViewModel { Id = 3, FirstName = "Neymar", LastName = "da Silva Santo", ProjectName = "MobiTel", JobTyp = "Part Time", Image = "0px -392px", Timesheet = e3timesheet };

            empTimesheets.Add(e1);
            empTimesheets.Add(e2);
            empTimesheets.Add(e3);

            e1timesheet.Add(new TimesheetViewModel { DayOfWeek = "Monday", ExpectedHours = 9, ActualHours = 10 });
            e1timesheet.Add(new TimesheetViewModel { DayOfWeek = "Tuesday", ExpectedHours = 11, ActualHours = 10 });
            e1timesheet.Add(new TimesheetViewModel { DayOfWeek = "Wednesday", ExpectedHours = 9, ActualHours = 10 });
            e1timesheet.Add(new TimesheetViewModel { DayOfWeek = "Thursday", ExpectedHours = 12, ActualHours = 10 });
            e1timesheet.Add(new TimesheetViewModel { DayOfWeek = "Friday", ExpectedHours = 8, ActualHours = 10 });


            e2timesheet.Add(new TimesheetViewModel { DayOfWeek = "Monday", ExpectedHours = 10, ActualHours = 10 });
            e2timesheet.Add(new TimesheetViewModel { DayOfWeek = "Tuesday", ExpectedHours = 12, ActualHours = 10 });
            e2timesheet.Add(new TimesheetViewModel { DayOfWeek = "Wednesday", ExpectedHours = 10, ActualHours = 8 });
            e2timesheet.Add(new TimesheetViewModel { DayOfWeek = "Thursday", ExpectedHours = 9, ActualHours = 8 });
            e2timesheet.Add(new TimesheetViewModel { DayOfWeek = "Friday", ExpectedHours = 9, ActualHours = 10 });

            e3timesheet.Add(new TimesheetViewModel { DayOfWeek = "Monday", ExpectedHours = 9, ActualHours = 12 });
            e3timesheet.Add(new TimesheetViewModel { DayOfWeek = "Tuesday", ExpectedHours = 8, ActualHours = 10 });
            e3timesheet.Add(new TimesheetViewModel { DayOfWeek = "Wednesday", ExpectedHours = 10, ActualHours = 12 });
            e3timesheet.Add(new TimesheetViewModel { DayOfWeek = "Thursday", ExpectedHours = 9, ActualHours = 10 });
            e3timesheet.Add(new TimesheetViewModel { DayOfWeek = "Friday", ExpectedHours = 12, ActualHours = 10 });

            return empTimesheets;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public interface IEmployeeTimesheetRepository : IDisposable
    {
        IList<EmployeeTimesheetViewModel> GetEmpTimesheet();
    }

    public class EmployeeTimesheetViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProjectName { get; set; }
        public string JobTyp { get; set; }
        public string Image { get; set; }
        public List<TimesheetViewModel> Timesheet { get; set; }

    }

    public class TimesheetViewModel
    {
        public string Id { get; set; }
        public string DayOfWeek { get; set; }
        public int ExpectedHours { get; set; }
        public int ActualHours { get; set; }
    }

}

