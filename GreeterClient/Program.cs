using Contracts;
using Grpc.Net.Client;
// .. TODO :
// .. Console.ReadKey() ->
// .. Waiting for server initialization
Console.ReadKey();
var channel = GrpcChannel.ForAddress("http://localhost:8080");
var client = new Greeter.GreeterClient(channel);
var response = client.SayHello(new() { Name = "limeniye" });
Console.WriteLine(response.Message);
Console.ReadLine();