using Contracts;
using Grpc.Core;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using ServiceStack;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;

// .. TODO :
// .. Console.ReadKey() ->
// .. Waiting for server initialization
Console.ReadKey();
const string host = "localhost";

#region Doesnt work with gRPC
//var handler = new HttpClientHandler();
//handler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
//var options = new GrpcChannelOptions()
//{
//    HttpHandler = handler,
//    Credentials = ChannelCredentials.Insecure
//};

//var channel = new Channel("localhost:50050", ChannelCredentials.Insecure);
//var client = new GrpcServices.GrpcServicesClient(channel);
//var response = client.GetHello(new Hello { Name = "limeniye" });
//Console.WriteLine(response.Result);
#endregion

try
{
    var client = InsecureProdClient(50050);
    //var client = SecureProdClient(50052);
    var response = await client.GetAsync(new Hello { Name = "limeniye" });
    Console.WriteLine(response.Result);
}
catch(Exception ex)
{
    Console.WriteLine(ex);
}
// SSL Nginx -> plain-text .NET Core
//var client = SecureProdClient(50051);

// SSL Nginx -> SSL .NET Core
//var client = SecureProdClient(50052);

Console.ReadLine();

static GrpcServiceClient SecureProdClient(int port) =>
    new GrpcServiceClient($"https://{host}:{port}",
        new X509Certificate2("server.crt"),
        GrpcUtils.AllowSelfSignedCertificatesFrom(host));

static GrpcServiceClient InsecureProdClient(int port)
{
    GrpcClientFactory.AllowUnencryptedHttp2 = true;
    return new GrpcServiceClient($"http://{host}:{port}");
}