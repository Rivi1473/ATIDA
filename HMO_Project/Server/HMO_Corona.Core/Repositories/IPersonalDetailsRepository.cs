using HMO_Corona.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Corona.Core.Repositories
{
    public interface IPersonalDetailsRepository
    {
        public Task<List<PersonalDetails>> GetAllPersonalDetailsAsync();
        public Task<PersonalDetails> GetPersonalDetailsByIdAsync(int id);
        public Task AddPersonalDetailsAsync(PersonalDetails personalDetails);
        public Task UpdatePersonalDetailsAsync(int id, PersonalDetails personalDetails);
        public Task DeletePersonalDetailsAsync(int id);
    }
}
