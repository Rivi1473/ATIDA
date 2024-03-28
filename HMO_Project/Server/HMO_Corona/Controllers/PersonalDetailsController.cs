using AutoMapper;
using AutoMapper.Execution;
using HMO_Corona.API.Models;
using HMO_Corona.Core.Dtos;
using HMO_Corona.Core.Entities;
using HMO_Corona.Core.Services;
using HMO_Corona.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HMO_Corona.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalDetailsController : ControllerBase
    {
        private readonly IPersonalDetailsService _personalDetailsService;
        private readonly IMapper _mapper;
        public PersonalDetailsController(IPersonalDetailsService personalDetailsService,IMapper mapper)
        {
            _mapper = mapper;
            _personalDetailsService = personalDetailsService;
        }
        // GET: api/<CoronaDetailsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var personalDetailsList = await _personalDetailsService.GetAllPersonalDetailsAsync();

            var url = MakeUrl();
            List<PersonalDetailsDto> personalDetailsDtoList = _mapper.Map<IEnumerable<PersonalDetailsDto>>(personalDetailsList, opt => opt.Items["Url"] = url).ToList();
            return Ok(personalDetailsDtoList);
        }

        // GET api/<CoronaDetailsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var personalDetails = await _personalDetailsService.GetPersonalDetailsByIdAsync(id);
            if (personalDetails is null)
            {
                return NotFound();
            }
            var url = MakeUrl();
            var personalDetailsDto = _mapper.Map<PersonalDetailsDto>(personalDetails, opt => opt.Items["Url"] = url);
            return Ok(personalDetailsDto);
        }

        //[HttpGet("{id}/Image", Name = "GetImageByMemberId")]
        [HttpGet("{id}/Image")]
        public async Task<IActionResult> GetFileById(int id)
        {
            var personalDetails = await _personalDetailsService.GetPersonalDetailsByIdAsync(id);
            if (personalDetails is null)
            {
                return NotFound();
            }
            if (personalDetails.FileData is not null)
            {
                return File(personalDetails.FileData, personalDetails.FileType);
            }
            else
            {
                return NotFound();
            }
        }
        // POST api/<CoronaDetailsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] PersonalDetailsModel personalDetailsModel)
        {
            var request = validation(personalDetailsModel,0);
            if (request != "")
                return BadRequest(request);
            var personalDetails = new PersonalDetails();
            _mapper.Map(personalDetailsModel, personalDetails);
            if (personalDetailsModel.ImageFile is not null)
            {
                try
                {
                    using (var stream = new MemoryStream())
                    {
                        personalDetailsModel.ImageFile.CopyTo(stream);
                        personalDetails.FileData = stream.ToArray();
                        personalDetails.FileType = personalDetailsModel.ImageFile.ContentType;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            await _personalDetailsService.AddPersonalDetailsAsync(personalDetails);
            var url = MakeUrl();
            var personalDetailsDto = _mapper.Map<PersonalDetailsDto>(personalDetails, opt => opt.Items["Url"] = url);
            return Ok(personalDetailsDto);
        }

        // PUT api/<CoronaDetailsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] PersonalDetailsModel personalDetailsModel)
        {
            var request = validation(personalDetailsModel,1);
            if (request != "")
                return BadRequest(request);
            var personalDetails = await _personalDetailsService.GetPersonalDetailsByIdAsync(id);
            if (personalDetails is null)
            {
                return NotFound();
            }
            //var personalDetails = new PersonalDetails();
            _mapper.Map(personalDetailsModel, personalDetails);
            if (personalDetailsModel.ImageFile is not null)
            {
                try
                {
                    using (var stream = new MemoryStream())
                    {
                        personalDetailsModel.ImageFile.CopyTo(stream);
                        personalDetails.FileData = stream.ToArray();
                        personalDetails.FileType = personalDetailsModel.ImageFile.ContentType;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            await _personalDetailsService.UpdatePersonalDetailsAsync(id, personalDetails);

            var url = MakeUrl();
            var personalDetailsDto = _mapper.Map<PersonalDetailsDto>(personalDetails, opt => opt.Items["Url"] = url);
            return Ok(personalDetailsDto);
        }

        // DELETE api/<CoronaDetailsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _personalDetailsService.DeletePersonalDetailsAsync(id);

        }
        private string MakeUrl()
        {
            var request = HttpContext.Request;
            var scheme = request.Scheme;
            var host = request.Host.Host;
            var port = request.Host.Port;
            var url = $"{scheme}://{host}:{port}/api/{HttpContext.Request.RouteValues["controller"]}/";
            return url;
        }
        private string validation(PersonalDetailsModel personalDetailsModel,int num)
        {
            if(personalDetailsModel.BornDate>DateTime.Now)
                return "date of born cannot be after today's date";
            if ((num==0&&!personalDetailsModel.ImageFile.ContentType.StartsWith("image/")))
            {
                return "file is not an image";
            }
           if (!Regex.IsMatch(personalDetailsModel.MobilePhone, @"^\d{10}$"))       
                return "mobile phone number must be 10 digits";
            if (!Regex.IsMatch(personalDetailsModel.Tz, @"^\d{9}$"))
                return "id number must be 9 digits";
            return "";
        }
    }
}
