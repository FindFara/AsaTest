using Grpc.API;
using Grpc.Net.Client;
string responseMessage = "";
try
{
    var channel = GrpcChannel.ForAddress("http://localhost:5125");
    var greeterClient = new Greeter.GreeterClient(channel);
    var request = new HelloRequest { Name = "Fara" };
    var response = await greeterClient.SayHelloAsync(request);
    responseMessage = response.Message;
    Console.WriteLine(responseMessage);
}
catch (Exception ex)
{
    Console.WriteLine("Error");
}