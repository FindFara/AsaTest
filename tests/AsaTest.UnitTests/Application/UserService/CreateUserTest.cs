using Application.Servises.Users.Command;
using Application.Servises.Users.Query;
using Application.Servises.Users.ViewModel;
using AutoFixture;
using Domain.Entities.Users;
using Domain.Repositories;
using FluentAssertions;
using FluentAssertions.Execution;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsaTest.UnitTests.Application.UserService
{
    public class CreateUserTest 
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly IFixture _fixture;


        public CreateUserTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _fixture = new Fixture();
        }

        [Fact]
        public async Task CreateUser_ShouldTrue_WhenCall()
        {
            // Arrange
            User_VM? userRequest = _fixture.Build<User_VM>()
                                                .With(temp => temp.LastName,"Fara")
                                                .Create();

            var request = new CreateUser { User = userRequest };

            _mockUserRepository.Setup(repo => repo.AddUserAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            var handler = new CreateUserHandler(_mockUserRepository.Object);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            result.Should().BeTrue();
        }
    }

}
