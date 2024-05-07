using Grpc.APIs.Services;
using Infrastructure;
using Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserServices>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
