using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PatientsSchedule.Tests
{
    public class PatientConverterTests
    {
        [Fact]
        public void PatientConverter_PatientForFrontEnd_Works()
        {
            // Arrange
            var expected = GetListOfPatients().Where(x => x.Id == 1).First();
            
            // Act
            var actual = Web.Internal.PatientConverter.PatientForFrontEnd(expected);

            //Assert
            Assert.Equal(expected.Id, actual.Id);
            Assert.True(string.Equals(expected.FirstName, actual.FirstName, System.StringComparison.OrdinalIgnoreCase));
            Assert.True(string.Equals(expected.LastName, actual.LastName, System.StringComparison.OrdinalIgnoreCase));
            Assert.True(string.Equals(expected.Address, actual.Address, System.StringComparison.OrdinalIgnoreCase));
        }

        private List<Core.Models.Patient> GetListOfPatients()
        {
            List<Core.Models.Patient> output = new List<Core.Models.Patient>
            {
                new Core.Models.Patient { Id = 1, FirstName = "Tinu", LastName = "Murani", Address = "Oradea" },
                new Core.Models.Patient { Id = 2, FirstName = "Anca", LastName = "Porumb", Address = "Oradea" },
                new Core.Models.Patient { Id = 3, FirstName = "Radu", LastName = "Murani", Address = "Oradea" },
                new Core.Models.Patient { Id = 4, FirstName = "Anca", LastName = "Litiu", Address = "Oradea" },
            };

            return output;
        }
    }
}
