using Microsoft.EntityFrameworkCore;
using MyTestChat.Database.Models;

namespace MyTestChat.Database
{
    public class ChatDbContext : DbContext
    {
        public DbSet<ChatMessage> Messages { get; set; }
        public ChatDbContext()
        {

        }

        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {

        }
    }    
}