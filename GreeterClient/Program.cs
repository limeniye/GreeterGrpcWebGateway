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
    //if (cert != null && cert.Issuer.Equals("CN=localhost"))
    //    return true;
    //return errors == System.Net.Security.SslPolicyErrors.None;

    return true;
};

var sslCredentials = GetSslClientCredentials();

var channel = new Channel("localhost", 8080, sslCredentials);

//var channel = GrpcChannel.ForAddress("https://localhost:8080", new GrpcChannelOptions()
//{
//    HttpClient = new HttpClient(httpClientHandler),
//    Credentials = channelCredentials,
//});
var client = new Greeter.GreeterClient(channel);
var response = client.SayHello(new() { Name = "limeniye" });
Console.WriteLine(response.Message);
Console.ReadLine();




SslCredentials GetSslClientCredentials()
{
    var caCert = File.ReadAllText("M:\\GreeterGrpcWebGateway\\GreeterClient\\certs\\ca.crt");
    var cert = File.ReadAllText("M:\\GreeterGrpcWebGateway\\GreeterClient\\certs\\client.crt");
    var key = File.ReadAllText("M:\\GreeterGrpcWebGateway\\GreeterClient\\certs\\client.key");
    var keyPair = new KeyCertificatePair(cert, key);
    var credentials = new SslCredentials(caCert, keyPair);
    return credentials;
}