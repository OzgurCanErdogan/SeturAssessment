using ContactApplication.Models;

namespace ContactApplication.Data
{
    public class ContactRepo : IPersonRepo, IContactInformationRepo
    {
        private readonly AppDbContext _context;
        public ContactRepo(AppDbContext context)
        {
            _context = context;
        }

        //IPersonRepo Implemantation
        public void CreatePerson(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            _context.People.Add(person);
        }
        public void DeletePerson(Guid id)
        {
            Person deletePerson = GetPerson(id);
            _context.People.Remove(deletePerson);
            _context.SaveChanges();
        }

        public Person GetPerson(Guid id)
        {
            return _context.People.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _context.People.ToList();
        }


        //IContactInformationRepo Implemantation
        public ContactInformation GetContactInformation(Guid id)
        {
            return _context.ContactInformation.FirstOrDefault(p => p.Id == id);
        }
        public void AddContactInformation(ContactInformation contactInformation, Guid personId)
        {
            Person tempPerson = GetPerson(personId);
            if (tempPerson != null)
            {
                ContactInformation contact = contactInformation;
                contact.Person = tempPerson;
                _context.ContactInformation.Add(contact);
                _context.SaveChanges();
            }
        }
        public void DeleteContactInformation(Guid contactInformationId, Guid personId)
        {
            Person tempPerson = GetPerson(personId);
            if (tempPerson != null)
            {
                ContactInformation deleteInformation = GetContactInformation(contactInformationId);
                _context.ContactInformation.Remove(deleteInformation);
                _context.SaveChanges();
            }

        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
