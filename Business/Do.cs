using Contracts;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace Business
{
    public static class Do
    {
        public static async Task<string> SomethingAsync()
        {
            try
            {
                var channel = GrpcChannel.ForAddress("http://localhost:8080");
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
