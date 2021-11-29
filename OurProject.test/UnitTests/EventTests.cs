//System
using System;
using System.Threading.Tasks;

//Microsoft
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

//Moq
using Moq;

//OurProject
using OurProject.API.Controllers;
using OurProject.API.Ports;
using OurProject.API.Domain;

//Xunit
using Xunit;

//Namespace
namespace OurProject.Test.UnitTests
{
    public class EventControllerUnitTest
    {
        //Mock is a library that allows us to fake databases and loggers
        private Mock<ILogger<EventController>> _mockedLogger = new Mock<ILogger<EventController>>();
        private Mock<IDatabase> _mockedDatabase = new Mock<IDatabase>();

        public EventControllerUnitTest()
        {
            _mockedDatabase.Reset();
            _mockedLogger.Reset();
        }

        //All GetEventByID tests
        [Fact]
        public async Task TestGetEventById_Success()
        {
            var rnd = new Random();
            var testId = rnd.Next(101);

            //Create mock up event
            var testEvent = new Event
            {
                Id = testId,
                Name = "Thomas More Student Lift off",
                Description = "Student Lift Off",
                MinAge = 2,
                MaxAge = 5,
                StartDate = Convert.ToDateTime("2018-11-05 11:38:56.307"),
                EndDate = Convert.ToDateTime("2019-11-05 11:38:56.307")
            };


            //Call the method GetEventById to test our mocked event, no db calls
            _mockedDatabase.Setup(x => x.GetEventById(testId)).Returns(Task.FromResult(testEvent));

            //Link controller
            var controller = new EventController(_mockedLogger.Object, _mockedDatabase.Object);
            //Get results from the controller
            var actualResult = await controller.GetEventById(testId) as OkObjectResult;

            //Check results
            Assert.Equal(200, actualResult.StatusCode);
            var viewModel = actualResult.Value as ViewEvent;
            Assert.Equal(testEvent.Id, viewModel.Id);
            Assert.Equal(testEvent.Name, viewModel.Name);
            Assert.Equal(testEvent.Description, viewModel.Description);
            Assert.Equal(testEvent.MinAge, viewModel.MinAge);
            Assert.Equal(testEvent.MaxAge, viewModel.MaxAge);
            Assert.Equal(testEvent.StartDate, viewModel.StartDate);
            Assert.Equal(testEvent.EndDate, viewModel.EndDate);
            Assert.Equal(testEvent.StreetName, viewModel.StreetName);
            Assert.Equal(testEvent.StreetNumber, viewModel.StreetNumber);
            Assert.Equal(testEvent.City, viewModel.City);
            Assert.Equal(testEvent.Country, viewModel.Country);

            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }

        [Fact]
        public async Task TestGetEventById_DoesntExist()
        {
            var rnd = new Random();
            var testId = rnd.Next(101);

            //Create mock up event
            var testEvent = new Event
            {
                Id = testId,
                Name = "EpicBigFestival",
                Description = "Festival is big epic",
                MinAge = 2,
                MaxAge = 5,
                StartDate = Convert.ToDateTime("2018-11-05 11:38:56.307"),
                EndDate = Convert.ToDateTime("2019-11-05 11:38:56.307"),
                StreetName = "Bruul",
                StreetNumber = 2,
                City = "London",
                Country = "England"
            };

            _mockedDatabase.Setup(x => x.GetEventById(testId)).Returns(Task.FromResult(null as Event)); //Doesn't return the found event but returns null

            //Link the EventController
            var controller = new EventController(_mockedLogger.Object, _mockedDatabase.Object);

            //Check the results
            var result = await new EventController(_mockedLogger.Object, _mockedDatabase.Object).GetEventById(testId);
            Assert.IsType<NotFoundResult>(result);

            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }

        [Fact]
        public async Task TestGetEventById_ErrorOnRetrievalAsync()
        {
            var rnd = new Random();
            var testId = rnd.Next(101);

            //Create mock up event
            var testEvent = new Event
            {
                Id = testId,
                Name = "EpicBigFestival",
                Description = "Festival is big epic",
                MinAge = 2,
                MaxAge = 5,
                StartDate = Convert.ToDateTime("2018-11-05 11:38:56.307"),
                EndDate = Convert.ToDateTime("2019-11-05 11:38:56.307"),
                StreetName = "Bruul",
                StreetNumber = 2,
                City = "London",
                Country = "England"
            };

            _mockedDatabase.Setup(x => x.GetEventById(testId)).ThrowsAsync(new Exception("Cowboy Bebop"));

            //Link the EventController
            var result = await new EventController(_mockedLogger.Object, _mockedDatabase.Object).GetEventById(testId);

            //Check the results
            Assert.IsType<BadRequestObjectResult>(result);
            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }

