using Contracts;
using Grpc.Core;
// .. TODO :
// .. Console.ReadKey() ->
// .. Waiting for server initialization
Console.ReadKey();
const string host = "localhost";
const string greeterservicePort = "5001"; // greeterservice
const string nginxPort = "50050"; // nginx
const int envoyPort = 8811; // envoy

try
{
    //var handler = new HttpClientHandler();
    //handler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
    //var options = new GrpcChannelOptions() { HttpHandler = handler };

    var client = new Greeter.GreeterClient(new Channel(host, envoyPort, ChannelCredentials.Insecure, new List<ChannelOption> 
    {
        new ChannelOption("grpc.enable_http_proxy", 0) 
    }));
    var response = client.SayHello(new () { Name = "limeniye" });
    Console.WriteLine(response.Message);
}
catch(Exception ex)
{
    Console.WriteLine(ex);
}
Console.ReadLine();