using Application.Servises.Users.ViewModel;
using Domain.Entities.Users;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servises.Users.Command;

public class CreateUser : IRequest<bool>
{
    public User_VM User { get; set; } = new User_VM();
}
internal class GetUserHandler : IRequestHandler<CreateUser, bool>
{
    private readonly IUserRepository userRepository;

    public GetUserHandler(IUserRepository user)
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
        var addUser = userRepository.AddUserAsync(user);

        if (addUser.Status == TaskStatus.RanToCompletion)
        {
            return true;
        }
        return false;
    }
}
