using MyTestChat.Backend.Services;

namespace MyTestChat.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
     
            builder.Services.AddGrpc();
            
            var app = builder.Build();
            
            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseGrpcWeb();

            app.MapGrpcService<GreeterService>().EnableGrpcWeb();
            app.MapFallbackToFile("index.html");
            app.Run();
        }
    }
}