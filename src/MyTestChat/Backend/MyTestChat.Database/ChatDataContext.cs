using Microsoft.EntityFrameworkCore;
using MyTestChat.Database.Models;

namespace MyTestChat.Database
{
    public class ChatDataContext : DbContext
    {
        public DbSet<ChatMessage> Messages { get; set; }
        public ChatDataContext()
        {

        }

        public ChatDataContext(DbContextOptions<ChatDataContext> options) : base(options)
        {

        }
    }    
}