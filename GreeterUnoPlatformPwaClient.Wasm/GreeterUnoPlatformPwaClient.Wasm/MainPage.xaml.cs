using Business;
using Grpc.Net.Client;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace GreeterUnoPlatformPwaClient.Wasm
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var res = DoSomething.Foo();
            textBlock.Text = res;
        }
    }
}
