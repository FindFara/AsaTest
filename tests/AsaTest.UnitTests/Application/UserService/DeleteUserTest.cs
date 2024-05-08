using Application.Servises.Users.Command;
using Application.Servises.Users.ViewModel;
using AutoFixture;
using Domain.Entities.Users;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace AsaTest.UnitTests.Application.UserService;

public class DeleteUserTest
{
    #region Properties
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly IFixture _fixture;
    #endregion

    #region Ctor
    public DeleteUserTest()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _fixture = new Fixture();
    }

    #endregion

    #region Facts
    [Fact]
    public async Task DeleteUser_ShouldReturnTrue_WhenCall()
    {
        // Arrange
        User_VM? userRequest = _fixture.Build<User_VM>()
                                            .With(temp => temp.LastName, "Fara")
                                            .Create();

        var request = new DeleteUser { User = userRequest };

        _mockUserRepository.Setup(repo => repo.AddUserAsync(It.IsAny<User>()))
            .Returns(Task.CompletedTask);

        var handler = new DeleteUserHandler(_mockUserRepository.Object);

        //Act
        var result = await handler.Handle(request, CancellationToken.None);

        //Assert
        result.Should().BeTrue();
    }
    #endregion
}
