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

namespace UnitTests.Systems.Controllers
{
    public class TestEventController
    {
        [Fact]
        public async Task GetEvents_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var mockEventService = new Mock<IEventService>();
            mockEventService
                .Setup(service => service.GetEvents())
                .Returns(Task.FromResult(
                    new ServiceResponse<List<Event>>
                    {
                        Data = EventsFixture.GetTestEvents(),
                        Success = true
                    }));

            var sut = new EventController(mockEventService.Object);

            // Act
            var result = await sut.GetEvents();

            //Assert
            result.Should().BeOfType<ActionResult<ServiceResponse<List<Event>>>>();
            result.Result.Should().BeOfType<OkObjectResult>();

            ((OkObjectResult)result.Result).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetEvents_OnSuccess_InvokesServiceExaclyOnce()
        {
            // Arrange
            var mockEventService = new Mock<IEventService>();
            mockEventService
                .Setup(service => service.GetEvents())
                .Returns(Task.FromResult(
                    new ServiceResponse<List<Event>>
                    {
                        Data = EventsFixture.GetTestEvents(),
                        Success = true
                    }));

            var sut = new EventController(mockEventService.Object);

            // Act
            var result = await sut.GetEvents();

            // Assert
            mockEventService.Verify(service => service.GetEvents(), Times.Once);
        }

        [Fact]
        public async Task GetEvents_OnSuccess_ReturnsListOfUsers()
        {
            // Arrange
            var mockEventService = new Mock<IEventService>();
            mockEventService
                .Setup(service => service.GetEvents())
                .Returns(Task.FromResult(
                    new ServiceResponse<List<Event>>
                    {
                        Data = EventsFixture.GetTestEvents(),
                        Success = true
                    }));

            var sut = new EventController(mockEventService.Object);

            // Act
            var result = await sut.GetEvents();

            // Arrange
            result.Should().BeOfType<ActionResult<ServiceResponse<List<Event>>>>();
            var objectResult = (OkObjectResult)result.Result;
            objectResult.Value.Should().BeOfType<ServiceResponse<List<Event>>>();
        }



    }
}
