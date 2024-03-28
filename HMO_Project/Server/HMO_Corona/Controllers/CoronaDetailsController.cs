using AutoMapper;
using HMO_Corona.API.Models;
using HMO_Corona.Core.Dtos;
using HMO_Corona.Core.Entities;
using HMO_Corona.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO_Corona.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoronaDetailsController : ControllerBase
    {
        private readonly ICoronaDetailsService _coronaDetailsService;
        private readonly IMapper _mapper;
        public CoronaDetailsController(ICoronaDetailsService coronaDetailsService, IMapper mapper)
        {
            _mapper = mapper;
            _coronaDetailsService = coronaDetailsService;
        }
        // GET: api/<CoronaDetailsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var coronaDetailsList = await _coronaDetailsService.GetAllCoronaDetailsAsync();
            List<CoronaDetailsDto> coronaDetailsDtoList = _mapper.Map<IEnumerable<CoronaDetailsDto>>(coronaDetailsList).ToList();
            return Ok(coronaDetailsDtoList);
        }

        // GET api/<CoronaDetailsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var coronaDetails = await _coronaDetailsService.GetCoronaDetailsByIdAsync(id);
            return Ok(_mapper.Map<CoronaDetailsDto>(coronaDetails));
        }

        // POST api/<CoronaDetailsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CoronaDetailsModel coronaDetailsModel)
        {
            var request = validation(coronaDetailsModel);
            if (request != "")
                return BadRequest(request);
            var coronaDetails=new CoronaDetails();
            _mapper.Map(coronaDetailsModel, coronaDetails);
            await _coronaDetailsService.AddCoronaDetailsAsync(coronaDetails);
            return Ok(_mapper.Map<CoronaDetailsDto>(coronaDetails));

        }

        // PUT api/<CoronaDetailsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CoronaDetailsModel coronaDetailsModel)
        {
            var request = validation(coronaDetailsModel);
            if (request != "")
                return BadRequest(request);
            var coronaDetails = await _coronaDetailsService.GetCoronaDetailsByIdAsync(id);
            if (coronaDetails is null)
            {
                return NotFound();
            }
            _mapper.Map(coronaDetailsModel, coronaDetails);
            await _coronaDetailsService.UpdateCoronaDetailsAsync(id, coronaDetails);
            return Ok(_mapper.Map<CoronaDetailsDto>(coronaDetails));
        }

        // DELETE api/<CoronaDetailsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _coronaDetailsService.DeleteCoronaDetailsAsync(id);

        }
        private string validation(CoronaDetailsModel coronaDetailsModel)
        {
            DateTime date = new DateTime(1900, 1, 1);
            if (coronaDetailsModel.PositiveResultDate > DateTime.Now)
                return "Positive date cannot be after today's date";
            if (coronaDetailsModel.RecoveryDate > DateTime.Now)
                return "Recovery date cannot be after today's date";
            if (coronaDetailsModel.FirstVaccinationDate > DateTime.Now)
                return "First vaccination date cannot be after today's date";
            if (coronaDetailsModel.SecondVaccinationDate > DateTime.Now)
                return "Second vaccination Result date cannot be after today's date";
            if (coronaDetailsModel.ThirdVaccinationDate > DateTime.Now)
                return "third vaccination date cannot be after today's date";
            if (coronaDetailsModel.PositiveResultDate==date && coronaDetailsModel.RecoveryDate!= date|| coronaDetailsModel.RecoveryDate != date && coronaDetailsModel.PositiveResultDate >=coronaDetailsModel.RecoveryDate)
                return "Recovery date cannot be before positive answer date";
            if (coronaDetailsModel.FirstVaccinationDate != date && coronaDetailsModel.FirstmanufacturerVaccination ==""|| coronaDetailsModel.FirstVaccinationDate == date && coronaDetailsModel.FirstmanufacturerVaccination != ""
                || coronaDetailsModel.SecondVaccinationDate != date && coronaDetailsModel.SecondmanufacturerVaccination == "" || coronaDetailsModel.SecondVaccinationDate == date && coronaDetailsModel.SecondmanufacturerVaccination != ""
                || coronaDetailsModel.ThirdVaccinationDate != date && coronaDetailsModel.ThirdmanufacturerVaccination == "" || coronaDetailsModel.ThirdVaccinationDate == date && coronaDetailsModel.ThirdmanufacturerVaccination != ""
                || coronaDetailsModel.FourthVaccinationDate != date && coronaDetailsModel.FourthmanufacturerVaccination == "" || coronaDetailsModel.FourthVaccinationDate == date && coronaDetailsModel.FourthmanufacturerVaccination != "")
                return "you must enter a date and manufacturer fot a vaccination";
            if (coronaDetailsModel.SecondVaccinationDate != date && coronaDetailsModel.FirstVaccinationDate == date || coronaDetailsModel.SecondVaccinationDate != date && coronaDetailsModel.FirstVaccinationDate > coronaDetailsModel.SecondVaccinationDate
                || coronaDetailsModel.ThirdVaccinationDate != date && coronaDetailsModel.SecondVaccinationDate == date || coronaDetailsModel.ThirdVaccinationDate != date && coronaDetailsModel.SecondVaccinationDate > coronaDetailsModel.ThirdVaccinationDate
                || coronaDetailsModel.FourthVaccinationDate != date && coronaDetailsModel.ThirdVaccinationDate == date || coronaDetailsModel.FourthVaccinationDate != date && coronaDetailsModel.ThirdVaccinationDate > coronaDetailsModel.FourthVaccinationDate)
                return "You must enter the vaccination details in order and according to the dates";
            return "";
        } 
    }
}
