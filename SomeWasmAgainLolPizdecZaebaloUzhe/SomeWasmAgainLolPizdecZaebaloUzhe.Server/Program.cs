using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Uno.Wasm.Bootstrap.Server;

namespace UnoQuickStart
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddGrpc().AddJsonTranscoding(o =>
            {
                o.JsonSettings.WriteIndented = true;
            });

           builder.Services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
            }));
            var app = builder.Build();
            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.UseUnoFrameworkFiles();
            app.MapFallbackToFile("index.html");

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors();

            app.MapControllers();
            app.UseStaticFiles();

            app.Run();
        }
    }
}
