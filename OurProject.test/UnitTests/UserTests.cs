//System
using System;
using System.Threading.Tasks;

//Microsoft
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

//Moq
using Moq;

//OurProject
using OurProject.API.Ports;
using OurProject.API.Domains;
using OurProject.API.UserControllers;

//Xunit
using Xunit;

//Namespace
namespace OurProject.Test.UnitTests
{
    public class UserControllerUnitTest
    {
        private Mock<ILogger<UserController>> _mockedLogger = new Mock<ILogger<UserController>>();
        private Mock<IDatabase> _mockedDatabase = new Mock<IDatabase>();

        public UserControllerUnitTest()
        {
            _mockedDatabase.Reset();
            _mockedLogger.Reset();
        }

        [Fact]
        public async Task TestGetUserById_Success()
        {
            var rnd = new Random();
            var testId = rnd.Next(101);

            //Create mock up user
            var testUser = new User
            {
                Id = testId,
                personName = "Fluppe",
                personBirth = "9 mei 1998",
                personMail = "fluppevanmeerbeeck@gmail.com",
            };


            //Call the method GetUserById to test our mocked user, no db calls
            _mockedDatabase.Setup(x => x.GetUserById(testId)).Returns(Task.FromResult(testUser));

            //Link controller
            var controller = new UserController(_mockedLogger.Object, _mockedDatabase.Object);
            //Get results from the controller
            var actualResult = await controller.GetUserById(testId) as OkObjectResult;

            //Check results
            Assert.Equal(200, actualResult.StatusCode);
            var viewModel = actualResult.Value as ReadUser;
            Assert.Equal(testUser.Id, viewModel.Id);
            Assert.Equal(testUser.personName, viewModel.personName);
            Assert.Equal(testUser.personBirth, viewModel.personBirth);
            Assert.Equal(testUser.personMail, viewModel.personMail);

            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }

        [Fact]
        public async Task TestGetAllUser_Success()
        {
            var rnd = new Random();
            var testId = rnd.Next(101);

            //Create mock up user
            var testUser = new User
            {
                Id = testId,
                personName = "Fluppe",
                personBirth = "9 mei 1998",
                personMail = "fluppevanmeerbeeck@gmail.com",
            };

            _mockedDatabase.Setup(x => x.GetAllUser(testId)).Returns(Task.FromResult(testUser));

            var controller = new UserController(_mockedLogger.Object, _mockedDatabase.Object);

            var actualResult = await controller.GetAllUser(testId) as OkObjectResult;

            //Check results
            Assert.Equal(200, actualResult.StatusCode);
            var viewModel = actualResult.Value as ReadUser;
            Assert.Equal(testUser.Id, viewModel.Id);
            Assert.Equal(testUser.personName, viewModel.personName);
            Assert.Equal(testUser.personBirth, viewModel.personBirth);
            Assert.Equal(testUser.personMail, viewModel.personMail);

            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }

        [Fact]
        public async Task TestPersistUser_Success()
        {
            var rnd = new Random();
            var testId = rnd.Next(101);

            //Create mock up user
            var testUser = new User
            {
                Id = 2,
                personName = "Arthur",
                personBirth = "12 october 2002",
                personMail = "arthurdelophem3@gmail.com",
            };

            _mockedDatabase.Setup(x => x.PersistUser(testId)).Returns(Task.FromResult(testUser));

            var controller = new UserController(_mockedLogger.Object, _mockedDatabase.Object);

            var actualResult = await controller.PersistUser(testId) as OkObjectResult;

            //Check results
            Assert.Equal(200, actualResult.StatusCode);
            var viewModel = actualResult.Value as ReadUser;
            Assert.Equal(testUser.Id, viewModel.Id);
            Assert.Equal(testUser.personName, viewModel.personName);
            Assert.Equal(testUser.personBirth, viewModel.personBirth);
            Assert.Equal(testUser.personMail, viewModel.personMail);

            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }

        [Fact]
        public async Task TestDeleteUser_Success()
        {
            var rnd = new Random();
            var testId = rnd.Next(101);

            //Create mock up user
            var testUser = new User
            {
                Id = 2,
                personName = "Arthur",
                personBirth = "12 october 2002",
                personMail = "arthurdelophem3@gmail.com",
            };

            _mockedDatabase.Setup(x => x.DeleteUser(testId)).Returns(Task.FromResult(testUser));

            var controller = new UserController(_mockedLogger.Object, _mockedDatabase.Object);

            var actualResult = await controller.DeleteUser(testId) as OkObjectResult;

            //Check results
            Assert.Equal(200, actualResult.StatusCode);
            var viewModel = actualResult.Value as ReadUser;
            Assert.Equal(testUser.Id, viewModel.Id);
            Assert.Equal(testUser.personName, viewModel.personName);
            Assert.Equal(testUser.personBirth, viewModel.personBirth);
            Assert.Equal(testUser.personMail, viewModel.personMail);

            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }
    }
}