- Visual Studio -> Extensions -> Install -> StackServices;
- Run GreeterService;
- GreeterClient -> Right Click -> Add ServiceStack Referenece
  More about ServiceStack Referenece 

- Address -> https://localhost:5001

```C#
var handler = new HttpClientHandler();
handler.ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true;
var options = new GrpcChannelOptions()
{
    HttpHandler = handler,
    Credentials = ChannelCredentials.Insecure
};

var channel = new Channel("localhost:5054", ChannelCredentials.Insecure);
var client = new GrpcServices.GrpcServicesClient(channel);
var response = client.GetHello(new Hello { Name = "limeniye" });
```

-Or
  > x proto-csharp https://localhost:5001