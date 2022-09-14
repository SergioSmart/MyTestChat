using Grpc.Core;
using MyTestChat.Database;
using MyTestChat.Protos;

namespace MyTestChat.Backend.Services
{
    public class ChatRoomService : ChatRoom.ChatRoomBase
    {
        private readonly ChatDbContext _chatDbContext;

        public ChatRoomService(ChatDbContext chatDbContext)
        {
            _chatDbContext = chatDbContext;
        }
        public override async Task JoinChat(ChatRequest request, 
            IServerStreamWriter<ChatMessage> responseStream, 
            ServerCallContext context)
        {
            foreach (var chatMessage in _chatDbContext.Messages)
            {
                await responseStream.WriteAsync(new ChatMessage { Message = chatMessage.Message });
            }
        }

        public override async Task<ChatRequest> Send(ChatMessage request, 
            ServerCallContext context)
        {
            var chatMessage = new Database.Models.ChatMessage
            {
                Message = request.Message
            }; 
            await _chatDbContext.Messages.AddAsync(chatMessage);
            await _chatDbContext.SaveChangesAsync(); 

            return new ChatRequest();
        }
    }
}
