using CallCenter.Controllers;
using CallCenter.Models;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class CallControllerTests
{
    [Fact]
    public async Task AddCall_ValidModel_ReturnsOkResult()
    {
        // Arrange
        var callRepositoryMock = new Mock<CallRepository>(MockBehavior.Loose);

        var controller = new CallController(callRepositoryMock.Object);
        var addCallRequest = new AddCallRequest
        {
            ClientId = Guid.NewGuid(),
            EmployeeId = Guid.NewGuid(),
            WorkId = Guid.NewGuid()
        };

        // Act
        var result = await controller.AddCall(addCallRequest);

        // Assert
        Assert.IsType<OkResult>(result);
        callRepositoryMock.Verify(mock => mock.AddCall(It.IsAny<Call>()), Times.Once);
    }

    // Similar tests for other endpoints like UpdateCall, GetCallByCallId, GetCallByCallClientId, GetCallByCallWorkId
}
