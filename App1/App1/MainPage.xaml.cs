using Business;
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
            var result = await Do.SomethingAsync();
        }
    }
}
