using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvolentHealth.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvolentHealth.Model;
using Moq;
using EvolentHealth.DAL;
using EvolentHealth.BAL.Contact;
using System.Web.Http;
using System.Web.Http.Results;

namespace EvolentHealth.WebApi.Controllers.Tests
{
    [TestClass()]
    public class ContactsControllerTests
    {
        [TestMethod]
        public void Get()
        {
            var contact = new Contact { FirstName = "Evolent" };
            var contacts = new List<Contact>();
            contacts.Add(contact);

            var mockRepo = new Mock<IContactManager>();
            mockRepo.Setup(x => x.GetContactList()).Returns(contacts);

            // Arrange
            ContactsController controller = new ContactsController(mockRepo.Object);

            // Act
            var result = controller.Get();

            //// Assert
            //Assert.IsNotNull(result.FirstOrDefault());
            //Assert.AreEqual(1, result.Count());
            //Assert.AreEqual("Evolent", result.FirstOrDefault().FirstName);
        }

        [TestMethod]
        public void GetById()
        {
            int id = 1;
            var contact = new Contact { Id =1, FirstName = "Evolent" };

            var mockRepo = new Mock<IContactManager>();
            mockRepo.Setup(x => x.GetContact(id)).Returns(contact);

            // Arrange
            ContactsController controller = new ContactsController(mockRepo.Object);

            // Act
            var result = controller.Get(1);

            // Assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual("Evolent", result.FirstName);
        }

        [TestMethod]
        public void Post()
        {
            var contact = new Contact { Id = 1, FirstName = "Evolent" };

            var mockRepo = new Mock<IContactManager>();
            mockRepo.Setup(x => x.AddContact(contact));

            // Arrange
            ContactsController controller = new ContactsController(mockRepo.Object);

            // Act
            IHttpActionResult actionResult = controller.Post(contact);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));

        }

        [TestMethod]
        public void Put()
        {
            var contact = new Contact { Id = 1, FirstName = "Evolent" };

            var mockRepo = new Mock<IContactManager>();
            mockRepo.Setup(x => x.EditContact(contact)).Returns(true);


            // Arrange
            ContactsController controller = new ContactsController(mockRepo.Object);

            // Act
            IHttpActionResult actionResult = controller.Put(contact);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }

        [TestMethod]
        public void Delete()
        {
            var contact = new Contact { Id = 1, FirstName = "Evolent" };

            var mockRepo = new Mock<IContactManager>();
            mockRepo.Setup(x => x.DeleteContact(1)).Returns(true);


            // Arrange
            ContactsController controller = new ContactsController(mockRepo.Object);

            // Act
            IHttpActionResult actionResult = controller.Delete(1);

            //Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }
    }
}