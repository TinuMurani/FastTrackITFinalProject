using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientsSchedule.Web.DataOperations;
using PatientsSchedule.Web.Models;

namespace PatientsSchedule.Web.Controllers
{
    [Authorize]
    public class PatientsController : Controller
    {
        private readonly IDbDataAccess _dbDataAccess;

        public PatientsController(IDbDataAccess dbDataAccess)
        {
            _dbDataAccess = dbDataAccess;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dbDataAccess.GetAllPatientsAsync());
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
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Address,PhoneNumber,Email")] PatientModel patient)
        {
            if (ModelState.IsValid)
            {
                int success = await _dbDataAccess.SavePatientAsync(patient);

                if (success != 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMessage = "Something went wrong while creating patient list entry, please try again...";
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

            var pacient = await _dbDataAccess.GetPatientByIdAsync(id.Value);

            if (pacient == null)
            {
                return NotFound();
            }

            return View(pacient);
        }

        // POST: ContactList/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,PhoneNumber,Email")] PatientModel patient)
        {
            if (id != patient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var succes = await _dbDataAccess.UpdatePatientAsync(patient);

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
                    var entry = await _dbDataAccess.GetPatientByIdAsync(patient.Id);

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

            return View(patient);
        }

        // GET: PatientsList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _dbDataAccess.GetPatientByIdAsync(id.Value);

            if (pacient is null)
            {
                return NotFound();
            }

            return View(pacient);
        }

        // GET: PatientList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var patient = await _dbDataAccess.GetPatientByIdAsync(id.Value);

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
            var succes = await _dbDataAccess.DeletePatientAsync(id);

            if (succes != 0)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
