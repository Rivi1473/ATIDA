using HMO_Corona.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Corona.Core.Services
{
    public interface ICoronaDetailsService
    {
        public Task<List<CoronaDetails>> GetAllCoronaDetailsAsync();
        public Task<CoronaDetails> GetCoronaDetailsByIdAsync(int id);
        public Task<int> AddCoronaDetailsAsync(CoronaDetails coronaDetails);
        public Task UpdateCoronaDetailsAsync(int id, CoronaDetails coronaDetails);
        public Task DeleteCoronaDetailsAsync(int id);
    }
}
