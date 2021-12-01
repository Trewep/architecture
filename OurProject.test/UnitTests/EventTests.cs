//System
using System;
using System.Threading.Tasks;

//Microsoft
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

//Moq
using Moq;

//OurProject
using OurProject.API.EventControllers;
using OurProject.API.Controllers;
using OurProject.API.Domains;
using OurProject.API.Ports;

//Xunit
using Xunit;

//Namespace
namespace OurProject.Test.UnitTests
{

    public class EventControllerUnitTest
    {
        //Mock = Library for faking databases and loggers
        private Mock<ILogger<EventController>> _mockedLogger = new Mock<ILogger<EventController>>();
        private Mock<IDatabase> _mockedDatabase = new Mock<IDatabase>();

        public EventControllerUnitTest()
        {
            _mockedDatabase.Reset();
            _mockedLogger.Reset();
        }

        //GetEventByID test
        [Fact]
        public async Task TestGetEventById_Success()
        {
            var rnd = new Random();
            var testId = rnd.Next(101);

            //Create mock up event
            var testEvent = new Event
            {
                Id = testId,
                eventName = "party in de bergen",
                eventDate = "12 december 2021",
                eventDescription = "party in de bergen voor alle medewerkers",
                eventMinAge = 18,
                eventMaxAge = 99,
                eventEnroll = true,
                eventEnrollDate = "1 december 2021",
                eventCounter = 3,
                eventPersonList = "Fluppe, Arthur, Dylan"
            };
            //Use GetEventById (METHOD) to test our mocked event
            //NO DB USING
            _mockedDatabase.Setup(x => x.GetEventById(testId)).Returns(Task.FromResult(testEvent));

            //Link controller
            var controller = new EventController(_mockedLogger.Object, _mockedDatabase.Object);
            //Get results from the controller
            var actualResult = await controller.GetEventById(testId) as OkObjectResult;

            //Check results
            Assert.Equal(200, actualResult.StatusCode);
            var viewModel = actualResult.Value as ReadEvent;
            Assert.Equal(testEvent.Id, viewModel.Id);
            Assert.Equal(testEvent.eventName, viewModel.eventName);
            Assert.Equal(testEvent.eventDate, viewModel.eventDate);
            Assert.Equal(testEvent.eventDescription, viewModel.eventDescription);
            Assert.Equal(testEvent.eventMinAge, viewModel.eventMinAge);
            Assert.Equal(testEvent.eventMaxAge, viewModel.eventMaxAge);
            Assert.Equal(testEvent.eventEnroll, viewModel.eventEnroll);
            Assert.Equal(testEvent.eventEnrollDate, viewModel.eventEnrollDate);
            Assert.Equal(testEvent.eventCounter, viewModel.eventCounter);
            Assert.Equal(testEvent.eventPersonList, viewModel.eventPersonList);

            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }

        //GetAllEvents test
        [Fact]
        public async Task TestGetAllEvents_Success()
        {
            var rnd = new Random();
            var testId = rnd.Next(101);

            //Create mock up event
            var testEvent = new Event
            {
                Id = testId,
                eventName = "party in de bergen",
                eventDate = "12 december 2021",
                eventDescription = "party in de bergen voor alle medewerkers",
                eventMinAge = 18,
                eventMaxAge = 99,
                eventEnroll = true,
                eventEnrollDate = "1 december 2021",
                eventCounter = 3,
                eventPersonList = "Fluppe, Arthur, Dylan"
            };
            //Use GetEventById (METHOD) to test our mocked event
            //NO DB USING
            _mockedDatabase.Setup(x => x.GetAllEvents(testId)).Returns(Task.FromResult(testEvent));

            //Link controller
            var controller = new EventController(_mockedLogger.Object, _mockedDatabase.Object);
            //Get results from the controller
            var actualResult = await controller.GetAllEvents(testId) as OkObjectResult;

            //Check results
            Assert.Equal(200, actualResult.StatusCode);
            var viewModel = actualResult.Value as ReadEvent;
            Assert.Equal(testEvent.Id, viewModel.Id);
            Assert.Equal(testEvent.eventName, viewModel.eventName);
            Assert.Equal(testEvent.eventDate, viewModel.eventDate);
            Assert.Equal(testEvent.eventDescription, viewModel.eventDescription);
            Assert.Equal(testEvent.eventMinAge, viewModel.eventMinAge);
            Assert.Equal(testEvent.eventMaxAge, viewModel.eventMaxAge);
            Assert.Equal(testEvent.eventEnroll, viewModel.eventEnroll);
            Assert.Equal(testEvent.eventEnrollDate, viewModel.eventEnrollDate);
            Assert.Equal(testEvent.eventCounter, viewModel.eventCounter);
            Assert.Equal(testEvent.eventPersonList, viewModel.eventPersonList);

            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }

