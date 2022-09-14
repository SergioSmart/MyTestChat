using Microsoft.EntityFrameworkCore;

namespace MyTestChat.Database
{
    public class ChatDataContext : DbContext
    {
        public ChatDataContext()
        {

        }

        public ChatDataContext(DbContextOptions<ChatDataContext> options) : base(options)
        {

        }
    }
}