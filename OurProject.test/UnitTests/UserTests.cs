//System
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

//Microsoft
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

//Moq
using Moq;

//OurProject
using OurProject.API.UserControllers;
using OurProject.API.Controllers;
using OurProject.API.Domains;
using OurProject.API.Ports;

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



            _mockedDatabase.Setup(x => x.GetUserById(testId)).Returns(Task.FromResult(testUser));

            var controller = new UserController(_mockedLogger.Object, _mockedDatabase.Object);
            var actualResult = (OkObjectResult)await controller.GetUserById(testId);

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
            var testId = 9;

            //Create mock up user
            var testUser = new User
            {
                Id = testId,
                personName = "Fluppe",
                personBirth = "9 mei 1998",
                personMail = "fluppevanmeerbeeck@gmail.com",
            };
            User[] testUserArray = { testUser };
            _mockedDatabase.Setup(x => x.GetAllUser(testId.ToString())).Returns(Task.FromResult(Array.AsReadOnly(testUserArray)));

            var controller = new UserController(_mockedLogger.Object, _mockedDatabase.Object);

            var actualResult = (OkObjectResult)await controller.GetAllUser(testId.ToString());

            //Check results
            Assert.Equal(200, actualResult.StatusCode);
            var viewModels = (List<ReadUser>)actualResult.Value;
            Assert.Single(viewModels);
            var viewModel = viewModels[0];
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

            var testCreateUser = new CreateUser
            {
                Id = 2,
                personName = "Arthur",
                personBirth = "12 october 2002",
                personMail = "arthurdelophem3@gmail.com",
            };

            _mockedDatabase.Setup(x => x.PersistUser(It.IsAny<User>())).Returns(Task.FromResult(testUser));
            _mockedDatabase.Setup(x => x.PersistUser(It.IsAny<User>())).Returns(Task.FromResult(testUser));

            var controller = new UserController(_mockedLogger.Object, _mockedDatabase.Object);

            var actualResult = (CreatedAtActionResult)await controller.PersistUser(testCreateUser);

            //Check results
            Assert.True(true);


            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }

        [Fact]
        public async Task TestDeleteById_Success()
        {
            var rnd = new Random();
            var testId = rnd.Next(101);

            //Create mock up user
            var testUser = new User
            {
                Id = testId,
                personName = "Arthur",
                personBirth = "12 october 2002",
                personMail = "arthurdelophem3@gmail.com",
            };

            _mockedDatabase.Setup(x => x.DeleteUser(testId)).Returns(Task.FromResult(testUser));
            _mockedDatabase.Setup(x => x.GetUserById(testUser.Id)).Returns(Task.FromResult(testUser));

            var controller = new UserController(_mockedLogger.Object, _mockedDatabase.Object);

            var actualResult = (NoContentResult)await controller.DeleteById(testId);

            //Check results
            Assert.True(true);

            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }
    }
}