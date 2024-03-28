using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Corona.Core.Dtos
{
    public class CoronaDetailsDto
    {
        public int Id { get; set; }
        public DateTime? FirstVaccinationDate { get; set; }
        public string? FirstmanufacturerVaccination { get; set; }
        public DateTime? SecondVaccinationDate { get; set; }
        public string? SecondmanufacturerVaccination { get; set; }
        public DateTime? ThirdVaccinationDate { get; set; }
        public string? ThirdmanufacturerVaccination { get; set; }
        public DateTime? FourthVaccinationDate { get; set; }
        public string? FourthmanufacturerVaccination { get; set; }
        public DateTime? PositiveResultDate { get; set; }
        public DateTime? RecoveryDate { get; set; }
    }
}
