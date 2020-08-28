using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientsSchedule.Web.DataOperations;
using PatientsSchedule.Web.Models;

namespace PatientsSchedule.Web.Controllers
{
    [Authorize]
    public class WeeklyAppointmentsController : Controller
    {
        private readonly IDbDataAccess _dbDataAccess;

        public WeeklyAppointmentsController(IDbDataAccess dbDataAccess)
        {
            _dbDataAccess = dbDataAccess;
        }
        public IActionResult Index()
        {
            return View(new WeeklyAppointmentsModel(_dbDataAccess, DateTime.Now));
        }
    }
}
