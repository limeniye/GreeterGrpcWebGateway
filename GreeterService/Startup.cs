 namespace GreeterService
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddGrpcHttpApi();
            services.AddGrpcReflection();
            services.AddGrpc().AddJsonTranscoding(o =>
            {
                o.JsonSettings.WriteIndented = true;
            });
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
            }));
        }

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
                endpoints.MapGrpcService<Services.GreeterService>().RequireCors("AllowAll");
            });
        }
    }
}
