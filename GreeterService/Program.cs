using GreeterService;
using ServiceStack;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}
app.UseRouting();
app.UseServiceStack(new AppHost());

app.Run();
