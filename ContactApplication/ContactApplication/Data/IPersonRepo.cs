using ContactApplication.Models;

namespace ContactApplication.Data
{
    public interface IPersonRepo
    {

        void CreatePerson(Person person);
        void DeletePerson(Guid person);
        IEnumerable<Person> GetAll();
        Person GetPersonById(Guid id);
        bool PersonExists(Guid id);
        Person GetPersonDetailedById(Guid id);
        IEnumerable<Person> GetAllDetailed();

    }
}
