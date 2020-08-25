using System.ComponentModel;

namespace PatientsSchedule.Web.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        [DisplayName("Prenume")]
        public string FirstName { get; set; }

        [DisplayName("Nume")]
        public string LastName { get; set; }

        [DisplayName("Adresa")]
        public string Address { get; set; }

        [DisplayName("Telefon")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string FullName
        {
            get
            {
                return $"{ LastName } { FirstName }";
            }
        }
    }
}
