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
            SaveChanges();

            //return person;
        }
        public void DeletePerson(Guid id)
        {
            Person deletePerson = GetPersonById(id);
            _context.Person.Remove(deletePerson);
            SaveChanges();
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
        public IEnumerable<Person> GetAllDetailed()
        {
            return _context.Person.Include(p => p.ContactInformation).ToList();
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
                SaveChanges();

            }
        }
        public void DeleteContactInformation(Guid contactInformationId, Guid personId)
        {
            Person tempPerson = GetPersonById(personId);
            if (tempPerson != null)
            {
                ContactInformation deleteInformation = GetContactInformation(contactInformationId);
                _context.ContactInformation.Remove(deleteInformation);
                SaveChanges();


            }

        }

        public bool ContactInformationExists(Guid id)
        {
            return _context.ContactInformation.Any(p => p.Id == id);
        }

        public IEnumerable<ContactInformation> GetAllContactInformation()
        {
            return _context.ContactInformation.ToList();
        }

        private bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateReportDetail(Guid reportId, byte[] file)
        {
            ReportDetails reportDetails = new ReportDetails();
            reportDetails.ReportId = reportId;
            reportDetails.ReportByte = file;
            _context.ReportDetails.Add(reportDetails);
            SaveChanges();
        }

        public void UpdateReportStatus(Guid reportId)
        {
            Report report = _context.Reports.FirstOrDefault(p=> p.Id == reportId);
            if (report != null)
            {
                report.Status = ReportStatus.Created;
                _context.Update(report);
                SaveChanges();
            }
        }
        public bool IsReportExist(Guid reportId)
        {
            return _context.Reports.Any(p => p.Id == reportId);
        }
    }
}
