using Contracts;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Business
{
    public static class Do
    {
        public static async Task<string> SomethingAsync()
        {
            try
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                var channel = GrpcChannel.ForAddress("http://localhost:8080", new GrpcChannelOptions()
                {
                    HttpClient = new HttpClient(new HttpClientHandler())
                });
                var client = new Greeter.GreeterClient(channel);
                var response = await client.SayHelloAsync(new HelloRequest() { Name = "limeniye" });
                return response.Message;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