        //PersistEvent test
        [Fact]
        public async Task TestPersistEvent_Success()
        {
            var rnd = new Random();
            var testId = rnd.Next(101);

            //Create mock up event
            var testEvent = new Event
            {
                Id = 1,
                eventName = "party in de bergen 2.0",
                eventDate = "12 januari 2022",
                eventDescription = "party in de bergen voor alle medewerkers maar beter en groter",
                eventMinAge = 18,
                eventMaxAge = 99,
                eventEnroll = true,
                eventEnrollDate = "28 december 2021",
                eventCounter = 3,
                eventPersonList = "Fluppe, Arthur, Dylan"
            };
            //Use GetEventById (METHOD) to test our mocked event
            //NO DB USING
            _mockedDatabase.Setup(x => x.PersistEvent(testId)).Returns(Task.FromResult(testEvent));

            //Link controller
            var controller = new EventController(_mockedLogger.Object, _mockedDatabase.Object);
            //Get results from the controller
            var actualResult = await controller.PersistEvent(testId) as OkObjectResult;

            //Check results
            Assert.Equal(200, actualResult.StatusCode);
            var viewModel = actualResult.Value as ReadEvent;
            Assert.Equal(testEvent.Id, viewModel.Id);
            Assert.Equal(testEvent.eventName, viewModel.eventName);
            Assert.Equal(testEvent.eventDate, viewModel.eventDate);
            Assert.Equal(testEvent.eventDescription, viewModel.eventDescription);
            Assert.Equal(testEvent.eventMinAge, viewModel.eventMinAge);
            Assert.Equal(testEvent.eventMaxAge, viewModel.eventMaxAge);
            Assert.Equal(testEvent.eventEnroll, viewModel.eventEnroll);
            Assert.Equal(testEvent.eventEnrollDate, viewModel.eventEnrollDate);
            Assert.Equal(testEvent.eventCounter, viewModel.eventCounter);
            Assert.Equal(testEvent.eventPersonList, viewModel.eventPersonList);

            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }

        //DeleteEvent test
        [Fact]
        public async Task TestDeleteEvent_Success()
        {
            var rnd = new Random();
            var testId = rnd.Next(101);

            //Create mock up event
            var testEvent = new Event
            {
                Id = 1,
                eventName = "party in de bergen 2.0",
                eventDate = "12 januari 2022",
                eventDescription = "party in de bergen voor alle medewerkers maar beter en groter",
                eventMinAge = 18,
                eventMaxAge = 99,
                eventEnroll = true,
                eventEnrollDate = "28 december 2021",
                eventCounter = 3,
                eventPersonList = "Fluppe, Arthur, Dylan"
            };
            //Use GetEventById (METHOD) to test our mocked event
            //NO DB USING
            _mockedDatabase.Setup(x => x.DeleteEvent(testId)).Returns(Task.FromResult(testEvent));

            //Link controller
            var controller = new EventController(_mockedLogger.Object, _mockedDatabase.Object);
            //Get results from the controller
            var actualResult = await controller.DeleteEvent(testId) as OkObjectResult;

            //Check results
            Assert.Equal(200, actualResult.StatusCode);
            var viewModel = actualResult.Value as CreateEvent;
            Assert.Equal(testEvent.Id, viewModel.Id);
            Assert.Equal(testEvent.eventName, viewModel.eventName);
            Assert.Equal(testEvent.eventDate, viewModel.eventDate);
            Assert.Equal(testEvent.eventDescription, viewModel.eventDescription);
            Assert.Equal(testEvent.eventMinAge, viewModel.eventMinAge);
            Assert.Equal(testEvent.eventMaxAge, viewModel.eventMaxAge);
            Assert.Equal(testEvent.eventEnroll, viewModel.eventEnroll);
            Assert.Equal(testEvent.eventEnrollDate, viewModel.eventEnrollDate);
            Assert.Equal(testEvent.eventCounter, viewModel.eventCounter);

            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }
    }
}