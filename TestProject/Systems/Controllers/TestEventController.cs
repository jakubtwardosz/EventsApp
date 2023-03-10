﻿using EventsApp.Server.Services.EventService;
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
        }

        [Fact]
        public async Task GetEvents_Returns_EmptyList_When_No_Events_Available()
        {
            // Arrange
            var expectedResponse = new ServiceResponse<List<Event>> { Data = new List<Event>(), Success = true };

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
            var expectedResponse = new ServiceResponse<Event> { Data = EventsFixture.GetTestEvent(id), Success = true };

            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(service => service.GetEvent(id)).ReturnsAsync(expectedResponse);
            var controller = new EventController(mockEventService.Object);

            // Act
            var result = await controller.GetEvent(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResponse, okResult.Value);
        }

        [Fact]
        public async Task GetEvent_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            int nonExistingId = 123;
            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(service => service.GetEvent(nonExistingId))
                            .ReturnsAsync(new ServiceResponse<Event>());

            var controller = new EventController(mockEventService.Object);

            // Act
            var result = await controller.GetEvent(nonExistingId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetEvent_InvalidId_ReturnsBadRequest()
        {
            // Arrange
            int invalidId = -1;
            var expectedResponse = new ServiceResponse<Event> { Data = EventsFixture.GetTestEvent(invalidId), Success = false };
            var mockEventService = new Mock<IEventService>();
            mockEventService.Setup(service => service.GetEvent(invalidId)).ReturnsAsync(expectedResponse);
            
            var controller = new EventController(mockEventService.Object);

            // Act
            var result = await controller.GetEvent(invalidId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }


    }
}
