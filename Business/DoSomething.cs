using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Business
{
    public static class DoSomething
    {
        public static async Task<string> Foo()
        {
            try
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);


                var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler()));
                var channel = GrpcChannel.ForAddress("https://localhost:8080", new GrpcChannelOptions 
                { 
                    HttpClient = httpClient,
                    Credentials = ChannelCredentials.Insecure
                });
                var client = new Contracts.Greeter.GreeterClient(channel);
                var response = await client.SayHelloAsync(new Contracts.HelloRequest { Name = "limeniye" });
                return response.Message;

            }
            catch (Exception ex)
            {
                var test = ex;
            }
            return "";
        }
    }

    internal static class GrpcChannelHalper
    {
        public static GrpcChannel GetGrpcChannel()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);

            var httpClientHandler = new HttpClientHandler();

#if !__WASM__
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert != null && cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
#endif
            return GrpcChannel.ForAddress("http://3.122.94.127:8080", new GrpcChannelOptions
            {
                HttpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWebText, httpClientHandler)),
            });
        }
    }
}
