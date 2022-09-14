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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>().EnableGrpcWeb();
                endpoints.MapGrpcService<ChatRoomService>().EnableGrpcWeb();
                                
                endpoints.MapFallbackToFile("index.html");
            });


            
            
            app.Run();
        }
    }
}