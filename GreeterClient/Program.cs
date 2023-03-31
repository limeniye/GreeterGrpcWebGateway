using Contracts;
using Grpc.Net.Client;
// .. TODO :
// .. Console.ReadKey() ->
// .. Waiting for server initialization
Console.ReadKey();
const string host = "localhost";
const string port0 = "5001"; // greeterservice
const string port1 = "50050"; // nginx

try
{
    var handler = new HttpClientHandler();
    handler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
    var options = new GrpcChannelOptions() { HttpHandler = handler };

    var client = new Greeter.GreeterClient(GrpcChannel.ForAddress($"http://{host}:{port1}", options));
    var response = client.SayHello(new () { Name = "limeniye" });
    Console.WriteLine(response.Message);
}
catch(Exception ex)
{
    Console.WriteLine(ex);
}
Console.ReadLine();