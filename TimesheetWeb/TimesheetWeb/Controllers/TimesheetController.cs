using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimesheetWeb.Models;

namespace TimesheetWeb.Controllers
{
    public class TimesheetController : Controller
    {
        private IEmployeeTimesheetRepository employeeTimesheetRepository;

        public TimesheetController()
        {
            this.employeeTimesheetRepository = new EmployeeTimesheetRepository();
        }

        public TimesheetController(IEmployeeTimesheetRepository employeeTimesheetRepository)
        {
            this.employeeTimesheetRepository = employeeTimesheetRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Timesheet()
        {
            var empTimesheets = employeeTimesheetRepository.GetEmpTimesheet();
            return Json(new { timesheetData = empTimesheets });
        }

    }
}