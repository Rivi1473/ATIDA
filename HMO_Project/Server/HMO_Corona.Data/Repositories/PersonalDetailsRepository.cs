using HMO_Corona.Core.Entities;
using HMO_Corona.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Corona.Data.Repositories
{
    public class PersonalDetailsRepository : IPersonalDetailsRepository
    {
        private readonly DataContext _context;
        public PersonalDetailsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<PersonalDetails>> GetAllPersonalDetailsAsync()
        {

            return await _context.PersonalDetails.Include(c => c.CoronaDetails).ToListAsync();
        }

        public async Task<PersonalDetails> GetPersonalDetailsByIdAsync(int id)
        {
            return await _context.PersonalDetails.Include(c => c.CoronaDetails).FirstAsync(i => i.Id == id);
        }
        public async Task AddPersonalDetailsAsync(PersonalDetails personalDetails)
        {
            _context.PersonalDetails.Add(personalDetails);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePersonalDetailsAsync(int id, PersonalDetails personalDetails)
        {
            var pDetails= GetPersonalDetailsByIdAsync(id).Result;
            if (pDetails != null)
            {
                pDetails.Name = personalDetails.Name;
                pDetails.Tz = personalDetails.Tz;
                pDetails.City = personalDetails.City;
                pDetails.StreetName = personalDetails.StreetName;
                pDetails.NumberHouse = personalDetails.NumberHouse;
                pDetails.BornDate = personalDetails.BornDate;
                pDetails.Phone = personalDetails.Phone;
                pDetails.MobilePhone = personalDetails.MobilePhone;
                pDetails.FileType = personalDetails.FileType;
                pDetails.FileData = personalDetails.FileData;
                await _context.SaveChangesAsync();
            }

        }
        public async Task DeletePersonalDetailsAsync(int id)
        {
            var personalDetails = GetPersonalDetailsByIdAsync(id).Result;
            _context.PersonalDetails.Remove(personalDetails);
            await _context.SaveChangesAsync();
        }
    }
}
