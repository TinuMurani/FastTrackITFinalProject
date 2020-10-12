using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientsSchedule.Repositories.Appointments;
using PatientsSchedule.Repositories.Interventions;
using PatientsSchedule.Repositories.Patients;
using PatientsSchedule.Repositories.Teeth;
using PatientsSchedule.Web.Data;
using PatientsSchedule.Web.Internal;
using PatientsSchedule.Web.Models;

namespace PatientsSchedule.Web.Controllers
{
    public class InterventionsController : Controller
    {
        private readonly IDapperInterventionRepository _interventionRepository;
        private readonly IDapperToothRepository _toothRepository;
        private readonly IDapperPatientRepository _patientRepository;
        private readonly IDapperAppointmentRepository _appointmentRepository;

        public InterventionsController(IDapperInterventionRepository interventionRepository, 
            IDapperToothRepository toothRepository,
            IDapperPatientRepository patientRepository,
            IDapperAppointmentRepository appointmentRepository)
        {
            _interventionRepository = interventionRepository;
            _toothRepository = toothRepository;
            _patientRepository = patientRepository;
            _appointmentRepository = appointmentRepository;
        }

        // GET: Interventions
        [Route("Interventions/{id}")]
        public async Task<IActionResult> Index(int id, Intervention intervention = null)
        {
            ViewBag.ListOfTeeth = TeethConverters.TeethForFrontEnd(await _toothRepository.GetTeethAsync());

            InterventionView interventionView = new InterventionView();
            interventionView.Intervention = intervention ?? new Intervention();

            var interventions = await _interventionRepository.GetInterventionsByAppointmentId(id) ?? new List<Core.Models.Intervention>();

            interventionView.InterventionList = InterventionConverters.InterventionsForFrontEnd(interventions, _toothRepository, _patientRepository, _appointmentRepository);
            interventionView.Intervention.AppointmentId = interventions.First().AppointmentId;

            return View(interventionView);
        }

        //// GET: Interventions/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var intervention = await _context.Intervention
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (intervention == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(intervention);
        //}

        //// GET: Interventions/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Interventions/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,AppointmentId,ToothId,Description")] Intervention intervention)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(intervention);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(intervention);
        //}

        //// GET: Interventions/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var intervention = await _context.Intervention.FindAsync(id);
        //    if (intervention == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(intervention);
        //}

        //// POST: Interventions/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,AppointmentId,ToothId,Description")] Intervention intervention)
        //{
        //    if (id != intervention.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(intervention);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!InterventionExists(intervention.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(intervention);
        //}

        //// GET: Interventions/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var intervention = await _context.Intervention
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (intervention == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(intervention);
        //}

        //// POST: Interventions/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var intervention = await _context.Intervention.FindAsync(id);
        //    _context.Intervention.Remove(intervention);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool InterventionExists(int id)
        //{
        //    return _context.Intervention.Any(e => e.Id == id);
        //}
    }
}
