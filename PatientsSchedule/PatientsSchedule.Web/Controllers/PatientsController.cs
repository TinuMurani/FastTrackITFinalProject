using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PatientsSchedule.Library.DataAccess;
using PatientsSchedule.Web.Models;

namespace PatientsSchedule.Web.Controllers
{
    //[Authorize]
    public class PatientsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly SqlDataAccess _sql;

        public PatientsController(IConfiguration configuration)
        {
            _configuration = configuration;
            _sql = new SqlDataAccess(_configuration);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _sql.LoadData<PatientModel, dynamic>("spPatients_GetAll", new { }));
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactList/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Address,PhoneNumber,Email")] PatientModel pacient)
        {
            if (ModelState.IsValid)
            {
                int success = await _sql.SaveData<PatientModel, dynamic>("spPatients_Insert",
                    new
                    {
                        pacient.FirstName,
                        pacient.LastName,
                        pacient.Address,
                        pacient.PhoneNumber,
                        pacient.Email
                    });

                if (success != 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = "Something went wrong while creating patient list entry, please try again...";
                }
            }

            return View(pacient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _sql.LoadData<PatientModel, dynamic>("spPatients_GetById", new { Id = id.Value });

            if (pacient.FirstOrDefault() == null)
            {
                return NotFound();
            }

            return View(pacient.FirstOrDefault());
        }

        // POST: ContactList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,PhoneNumber,Email")] PatientModel pacient)
        {
            if (id != pacient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var succes = await _sql.SaveData<PatientModel, dynamic>("spPatients_Update",
                        new
                        {
                            pacient.Id,
                            pacient.FirstName,
                            pacient.LastName,
                            pacient.Address,
                            pacient.PhoneNumber,
                            pacient.Email
                        });

                    if (succes != 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Something went wrong while updating patient list entry, please try again...";
                    }
                }
                catch (SqlException)
                {
                    var entry = await _sql.LoadData<PatientModel, dynamic>("spPatients_GetById", new { pacient.Id });

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

            return View(pacient);
        }

        // GET: PatientsList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _sql.LoadData<PatientModel, dynamic>("spPatients_GetById", new { Id = id.Value });

            if (pacient.FirstOrDefault() == null)
            {
                return NotFound();
            }

            return View(pacient.FirstOrDefault());
        }

        // GET: PatientList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var patient = await _sql.LoadData<PatientModel, dynamic>("spPatients_GetById", new { Id = id.Value });

            if (patient.FirstOrDefault() is null)
            {
                return NotFound();
            }

            return View(patient.FirstOrDefault());
        }

        // POST: PatientList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var succes = await _sql.SaveData<PatientModel, dynamic>("spPatients_DeleteById", new { Id = id });

            if (succes != 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
