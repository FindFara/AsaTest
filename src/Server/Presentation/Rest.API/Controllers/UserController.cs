using Application.Servises.Users.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Rest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUser model)
        {
            var result = await mediator.Send(model);
            if (result)
            {
                return Ok("User added successfully");
            }
            else
            {
                return BadRequest("Error adding user");
            }

        }
    }
}
