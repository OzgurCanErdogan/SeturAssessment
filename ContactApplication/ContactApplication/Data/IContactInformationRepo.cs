using ContactApplication.Models;

namespace ContactApplication.Data
{
    public interface IContactInformationRepo
    {
        ContactInformation GetContactInformation(Guid id);
        void AddContactInformation(ContactInformation contactInformation, Guid personId);
        void DeleteContactInformation(Guid contactInformationId, Guid personId);
        bool ContactInformationExists(Guid id);
        IEnumerable<ContactInformation> GetAllContactInformation();
    }
}
