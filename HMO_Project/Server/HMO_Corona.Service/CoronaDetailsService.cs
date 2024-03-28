using HMO_Corona.Core.Entities;
using HMO_Corona.Core.Repositories;
using HMO_Corona.Core.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Corona.Service
{
    public class CoronaDetailsService : ICoronaDetailsService
    {
        private readonly ICoronaDetailsRepository _coronaDetailsRepository;
        public CoronaDetailsService(ICoronaDetailsRepository coronaDetailsRepository)
        {
            _coronaDetailsRepository = coronaDetailsRepository;
        }
        public async Task<List<CoronaDetails>> GetAllCoronaDetailsAsync()
        {
            return await _coronaDetailsRepository.GetAllCoronaDetailsAsync();
        }

        public async Task<CoronaDetails> GetCoronaDetailsByIdAsync(int id)
        {
            return await _coronaDetailsRepository.GetCoronaDetailsByIdAsync(id);
        }
        public async Task<int> AddCoronaDetailsAsync(CoronaDetails coronaDetails)
        {
           return await _coronaDetailsRepository.AddCoronaDetailsAsync(coronaDetails);
        }
        public async Task UpdateCoronaDetailsAsync(int id, CoronaDetails coronaDetails)
        {
            await _coronaDetailsRepository.UpdateCoronaDetailsAsync(id, coronaDetails);
        }

        public async Task DeleteCoronaDetailsAsync(int id)
        {
            await _coronaDetailsRepository.DeleteCoronaDetailsAsync(id);
        }
    }
}
