using Grpc.Core;
using Grpc.Net.Client;

// .. TODO :
// .. Console.ReadLine() ->
// .. Waiting for server initialization
Console.ReadLine();

var handler = new HttpClientHandler();
handler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
var options = new GrpcChannelOptions()
{
    HttpHandler = handler,
    Credentials = ChannelCredentials.Insecure
};

var channel = new Channel("localhost:5054", ChannelCredentials.Insecure);

//var client = new GrpcServices.GrpcServicesClient(channel);
//var response = client.GetHello(new MyGrpcProject.Hello { Name = "limeniye" });