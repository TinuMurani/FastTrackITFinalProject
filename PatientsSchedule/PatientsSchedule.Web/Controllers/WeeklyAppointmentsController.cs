using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatientsSchedule.Web.DataOperations;
using PatientsSchedule.Web.Internal;
using PatientsSchedule.Web.Models;
using PatientsSchedule.Web.Singleton;
using Microsoft.AspNetCore.Authorization;

namespace PatientsSchedule.Web.Controllers
{
    [Authorize]
    public class WeeklyAppointmentsController : Controller
    {
        private readonly IDbDataAccess _dbDataAccess;
        private readonly IStartupDate _currentDate;
        HoursModel hours = new HoursModel();

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
            if (navigate == "Saptamana precedenta")
            {
                _currentDate.ReferenceDate = _currentDate.ReferenceDate.AddDays(-7);
                return View(new WeeklyAppointmentsModel(_dbDataAccess, _currentDate.ReferenceDate));
            }
            else if (navigate == "Saptamana urmatoare")
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

            ViewBag.ListOfHours = hours.Hours;
            ViewBag.ListOfMinutes = hours.Minutes;

            return View();
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientId,AppointmentDate,FromHour,FromMinute,ToHour,ToMinute,AppointmentDuration")] AppointmentModel appointment)
        {
            if (ModelState.IsValid)
            {
                appointment = AppointmentOperations.PrepareForDatabase(appointment);

                int success = await _dbDataAccess.SaveAppointmentAsync(appointment);

                if (success != 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ListOfPatients = await _dbDataAccess.GetAllPatientsAsync();
                    ViewBag.ListOfHours = hours.Hours;
                    ViewBag.ListOfMinutes = hours.Minutes;

                    ViewBag.ErrorMessage = "Something went wrong while creating appointment list entry, please try again...";
                }
            }

            ViewBag.ListOfPatients = await _dbDataAccess.GetAllPatientsAsync();
            ViewBag.ListOfHours = hours.Hours;
            ViewBag.ListOfMinutes = hours.Minutes;

            return View(appointment);
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _dbDataAccess.GetAppointmentByIdAsync(id.Value);

            if (appointment == null)
            {
                return NotFound();
            }

            var patientList = await _dbDataAccess.GetAllPatientsAsync();
            ViewBag.ListOfPatients = patientList;

            ViewBag.ListOfHours = hours.Hours;
            ViewBag.ListOfMinutes = hours.Minutes;

            appointment = AppointmentOperations.PrepareForFrontEnd(appointment);

            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,AppointmentDate,FromHour,FromMinute,ToHour,ToMinute,AppointmentDuration")] AppointmentModel appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    appointment = AppointmentOperations.PrepareForDatabase(appointment);

                    var succes = await _dbDataAccess.UpdateAppointmentAsync(appointment);

                    if (succes != 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.ListOfPatients = await _dbDataAccess.GetAllPatientsAsync();
                        ViewBag.ListOfHours = hours.Hours;
                        ViewBag.ListOfMinutes = hours.Minutes;

                        ViewBag.ErrorMessage = "Something went wrong while updating patient list entry, please try again...";
                    }
                }
                catch (SqlException)
                {
                    var entry = await _dbDataAccess.GetAppointmentByIdAsync(appointment.Id);

                    if (entry is null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewBag.ListOfPatients = await _dbDataAccess.GetAllPatientsAsync();
            ViewBag.ListOfHours = hours.Hours;
            ViewBag.ListOfMinutes = hours.Minutes;

            return View(appointment);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var appointment = await _dbDataAccess.GetAppointmentByIdAsync(id.Value);

            if (appointment is null)
            {
                return NotFound();
            }

            appointment = AppointmentOperations.PrepareForFrontEndFormattedDate(appointment);

            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var succes = await _dbDataAccess.DeleteAppointmentAsync(id);

            if (succes == 0)
            {
                return RedirectToAction(nameof(Delete), new { id });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
