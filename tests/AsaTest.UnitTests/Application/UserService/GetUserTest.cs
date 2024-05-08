using Application.Servises.Users.Command;
using Application.Servises.Users.Query;
using Application.Servises.Users.ViewModel;
using AutoFixture;
using Domain.Common;
using Domain.Entities.Users;
using Domain.Repositories;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsaTest.UnitTests.Application.UserService
{
    public class GetUserTest
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly IFixture _fixture;


        public GetUserTest()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GetUser_ShouldReturnTypeUser_WhenCall()
        {
            // Arrange
            byte userRequest = 123;

            var request = new GetUser {UserId = userRequest };
            var mockBaseEntity = new Mock<BaseEntity<byte>>();
            mockBaseEntity.SetupGet(x => x.Id).Returns(userRequest);

            _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userRequest))
                .Returns(Task.FromResult(new User
                {
                    Id = mockBaseEntity,
                    Age = 1,
                    Created = new DateTime(2020,02,2)
                })); 

            var handler = new GetUserHandler(_mockUserRepository.Object);

            //Act
            var result = await handler.Handle(request, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<User_VM>(result); 
            Assert.Equal(userRequest, result.Id);
        }
    }
}
