using ContactApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactApplication.Data
{
    public class ContactRepo : IContactRepo
    {
        private readonly AppDbContext _context;
        public ContactRepo(AppDbContext context)
        {
            _context = context;
        }

        //IPersonRepo Implemantation
        public bool PersonExists(Guid id)
        {
            return _context.Person.Any(p => p.Id == id);
        }
        public void CreatePerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            _context.Person.Add(person);
        }
        public void DeletePerson(Guid id)
        {
            Person deletePerson = GetPersonById(id);
            _context.Person.Remove(deletePerson);
        }

        public Person GetPersonById(Guid id)
        {
            return _context.Person.FirstOrDefault(p => p.Id == id);
        }
        public Person GetPersonDetailedById(Guid id)
        {
            return _context.Person.Include(p => p.ContactInformation).FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.Person.ToList();
        }


        //IContactInformationRepo Implemantation
        public ContactInformation GetContactInformation(Guid id)
        {
            return _context.ContactInformation.FirstOrDefault(p => p.Id == id);
        }
        public void AddContactInformation(ContactInformation contactInformation, Guid personId)
        {
            Person tempPerson = GetPersonById(personId);
            if (tempPerson != null)
            {
                ContactInformation contact = contactInformation;
                contact.Person = tempPerson;
                //tempPerson.ContactInformation.Add(contact);
                _context.ContactInformation.Add(contact);
                

            }
        }
        public void DeleteContactInformation(Guid contactInformationId, Guid personId)
        {
            Person tempPerson = GetPersonById(personId);
            if (tempPerson != null)
            {
                ContactInformation deleteInformation = GetContactInformation(contactInformationId);
                _context.ContactInformation.Remove(deleteInformation);
                
            }

        }

        public bool ContactInformationExists(Guid id)
        {
            return _context.ContactInformation.Any(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
