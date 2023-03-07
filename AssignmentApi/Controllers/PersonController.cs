using Assignment.Entities.Models;
using AssignmentApi.Models;
using AssignmentApi.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;
        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.GetPersons());
        }

        [HttpGet,Route("id")]
        public IActionResult Get(int id)
        {
            Person? person = _personService.GetPersonById(id);

            if (person == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(person);
            }           
        }

        [HttpPost]
        public void Post(PersonModel person)
        {
            Person personDto = _mapper.Map<Person>(person);
            _personService.AddPerson(personDto);
        }

        [HttpPut]
        public void Put(PersonModel person)
        {
            Person personDto = _mapper.Map<Person>(person);
            _personService.UpdatePerson(personDto);
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            _personService.DeletePerson(Id);
        }
    }
}