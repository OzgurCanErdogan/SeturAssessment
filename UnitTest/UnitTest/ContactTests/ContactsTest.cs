using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ContactApplication;
using ContactApplication.Data;
using ContactApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace UnitTest.ContactTests
{
    [TestClass]
    public class ContactsTest
    {

        private static AppDbContext appDbContext = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
                .ConfigureWarnings(warnings => warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .UseNpgsql(connectionString: "User ID=postgres;Password=admin123;Host=localhost;Port=5432;Database=postgres;")
                .Options);

        private static IContactRepo _contactRepos = new ContactRepo(appDbContext);

        [TestMethod]
        public void CreatePerson()
        {
            //Arrange
            Person person = new Person();
            person.Name = "Test Name";
            person.Surname = "Test Surname";
            person.CompanyName = "Setur";
            int beforeCount = _contactRepos.GetAll().ToList().Count;

            //Act
            _contactRepos.CreatePerson(person);
            int afterCount = _contactRepos.GetAll().ToList().Count;
            Person createdPerson = _contactRepos.GetPersonById(person.Id);

            //Assert
            Assert.AreEqual(afterCount, beforeCount+1);
            Assert.AreEqual(createdPerson.Id, person.Id);
        }

        [TestMethod]
        public void DeletePerson()
        {
            //Arrange
            Person person = new Person();
            person.Name = "Test Name";
            person.Surname = "Test Surname";
            person.CompanyName = "Setur";
            int beforeCount = _contactRepos.GetAll().ToList().Count;
            _contactRepos.CreatePerson(person);

            //Act
            _contactRepos.DeletePerson(person.Id);
            int afterCount = _contactRepos.GetAll().ToList().Count;
            Person createdPerson = _contactRepos.GetPersonById(person.Id);

            //Assert
            Assert.AreEqual(afterCount, beforeCount);
            Assert.AreEqual(createdPerson, null);
        }

        [TestMethod]
        public void GetPersonById()
        {
            //Arrange
            Person person = new Person();
            person.Name = "Test Name";
            person.Surname = "Test Surname";
            person.CompanyName = "Setur";
            
            _contactRepos.CreatePerson(person);

            //Act
            Person createdPerson = _contactRepos.GetPersonById(person.Id);

            //Assert
            Assert.AreEqual(createdPerson.Id, person.Id);
        }
        

        [TestMethod]
        public void AddContactInformation()
        {
            //Arrange
            Person person = new Person();
            person.Name = "Test Name";
            person.Surname = "Test Surname";
            person.CompanyName = "Setur";
            _contactRepos.CreatePerson(person);

            ContactInformation contactInformation = new ContactInformation();
            contactInformation.Email = "test@test.com";
            contactInformation.PhoneNumber = "12345";;
            contactInformation.Location = "Ankara";
            int beforeCount = _contactRepos.GetAllContactInformation().ToList().Count;

            //Act
            _contactRepos.AddContactInformation(contactInformation, person.Id);
            int afterCount = _contactRepos.GetAllContactInformation().ToList().Count;


            //Assert
            Assert.AreEqual(afterCount, beforeCount + 1);
            Assert.AreEqual(contactInformation.Id, _contactRepos.GetContactInformation(contactInformation.Id).Id);
        }

        [TestMethod]
        public void GetContactInformation()
        {
            //Arrange
            Person person = new Person();
            person.Name = "Test Name";
            person.Surname = "Test Surname";
            person.CompanyName = "Setur";
            _contactRepos.CreatePerson(person);

            ContactInformation contactInformation = new ContactInformation();
            contactInformation.Email = "test@test.com";
            contactInformation.PhoneNumber = "12345"; ;
            contactInformation.Location = "Ankara";

            //Act
            _contactRepos.AddContactInformation(contactInformation, person.Id);

            //Assert
            Assert.AreEqual(contactInformation.Id, _contactRepos.GetContactInformation(contactInformation.Id).Id);
        }

        [TestMethod]
        public void DeleteContactInformation()
        {
            //Arrange
            Person person = new Person();
            person.Name = "Test Name";
            person.Surname = "Test Surname";
            person.CompanyName = "Setur";
            _contactRepos.CreatePerson(person);

            ContactInformation contactInformation = new ContactInformation();
            contactInformation.Email = "test@test.com";
            contactInformation.PhoneNumber = "12345"; ;
            contactInformation.Location = "Ankara";
            int beforeCount = _contactRepos.GetAllContactInformation().ToList().Count;
            _contactRepos.AddContactInformation(contactInformation, person.Id);

            //Act
            _contactRepos.DeleteContactInformation(contactInformation.Id, person.Id);
            int afterCount = _contactRepos.GetAllContactInformation().ToList().Count;

            //Assert
            Assert.AreEqual(afterCount, beforeCount);
            Assert.AreEqual(null, _contactRepos.GetContactInformation(contactInformation.Id));
        }
    }
}
