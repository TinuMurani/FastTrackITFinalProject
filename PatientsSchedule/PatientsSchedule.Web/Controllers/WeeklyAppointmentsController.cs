using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientsSchedule.Web.DataOperations;
using PatientsSchedule.Web.Internal;
using PatientsSchedule.Web.Models;
using PatientsSchedule.Web.Singleton;

namespace PatientsSchedule.Web.Controllers
{
    //[Authorize]
    public class WeeklyAppointmentsController : Controller
    {
        private readonly IDbDataAccess _dbDataAccess;
        private readonly IStartupDate _currentDate;

        public WeeklyAppointmentsController(IDbDataAccess dbDataAccess, IStartupDate currentDate)
        {
            _dbDataAccess = dbDataAccess;
            _currentDate = currentDate;
        }
        public IActionResult Index()
        {
            return View(new WeeklyAppointmentsModel(_dbDataAccess, _currentDate.ReferenceDate));
        }

        [HttpPost]
        public IActionResult Index(string navigate)
        {
            if (navigate == "Previous Week")
            {
                _currentDate.ReferenceDate = _currentDate.ReferenceDate.AddDays(-7);
                return View(new WeeklyAppointmentsModel(_dbDataAccess, _currentDate.ReferenceDate));
            }
            else if (navigate == "Next Week")
            {
                _currentDate.ReferenceDate = _currentDate.ReferenceDate.AddDays(7);
                return View(new WeeklyAppointmentsModel(_dbDataAccess, _currentDate.ReferenceDate));
            }

            _currentDate.ReferenceDate = DateTime.Now;
            return View(new WeeklyAppointmentsModel(_dbDataAccess, _currentDate.ReferenceDate));
        }
        public async Task<IActionResult> Create()
        {
            var patientList = await _dbDataAccess.GetAllPatientsAsync();

            ViewBag.ListOfPatients = patientList;
            return View();
        }

        // POST: ContactList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,AppointmentDate,FromHour,ToHour,AppointmentDuration")] AppointmentModel appointment)
        {
            
            if (ModelState.IsValid)
            {
                appointment.AppointmentDate = appointment.AppointmentDate.Replace("-", string.Empty);
                appointment.AppointmentDuration = InternalConverters.GetStringDuration(appointment.FromHour, appointment.ToHour);

                int success = await _dbDataAccess.SaveAppointmentAsync(appointment);

                if (success != 0)
                {
                    _currentDate.ReferenceDate = DateTime.Now;
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ListOfPatients = await _dbDataAccess.GetAllPatientsAsync();
                    ViewBag.ErrorMessage = "Something went wrong while creating appointment list entry, please try again...";
                }
            }
            ViewBag.ListOfPatients = await _dbDataAccess.GetAllPatientsAsync();

            return View(appointment);
        }
    }
}
