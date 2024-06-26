﻿using Application.Servises.Users.Query;
using Application.Servises.Users.ViewModel;
using AutoFixture;
using Domain.Entities.Users;
using Domain.Repositories;
using Moq;

namespace AsaTest.UnitTests.Application.UserService;

public class GetUserTest
{
    #region Properties
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly IFixture _fixture;
    #endregion

    #region Ctor
    public GetUserTest()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _fixture = new Fixture();
    }
    #endregion

    #region Facts
    [Fact]
    public async Task GetUser_ShouldReturnTypeUser_WhenCall()
    {
        // Arrange
        byte userRequest = 123;

        var request = new GetUser { UserId = userRequest };

        _mockUserRepository.Setup(repo => repo.GetUserByIdAsync(userRequest))
            .Returns(Task.FromResult(new User
            {
                Id = userRequest,
                FirstName = "Fara",
                LastName = "Test",
                Age = 1,
                Created = new DateTime(2020, 02, 2)
            }));

        var handler = new GetUserHandler(_mockUserRepository.Object);

        //Act
        var result = await handler.Handle(request, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<User_VM>(result);
        Assert.Equal(userRequest, result.Id);
    }
    #endregion
}
