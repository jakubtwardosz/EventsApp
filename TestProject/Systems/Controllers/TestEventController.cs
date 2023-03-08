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

namespace UnitTests.Systems.Controllers
{
    public class TestEventController
    {
        [Fact]
        public async Task Get_OnSuccess_InvokesEventServiceExaclyOnce()
        {
            // Arrange
            var mockEventService = new Mock<IEventService>();
            mockEventService
                .Setup(service => service.GetEvents())
                .Returns(Task.FromResult(
                    new ServiceResponse<List<Event>>
                    {
                        Data = new List<Event>(),
                        Success = true
                    }));

            var sut = new EventController(mockEventService.Object);

            // Act

            var result = await sut.GetEvents();

            mockEventService.Verify(service => service.GetEvents(), Times.Once);
        }
    }
}
