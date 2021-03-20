using Microsoft.VisualStudio.TestTools.UnitTesting;
using EvolentHealth.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EvolentHealth.BAL.ApiCall;
using EvolentHealth.Model;
using Moq;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Net;
using EvolentHealth.BAL.ApiCall.Impl;

namespace EvolentHealth.Controllers.Tests
{
    [TestClass()]
    public class ContactControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            // Arrange
            var contact = new Contact { FirstName = "Evolent" };
            var contacts = new List<Contact>();
            contacts.Add(contact);
            HttpResponseMessage resposnse = new HttpResponseMessage();

            resposnse.Content = new StringContent(new JavaScriptSerializer().Serialize(contacts), Encoding.UTF8, "application/json");
            resposnse.StatusCode = HttpStatusCode.Accepted;

            var mockRepo = new Mock<IWebApiCall>();
            mockRepo.Setup(x => x.Get()).Returns(resposnse);

            // Arrange
            ContactController controller = new ContactController(mockRepo.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Equals(contacts, (List<Contact>)result.Model);
        }

        [TestMethod()]
        public void AddContactPostTest()
        {
            // Arrange
            var contact = new Contact {Id=1, FirstName = "Evolent" };

            HttpResponseMessage resposnse = new HttpResponseMessage();
            resposnse.StatusCode = HttpStatusCode.Accepted;

            var mockRepo = new Mock<IWebApiCall>();
            mockRepo.Setup(x => x.Post(contact)).Returns(resposnse);

            // Arrange
            ContactController controller = new ContactController(mockRepo.Object);

            // Act
            var result = controller.AddContact(contact) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void AddContactTest()
        {
            // Arrange
            ContactController controller = new ContactController(new WebApiCall());

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EditContactTest()
        {
            // Arrange
            var contact = new Contact { Id=1, FirstName = "Evolent" };

            HttpResponseMessage resposnse = new HttpResponseMessage();
            resposnse.StatusCode = HttpStatusCode.Accepted;

            var mockRepo = new Mock<IWebApiCall>();
            mockRepo.Setup(x => x.Put(contact)).Returns(resposnse);

            // Arrange
            ContactController controller = new ContactController(mockRepo.Object);

            // Act
            var result = controller.EditContact(contact) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteContactTest()
        {
            // Arrange

            HttpResponseMessage resposnse = new HttpResponseMessage();
            resposnse.StatusCode = HttpStatusCode.Accepted;

            var mockRepo = new Mock<IWebApiCall>();
            mockRepo.Setup(x => x.Delete(1)).Returns(resposnse);

            // Arrange
            ContactController controller = new ContactController(mockRepo.Object);

            // Act
            var result = controller.DeleteContact(1) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}