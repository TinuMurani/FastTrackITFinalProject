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
        public DbSet<PatientsSchedule.Web.Models.PatientModel> PatientModel { get; set; }
        public DbSet<PatientsSchedule.Web.Models.AppointmentModel> AppointmentModel { get; set; }
    }
}
