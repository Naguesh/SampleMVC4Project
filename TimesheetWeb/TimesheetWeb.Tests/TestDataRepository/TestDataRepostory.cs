using System;
using System.Collections.Generic;
using TimesheetWeb.Models;

namespace TimesheetWeb.Tests
{
    public class EmployeeTimesheetTestRepository : IEmployeeTimesheetRepository
    {
        public IList<EmployeeTimesheetViewModel> GetEmpTimesheet()
        {
            List<EmployeeTimesheetViewModel> empTimesheets = new List<EmployeeTimesheetViewModel>();
            List<TimesheetViewModel> e1timesheet = new List<TimesheetViewModel>();
            List<TimesheetViewModel> e2timesheet = new List<TimesheetViewModel>();

            EmployeeTimesheetViewModel e1 = new EmployeeTimesheetViewModel { Id = 1, FirstName = "LionelTest", LastName = "MessiTest", ProjectName = "Teleshop", JobTyp = "Part Time", Image = "0px 0px", Timesheet = e1timesheet };
            EmployeeTimesheetViewModel e2 = new EmployeeTimesheetViewModel { Id = 2, FirstName = "CristianoTest", LastName = "RonaldoTest", ProjectName = "eComm", JobTyp = "Full Time", Image = "0px -196px", Timesheet = e2timesheet };

            empTimesheets.Add(e1);
            empTimesheets.Add(e2);

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

            return empTimesheets;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

  
}

