using Contracts;
using Grpc.Core;
using Grpc.Net.Client;
// .. TODO :
// .. Console.ReadKey() ->
// .. Waiting for server initialization
Console.ReadKey();
AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
var httpClientHandler = new HttpClientHandler();
httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
{
    if (cert != null && cert.Issuer.Equals("CN=localhost"))
        return true;
    return errors == System.Net.Security.SslPolicyErrors.None;
};

var channel = GrpcChannel.ForAddress("https://localhost:5010", new GrpcChannelOptions() 
{
    HttpClient = new HttpClient(httpClientHandler),
    Credentials = ChannelCredentials.SecureSsl
});
var client = new Greeter.GreeterClient(channel);
var response = client.SayHello(new() { Name = "limeniye" });
Console.WriteLine(response.Message);
Console.ReadLine();