using AutoMapper;
using CleanArchitectureTemplate.Core.Features.Register.Models;
using CleanArchitectureTemplate.Core.Features.Register;
using CleanArchitectureTemplate.Infrastructure.Abstractions.Repositories;
using CleanArchitectureTemplate.Infrastructure.Entities;
using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitectureTemplate.Unit.Tests.Features.Register
{
    [ExcludeFromCodeCoverage]
    public class RegisterHandlerTests
    {
        private Mock<IUserRepository> _userRepository;
        private Mock<IMapper> _mapper;

        private RegisterHandler _handler;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _mapper = new Mock<IMapper>();

            _handler = new RegisterHandler(_userRepository.Object, _mapper.Object);
        }

        [Test]
        public async Task RegisterUserTest()
        {
            var registerRequest = new RegisterCommand()
            {
                Username = "Test username",
                Password = "password123!",
            };
            var user = new UserAccount()
            {
                Username = "Test username",
                Password = "password123!",
            };

            _userRepository.Setup(x => x.CreateAsync(It.IsAny<UserAccount>())).ReturnsAsync(user);
            _mapper.Setup(x => x.Map<UserAccount>(It.IsAny<RegisterCommand>())).Returns(user);

            await _handler.Handle(registerRequest, new CancellationToken());
            _userRepository.Verify(x => x.CreateAsync(It.IsAny<UserAccount>()), Times.Once);
        }

        [Test]
        public void CheckNullArguments()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new RegisterHandler(null, _mapper.Object));
            Assert.Throws<ArgumentNullException>(() =>
                new RegisterHandler(_userRepository.Object, null));
        }
    }
}
