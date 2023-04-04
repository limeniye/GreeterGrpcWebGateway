using Contracts;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Net.Http;

namespace App1
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            try
            {
                var channel = GrpcChannel.ForAddress("http://localhost:8080", new GrpcChannelOptions()
                {
                    HttpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler())),
                    Credentials = Grpc.Core.ChannelCredentials.Insecure 
                });
                var client = new Greeter.GreeterClient(channel);
                var response = await client.SayHelloAsync(new() { Name = "limeniye" });
            }
            catch(Exception ex)
            {

            }
        }
    }
}
