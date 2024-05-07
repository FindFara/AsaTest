using Grpc.APIs;
using Grpc.Net.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/AddUser", async (UserCRUD userService) =>
{
    bool success = await userService.AddUser(userService.firstName, userService.lastName, userService.age);

    if (success)
    {
        return Results.Ok("User added successfully");
    }
    else
    {
        return Results.BadRequest("Error adding user");
    }
});
app.Run();
internal record UserCRUD(string firstName, string lastName, int age)
{
    public async Task<bool> AddUser(string firstNam, string lastName, int age)
    {
        try
        {
            GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5010");
            UserService.UserServiceClient userClient = new UserService.UserServiceClient(channel);
            var request = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };
            var response = await userClient.CreateUserAsync(request);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}