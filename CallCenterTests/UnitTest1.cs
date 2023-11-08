using CallCenter.Controllers;
using CallCenter.Models;
using CallCenter.Types;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using CarrierPidgeon;

public class CallControllerTests
{
    private readonly ICallRepository _callRepository;
    private readonly ApplicationContext _applicationContext;

    public CallControllerTests(ICallRepository callRepository, ApplicationContext applicationContext)
    {
        _callRepository = callRepository;
        _applicationContext = applicationContext;
    }

    [Fact]
    public async Task AddCall_ValidModel_ReturnsOkResult()
    {
        // Arrange
        Mock<ICallRepository> callRepositoryMock = new Mock<ICallRepository>();
        CallController controller = new CallController(callRepositoryMock.Object);

        AddCallRequest addCallRequest = new AddCallRequest
        {
            ClientId = Guid.NewGuid(),
            StartTime = DateTime.Now,
            EmployeeId = Guid.NewGuid(),
            WorkId = Guid.NewGuid()
        };

        callRepositoryMock.Setup(repo => repo.AddCall(It.IsAny<Call>())).Returns(Task.CompletedTask);

        // Act
        var result = await controller.AddCall(addCallRequest);

        // Assert
        callRepositoryMock.Verify(repo => repo.AddCall(It.IsAny<Call>()), Times.Once);

        Assert.IsType<OkResult>(result);
    }

}
