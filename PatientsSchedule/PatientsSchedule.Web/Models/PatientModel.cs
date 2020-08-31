using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientsSchedule.Web.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Prenume")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Nume")]
        public string LastName { get; set; }

        [Required]
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
