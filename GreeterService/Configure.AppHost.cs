using Funq;
using MyGrpcProject.ServiceInterface;
using ServiceStack;

[assembly: HostingStartup(typeof(GreeterService.AppHost))]

namespace GreeterService;

public class AppHost : AppHostBase, IHostingStartup
{
    public void Configure(IWebHostBuilder builder) => builder
        .ConfigureServices(services => {
            // Configure ASP.NET Core IOC Dependencies
        });

    public AppHost() : base("GreeterService", typeof(GreeterServices).Assembly) {}

    public override void Configure(Container container)
    {
    }
}
