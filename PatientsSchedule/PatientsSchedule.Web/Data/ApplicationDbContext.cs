using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PatientsSchedule.Web.Models;

namespace PatientsSchedule.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PatientsSchedule.Web.Models.Patient> PatientModel { get; set; }
        public DbSet<PatientsSchedule.Web.Models.Appointment> AppointmentModel { get; set; }
    }
}
