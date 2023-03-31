var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
var app = builder.Build();
app.UseGrpcWeb();
app.MapGrpcService<GreeterService.Services.GreeterService>().EnableGrpcWeb();
app.Run();
