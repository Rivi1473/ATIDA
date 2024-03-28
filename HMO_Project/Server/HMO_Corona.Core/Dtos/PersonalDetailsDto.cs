using HMO_Corona.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Corona.Core.Dtos
{
    public class PersonalDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tz { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public int NumberHouse { get; set; }
        public DateTime BornDate { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string FileType { get; set; }
        public string? ImageUrl { get; set; }
        public int CoronaDetailsId { get; set; }
        public CoronaDetails CoronaDetails { get; set; }
    }
}
