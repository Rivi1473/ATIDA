namespace HMO_Corona.API.Models
{
    public class PersonalDetailsModel
    {
        public string Name { get; set; }
        public string Tz { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public int NumberHouse { get; set; }
        public DateTime BornDate { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public IFormFile? ImageFile { get; set; }
        public int CoronaDetailsId { get; set; }

    }
}
