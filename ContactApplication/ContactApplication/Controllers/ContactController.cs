using AutoMapper;
using ContactApplication.Data;
using ContactApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System;
using ContactApplication.Dtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ContactApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private IContactRepo _contactRepo;
        private IMapper _mapper;

        public ContactController(IContactRepo contactRepo, IMapper mapper)
        {
            _contactRepo = contactRepo;
            _mapper = mapper;
        }

        [HttpPost(Name ="CreatePerson")]
        [Route("~/api/[controller]/CreatePerson")]
        public ActionResult<PersonCreateDto> CreatePerson(PersonCreateDto personData)
        {
            var person = _mapper.Map<Person>(personData);
            _contactRepo.CreatePerson(person);
            _contactRepo.SaveChanges();

            //var createdPersonDto = _mapper.Map<PersonReadDto>(person);
            return Ok(personData);
        }

        [HttpPost(Name = "DeletePerson")]
        [Route("~/api/[controller]/DeletePerson/{personId}")]
        public ActionResult<PersonCreateDto> DeletePerson(Guid personId)
        {
            _contactRepo.DeletePerson(personId);
            _contactRepo.SaveChanges();
            
            //var createdPersonDto = _mapper.Map<PersonReadDto>(person);
            return Ok();
        }

        [HttpGet(Name ="GetAllPerson")]
        [Route("~/api/[controller]/GetAllPerson")]
        public ActionResult<IEnumerable<PersonReadDto>> GetAllPerson()
        {
            var people = _contactRepo.GetAll();
            return Ok(_mapper.Map<IEnumerable<PersonReadDto>>(people));
        }

        [HttpGet("{personId}",Name = "GetPersonById")]
        [Route("~/api/[controller]/GetPersonById/{personId}")]
        public ActionResult<PersonReadDto> GetPersonById(Guid personId)
        {

            if (!_contactRepo.PersonExists(personId))
            {
                return NotFound();
            }

            var person = _contactRepo.GetPersonById(personId);
            if (person == null)
                return NotFound();

            return Ok(_mapper.Map<PersonReadDto>(person));
        }


        //Düzeltilecek. Return kısımları açıklamalı olacak
        [HttpPost(Name = "AddContactInformation")]
        [Route("~/api/[controller]/AddContactInformation/{personId}")]
        public ActionResult<Person> AddContactInformation(Guid personId, ContactInformationCreateDto createDto)
        {
            if (!_contactRepo.PersonExists(personId))
            {
                return NotFound();
            }

            var contact = _mapper.Map<ContactInformation>(createDto);

            _contactRepo.AddContactInformation(contact, personId);
            _contactRepo.SaveChanges();

            
            //var createdPersonDto = _mapper.Map<PersonReadDto>(person);
            return Ok(_contactRepo.GetPersonDetailedById(personId));
        }

        [HttpDelete(Name = "DeleteContactInformation")]
        [Route("~/api/[controller]/DeleteContactInformation/{personId}/{contactId}")]
        public ActionResult<Person> DeleteContactInformation(Guid personId, Guid contactId)
        {
            if (!_contactRepo.PersonExists(personId))
            {
                return NotFound();
            }
            if (!_contactRepo.ContactInformationExists(contactId))
            {
                return NotFound();
            }
            
            _contactRepo.DeleteContactInformation(contactId, personId);
            _contactRepo.SaveChanges();


            //var createdPersonDto = _mapper.Map<PersonReadDto>(person);
            return Ok(_contactRepo.GetPersonDetailedById(personId));
        }


    }
}
