using Application.Servises.Users.ViewModel;
using Domain.Entities.Users;
using Domain.Repositories;
using MediatR;

namespace Application.Servises.Users.Command;

public class CreateUser : IRequest<bool>
{
    public User_VM User { get; set; } = new User_VM();
}
public class CreateUserHandler : IRequestHandler<CreateUser, bool>
{
    private readonly IUserRepository userRepository;

    public CreateUserHandler(IUserRepository user)
    {
        userRepository = user;
    }
    public async Task<bool> Handle(CreateUser request, CancellationToken cancellationToken)
    {
        var user = new User()
        {
            FirstName = request.User.FirstName,
            LastName = request.User.LastName,
            Age = request.User.Age,
            Created = request.User.Created,
            LastModified = request.User.LastModified,
        };
        try
        {
            await userRepository.AddUserAsync(user);
            return true;
        }
        catch (Exception ex)
        {
            return false; 
        }

    }
}
