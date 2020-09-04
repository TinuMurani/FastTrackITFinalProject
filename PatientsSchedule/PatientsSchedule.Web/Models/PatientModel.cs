using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PatientsSchedule.Web.Models
{
    public class PatientModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
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
