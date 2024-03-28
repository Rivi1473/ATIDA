using HMO_Corona.Core.Entities;
using HMO_Corona.Core.Repositories;
using HMO_Corona.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO_Corona.Service
{
    public class PersonalDetailsService : IPersonalDetailsService
    {
        private readonly IPersonalDetailsRepository _personalDetailsRepository;
        public PersonalDetailsService(IPersonalDetailsRepository personalDetailsRepository)
        {
            _personalDetailsRepository = personalDetailsRepository;
        }
        public async Task<List<PersonalDetails>> GetAllPersonalDetailsAsync()
        {
            return await _personalDetailsRepository.GetAllPersonalDetailsAsync();
        }
        public async Task<PersonalDetails> GetPersonalDetailsByIdAsync(int id)
        {
            return await _personalDetailsRepository.GetPersonalDetailsByIdAsync(id);
        }
        public async Task AddPersonalDetailsAsync(PersonalDetails personalDetails)
        {
            await _personalDetailsRepository.AddPersonalDetailsAsync(personalDetails);

        }
        public async Task UpdatePersonalDetailsAsync(int id, PersonalDetails personalDetails)
        {
            await _personalDetailsRepository.UpdatePersonalDetailsAsync(id, personalDetails);
        }

        public async Task DeletePersonalDetailsAsync(int id)
        {
            await _personalDetailsRepository.DeletePersonalDetailsAsync(id);
        }
    }
}
