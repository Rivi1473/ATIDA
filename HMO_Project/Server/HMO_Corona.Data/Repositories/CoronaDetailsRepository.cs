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
    public class CoronaDetailsRepository : ICoronaDetailsRepository
    {
        private readonly DataContext _context;
        public CoronaDetailsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<CoronaDetails>> GetAllCoronaDetailsAsync()
        {
            // לבדוק על include
            return await _context.CoronaDetails.ToListAsync();
        }

        public async Task<CoronaDetails> GetCoronaDetailsByIdAsync(int id)
        {
            return await _context.CoronaDetails.FirstAsync(i => i.Id == id);
        }

        public async Task<int> AddCoronaDetailsAsync(CoronaDetails coronaDetails)
        {
            _context.CoronaDetails.Add(coronaDetails);
            await _context.SaveChangesAsync();
            return coronaDetails.Id;
        }

        public async Task UpdateCoronaDetailsAsync(int id, CoronaDetails coronaDetails)
        {
            var cDetails = GetCoronaDetailsByIdAsync(id).Result;
            if (cDetails != null)
            {
                cDetails.FirstVaccinationDate = coronaDetails.FirstVaccinationDate;
                cDetails.FirstmanufacturerVaccination = coronaDetails.FirstmanufacturerVaccination;
                cDetails.SecondVaccinationDate = coronaDetails.SecondVaccinationDate;
                cDetails.SecondmanufacturerVaccination = coronaDetails.SecondmanufacturerVaccination;
                cDetails.ThirdVaccinationDate = coronaDetails.ThirdVaccinationDate;
                cDetails.ThirdmanufacturerVaccination = coronaDetails.ThirdmanufacturerVaccination;
                cDetails.FourthVaccinationDate = coronaDetails.FourthVaccinationDate;
                cDetails.FourthmanufacturerVaccination = coronaDetails.FourthmanufacturerVaccination;
                cDetails.PositiveResultDate = coronaDetails.PositiveResultDate;
                cDetails.RecoveryDate = coronaDetails.RecoveryDate;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCoronaDetailsAsync(int id)
        {
            var coronaDetails = GetCoronaDetailsByIdAsync(id).Result;
            _context.CoronaDetails.Remove(coronaDetails);
            await _context.SaveChangesAsync();
        }
    }
}
