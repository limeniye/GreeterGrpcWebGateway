using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace GreeterService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddGrpcHttpApi();
            services.AddGrpcReflection();
            services.AddControllers();
            services.AddHttpContextAccessor();

            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.SetIsOriginAllowed((host) => true)
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            // we are not using app.UseGrpcWeb(); to enable browser app to call a gRPC service
            // We are using an Envoy proxy instead
            // Grpc.AspNetCore.Web package not needed for this scenario
            // app.UseGrpcWeb();

            app.UseCors("AllowAll");
            app.UseEndpoints(endpoints =>
            {
                // .EnableGrpcWeb() removed because in this scenario we are using an Envoy proxy to 
                // allow browser app to make gRPC calls 
                endpoints.MapGrpcService<GreeterService.Services.GreeterService>();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
