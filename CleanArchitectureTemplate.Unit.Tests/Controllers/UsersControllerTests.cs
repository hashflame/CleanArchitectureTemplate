using AutoMapper;
using CleanArchitectureTemplate.Core.Features.Register.Models;
using CleanArchitectureTemplate.Web.Controllers;
using CleanArchitectureTemplate.Web.Models.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitectureTemplate.Unit.Tests.Controllers
{
    [ExcludeFromCodeCoverage]
    public class UsersControllerTests
    {
        private Mock<IMediator> _mediator;
        private Mock<IMapper> _mapper;
        private UsersController _usersController;

        [SetUp]
        public void Setup()
        {
            _mediator = new Mock<IMediator>();
            _mapper = new Mock<IMapper>();

            _usersController = new UsersController(_mediator.Object, _mapper.Object);
        }

        [Test]
        public async Task RegisterTest()
        {
            var registerRequest = new RegisterRequest()
            {
                Username = "Test username",
                Password = "Password123Q!"
            };
            _mapper.Setup(x => x.Map<RegisterCommand>(It.IsAny<RegisterRequest>()))
                .Returns(new RegisterCommand()
                {
                    Username = "Test username",
                    Password = "Password123Q!"
                });

            var actual = await _usersController.Register(registerRequest) as OkObjectResult;
            _mapper.Verify(x => x.Map<RegisterCommand>(It.IsAny<RegisterRequest>()), Times.Once);
            _mediator.Verify(x => x.Send(It.IsAny<RegisterCommand>(), default), Times.Once);
            Assert.That(actual.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
        }

        [Test]
        public void CheckNullArguments()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new UsersController(null, _mapper.Object));
            Assert.Throws<ArgumentNullException>(() =>
                new UsersController(_mediator.Object, null));
        }
    }
}
