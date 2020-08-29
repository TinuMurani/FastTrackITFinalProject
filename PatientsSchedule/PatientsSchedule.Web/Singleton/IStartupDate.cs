using System;

namespace PatientsSchedule.Web.Singleton
{
    public interface IStartupDate
    {
        DateTime ReferenceDate { get; set; }
    }
}