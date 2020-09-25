using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PatientsSchedule.Repositories.Patients;
using PatientsSchedule.Web.Internal;
using PatientsSchedule.Web.Models;

namespace PatientsSchedule.Web.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private readonly IDapperPatientRepository _patientRepository;

        public PatientsController(IDapperPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var patients = PatientConverter.ListForFrontEnd(await _patientRepository.GetAllPatientsAsync());

                return View(patients);
            }
            catch (SqlException ex)
            {
                ViewBag.ErrorMessage = $"Error: { ex.Message }";
            }

            return View();
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
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Address,PhoneNumber,Email")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                Core.Models.Patient input = PatientConverter.PatientForDb(patient);

                try
                {
                    int success = await _patientRepository.SavePatientAsync(input);

                    if (success != 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = $"Error: { ex.Message }";
                }
            }

            return View(patient);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var input = await _patientRepository.GetPatientByIdAsync(id.Value);

            var patient = PatientConverter.PatientForFrontEnd(input);

            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: ContactList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,PhoneNumber,Email")] Patient patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Core.Models.Patient input = PatientConverter.PatientForDb(patient);

                    var succes = await _patientRepository.UpdatePatientAsync(input);

                    if (succes != 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Something went wrong while updating patient list entry, please try again...";
                    }
                }
                catch (SqlException ex)
                {
                    var entry = await _patientRepository.GetPatientByIdAsync(patient.Id);

                    if (entry is null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        ViewBag.ErrorMessage = $"Error: { ex.Message }";
                    }
                }
            }

            return View(patient);
        }

        // GET: PatientsList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var input = await _patientRepository.GetPatientByIdAsync(id.Value);

            var patient = PatientConverter.PatientForFrontEnd(input);

            if (patient is null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // GET: PatientList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var input = await _patientRepository.GetPatientByIdAsync(id.Value);

            var patient = PatientConverter.PatientForFrontEnd(input);

            if (patient is null)
            {
                return NotFound();
            }

            return View(patient);
        }

        // POST: PatientList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var succes = await _patientRepository.DeletePatientAsync(id);

                if (succes != 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (SqlException ex)
            {
                ViewBag.ErrorMessage = $"The current record could not be deleted. Reason: { ex.Message }";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
