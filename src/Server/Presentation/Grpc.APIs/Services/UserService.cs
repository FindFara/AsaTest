using Application.Servises.Users.Command;
using Application.Servises.Users.Query;
using Application.Servises.Users.ViewModel;
using Grpc.APIs;
using Grpc.Core;
using MediatR;

namespace Grpc.APIs.Services
{
    public class UserServices : UserService.UserServiceBase
    {
        private readonly IMediator mediator;

        public UserServices(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public override async Task<Response> CreateUser(User request, ServerCallContext context)
        {
            var user = new User_VM()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
            };
            await mediator.Send(new CreateUser { User = user });
            return new Response { Success = true };
        }

        public override async Task<Response> UpdateUser(User request, ServerCallContext context)
        {
            var user = new User_VM()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
            };
            await mediator.Send(new UpdateUser { User = user });
            return new Response { Success = true };

        }
        public override async Task<Response> DeleteUser(User request, ServerCallContext context)
        {
            var user = new User_VM()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Age = request.Age,
            };
            await mediator.Send(new DeleteUser { User = user });
            return new Response { Success = true };
        }
        public override async Task<User> GetUser(GetUserRequest request, ServerCallContext context)
        {
            byte id = Convert.ToByte(request.Id);
            var user = await mediator.Send(new GetUser { UserId = id });
            var userResponse = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
            };
            return userResponse;
        }
    }
}
