using EventsApp.Server.Services.EventService;
using EventsApp.Server.Controllers;
using EventsApp.Shared;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.Extensions.Msal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using UnitTests.Fixtures;
using Azure;

namespace UnitTests.Systems.Controllers
{
    public class TestEventController
    {
        [Fact]
        public async Task GetEvents_OnSuccess_InvokesServiceExaclyOnce()
        {
            // Arrange
            var expectedResponse = new ServiceResponse<List<Event>> { Data = EventsFixture.GetTestEvents(), Success = true };

            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(service => service.GetEvents()).ReturnsAsync(expectedResponse);
            var controller = new EventController(mockEventService.Object);

            // Act
            var result = await controller.GetEvents();

            // Assert
            mockEventService.Verify(service => service.GetEvents(), Times.Once);
        }

        [Fact]
        public async Task GetEvents_ReturnsCorrectData()
        {
            // Arrange
            var expectedResponse = new ServiceResponse<List<Event>> { Data = EventsFixture.GetTestEvents(), Success = true };

            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(service => service.GetEvents()).ReturnsAsync(expectedResponse);
            var controller = new EventController(mockEventService.Object);

            // Act
            var result = await controller.GetEvents();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResponse, okResult.Value);
        }

        [Fact]
        public async Task Get_OnNoEventsFound_ReturnsNotFound()
        {
            // Arrange
            var mockEventService = new Mock<IEventService>();
            mockEventService
                .Setup(service => service.GetEvents())
                .Returns(Task.FromResult(
                    new ServiceResponse<List<Event>>()));

            var sut = new EventController(mockEventService.Object);

            // Act
            var result = await sut.GetEvents();

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetEvents_Returns_BadRequestResult_On_Error()
        {
            // Arrange
            var expectedError = "BadRequestResult";

            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(service => service.GetEvents())
                .ReturnsAsync(new ServiceResponse<List<Event>> { Success = false, Message = expectedError });

            var controller = new EventController(mockEventService.Object);

            // Act
            var result = await controller.GetEvents();

            // Assert
            var badRequestResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ServiceResponse<List<Event>>>(badRequestResult.Value);

            Assert.False(response.Success);
            Assert.Equal(expectedError, response.Message);

        }

        [Fact]
        public async Task GetEvents_Returns_EmptyList_When_No_Events_Available()
        {
            // Arrange
            var expectedResponse = new ServiceResponse<List<Event>> { Data = new List<Event>(), Success = true, Message = "" };

            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(service => service.GetEvents()).ReturnsAsync(expectedResponse);
            var controller = new EventController(mockEventService.Object);

            // Act
            var result = await controller.GetEvents();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ServiceResponse<List<Event>>>(okResult.Value);
            Assert.NotNull(response.Data);
            Assert.Empty(response.Data);
            Assert.True(response.Success);
            Assert.Equal("", response.Message);
        }

        [Fact]
        public async Task GetEvents_Returns_Correct_Http_Status_Code()
        {
            // Arrange
            var expectedResponse = new ServiceResponse<List<Event>> { Data = EventsFixture.GetTestEvents(), Success = true };

            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(service => service.GetEvents()).ReturnsAsync(expectedResponse);
            var controller = new EventController(mockEventService.Object);

            // Act
            var result = await controller.GetEvents();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(200, (result.Result as OkObjectResult).StatusCode);
        }

        [Fact]
        public async Task GetEvent_ReturnsCorrectData()
        {
            // Arrange
            int id = 1;
            var expectedResponse = new ServiceResponse<Event> { Data = EventsFixture.GetTestEvent(), Success = true };

            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(service => service.GetEvent(id)).ReturnsAsync(expectedResponse);
            var controller = new EventController(mockEventService.Object);

            // Act
            var result = await controller.GetEvent(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResponse, okResult.Value);
            Assert.Equal(expectedResponse.Data.Id, id);
            Assert.True(expectedResponse.Success);
        }

        [Fact]
        public async Task GetEvent_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingId = 123;
            var expectedResponse = new ServiceResponse<Event> { Data = null, Success = false, Message = "Event is not exist." };
            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(service => service.GetEvent(nonExistingId)).ReturnsAsync(expectedResponse);

            var controller = new EventController(mockEventService.Object);

            // Act
            var result = await controller.GetEvent(nonExistingId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var serviceResponse = Assert.IsType<ServiceResponse<Event>>(okResult.Value);
            Assert.Null(serviceResponse.Data);
            Assert.False(serviceResponse.Success);
            Assert.Equal("Event is not exist.", serviceResponse.Message);
        }

        [Fact]
        public async Task GetEvent_InvalidId_ReturnsBadRequest()
        {
            // Arrange
            int invalidId = -1;
            var expectedResponse = new ServiceResponse<Event> { Data = null, Success = false, Message = "Event is not exist." };
            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(service => service.GetEvent(invalidId)).ReturnsAsync(expectedResponse);

            var controller = new EventController(mockEventService.Object);

            // Act
            var result = await controller.GetEvent(invalidId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var serviceResponse = Assert.IsType<ServiceResponse<Event>>(okResult.Value);
            Assert.Null(serviceResponse.Data);
            Assert.False(serviceResponse.Success);
            Assert.Equal("Event is not exist.", serviceResponse.Message);
        }
    }
}
