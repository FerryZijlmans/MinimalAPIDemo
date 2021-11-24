using Microsoft.AspNetCore.Mvc;
using MinimalApiDemo.Data;
using MinimalApiDemo.EndpointDefinition;
using MinimalApiDemo.model;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Demotest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
          var target = new UserEndpointDefinition();
          var userMock = new List<User>() { new User() { Username= "HERMAN"} };
          var serviceMock = new Mock<IUserService>(MockBehavior.Strict);
          serviceMock.Setup(x => x.GetUsers()).Returns(userMock);

          var result = target.GetUsers(serviceMock.Object);

          Assert.True(result.GetOkObjectResultValue<List<User>>() is not null);

        }
    }
}
