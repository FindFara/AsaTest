using Application.Servises.Users.ViewModel;
using Domain.Repositories;
using MediatR;

namespace Application.Servises.Users.Query;

public class GetUser : IRequest<User_VM>
{
    public byte UserId { get; set; }
}
public class GetUserHandler : IRequestHandler<GetUser, User_VM>
{
    private readonly IUserRepository userRepository;

    public GetUserHandler(IUserRepository user)
    {
        this.userRepository = user;
    }
    public async Task<User_VM> Handle(GetUser request, CancellationToken cancellationToken)
    {
        var userDb = await userRepository.GetUserByIdAsync(request.UserId);
        var user = new User_VM()
        {
            FirstName = userDb.FirstName,
            LastName = userDb.LastName,
            Age = userDb.Age,
            Created = userDb.Created,
            LastModified = userDb.LastModified,
        };
        return user;
    }
}

