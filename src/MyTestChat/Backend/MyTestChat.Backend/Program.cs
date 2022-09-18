using Microsoft.EntityFrameworkCore;
using MyTestChat.Backend.Services;
using MyTestChat.Database;

namespace MyTestChat.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);           
            builder.Services.AddGrpc();
            builder.Services.AddDbContext<ChatDbContext>(options => options.UseSqlite("Data Source = chat.db"), ServiceLifetime.Singleton);
            builder.Services.AddSingleton<ChatRoomManager>();

            var app = builder.Build();          
            
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ChatDbContext>();
                context.Database.EnsureCreated();
            }

            app.MapGrpcService<GreeterService>().EnableGrpcWeb();
            app.MapGrpcService<ChatRoomService>().EnableGrpcWeb();

            app.MapFallbackToFile("index.html");
            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseGrpcWeb();
            app.Run();
        }
    }
}