        //All getEventByAgeRange tests
        [Fact]
        public async Task TestGetEventsByAgeRange_Success()
        {
            var minAge = 2;
            var maxAge = 18;

            var testAge = 5;

            //Create mock up event
            var testEvent = new Event
            {
                Id = 1,
                Name = "EpicBigFestival",
                Description = "Festival is big epic",
                MinAge = minAge,
                MaxAge = maxAge,
                StartDate = Convert.ToDateTime("2018-11-05 11:38:56.307"),
                EndDate = Convert.ToDateTime("2019-11-05 11:38:56.307"),
                StreetName = "Bruul",
                StreetNumber = 2,
                City = "London",
                Country = "England"
            };


            //Call the method GetEventsByAgeRange to test our mocked event, no db calls
            _mockedDatabase.Setup(x => x.GetEventsByAgeRange(testAge));

            //Link controller
            var controller = new EventController(_mockedLogger.Object, _mockedDatabase.Object);
            //Get results from the controller
            var actualResult = await controller.GetEventsByAgeRange(testAge) as OkObjectResult;

            //Check results
            Assert.Equal(200, actualResult.StatusCode);
            //result returns an array of results not singular result, how to check if multiple results are correct *SEE BELOW*
            //Does pass the test with 200 not with notFound or badRequest 

            /*
            var viewModel = actualResult.Value as ViewEvent;
            Assert.Equal(testEvent.Id, viewModel.Id);
            Assert.Equal(testEvent.Name, viewModel.Name);
            Assert.Equal(testEvent.Description, viewModel.Description);
            Assert.Equal(testEvent.MinAge, viewModel.MinAge);
            Assert.Equal(testEvent.MaxAge, viewModel.MaxAge);
            Assert.Equal(testEvent.StartDate, viewModel.StartDate);
            Assert.Equal(testEvent.EndDate, viewModel.EndDate);
            Assert.Equal(testEvent.StreetName, viewModel.StreetName);
            Assert.Equal(testEvent.StreetNumber, viewModel.StreetNumber);
            Assert.Equal(testEvent.City, viewModel.City);
            Assert.Equal(testEvent.Country, viewModel.Country);
            */

            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }

        [Fact]
        public async Task TestGetEventsByAgeRange_DoesntExist()
        {
            var minAge = 2;
            var maxAge = 18;

            var testAge = 5;

            //Create mock up event
            var testEvent = new Event
            {
                Id = 1,
                Name = "EpicBigFestival",
                Description = "Festival is big epic",
                MinAge = minAge,
                MaxAge = maxAge,
                StartDate = Convert.ToDateTime("2018-11-05 11:38:56.307"),
                EndDate = Convert.ToDateTime("2019-11-05 11:38:56.307"),
                StreetName = "Bruul",
                StreetNumber = 2,
                City = "London",
                Country = "England"
            };

            _mockedDatabase.Setup(x => x.GetEventsByAgeRange(testAge)).Returns(Task.FromResult(null as Event[])); ; //Doesn't return the found event but returns null

            //Link the EventController
            var controller = new EventController(_mockedLogger.Object, _mockedDatabase.Object);

            //Check the results
            var result = await new EventController(_mockedLogger.Object, _mockedDatabase.Object).GetEventsByAgeRange(testAge);
            Assert.IsType<NotFoundResult>(result);

            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }

        [Fact]
        public async Task TestGetEventsByAgeRange_ErrorOnRetrievalAsync()
        {
            var minAge = 2;
            var maxAge = 18;

            var testAge = 5;

            //Create mock up event
            var testEvent = new Event
            {
                Id = 1,
                Name = "EpicBigFestival",
                Description = "Festival is big epic",
                MinAge = minAge,
                MaxAge = maxAge,
                StartDate = Convert.ToDateTime("2018-11-05 11:38:56.307"),
                EndDate = Convert.ToDateTime("2019-11-05 11:38:56.307"),
                StreetName = "Bruul",
                StreetNumber = 2,
                City = "London",
                Country = "England"
            };

            _mockedDatabase.Setup(x => x.GetEventsByAgeRange(testAge)).ThrowsAsync(new Exception("Cowboy Bebop"));

            //Link the EventController
            var result = await new EventController(_mockedLogger.Object, _mockedDatabase.Object).GetEventsByAgeRange(testAge);

            //Check the results
            Assert.IsType<BadRequestObjectResult>(result);
            _mockedLogger.VerifyAll();
            _mockedDatabase.VerifyAll();
        }
    }
}