﻿using ContactApplication.Models;

namespace ContactApplication.Data
{
    public interface IContactInformationRepo
    {
        bool SaveChanges();
        ContactInformation GetContactInformation(Guid id);
        void AddContactInformation(ContactInformation contactInformation, Guid personId);
        void DeleteContactInformation(Guid contactInformationId, Guid personId);
    }
}
