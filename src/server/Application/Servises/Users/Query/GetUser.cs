using Application.Servises.Users.ViewModel;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Servises.Users.Query;

public class GetUser : IRequest<User_VM>
{
    public byte UserId { get; set; }
}
public class GetUserHandler : IRequestHandler<GetUser, User_VM>
{
    private readonly IUserRepository user;

    public GetUserHandler(IUserRepository user)
    {
        this.user = user;
    }
    public Task<User_VM> Handle(GetUser request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

