using ContactApplication.Models;

namespace ContactApplication.Data
{
    public interface IPersonRepo
    {
        bool SaveChanges();
        void CreatePerson(Person person);
        void DeletePerson(Guid person);
        IEnumerable<Person> GetAll();
        Person GetPerson(Guid id);




    }
}
