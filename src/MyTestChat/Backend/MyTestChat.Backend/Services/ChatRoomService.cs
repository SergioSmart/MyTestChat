using Grpc.Core;
using MyTestChat.Database;
using MyTestChat.Protos;

namespace MyTestChat.Backend.Services
{
    public class ChatRoomService : ChatRoom.ChatRoomBase
    {
        private readonly ChatRoomManager _chatRoomManager;
        private readonly ChatDbContext _chatDbContext;
       
        private List<IServerStreamWriter<ChatMessage>> _listeners = new List<IServerStreamWriter<ChatMessage>>();

        public ChatRoomService(ChatRoomManager chatRoomManager)
        {
            _chatRoomManager = chatRoomManager;
            _chatRoomManager.MessageSended += ChatRoomService_MessageSended;
        }

        public override async Task JoinChat(ChatRequest request, 
            IServerStreamWriter<ChatMessage> responseStream, 
            ServerCallContext context)
        {
            foreach (var chatMessage in _chatRoomManager.GetMessages())
            {
                await responseStream.WriteAsync(new ChatMessage { Message = chatMessage.Message });
            }
            _listeners.Add(responseStream);
            
            while (!context.CancellationToken.IsCancellationRequested)
            {
                await Task.Delay(100);                              
            }
            _listeners.Remove(responseStream);
        }

        private void ChatRoomService_MessageSended(string message)
        {
            foreach (var streamWriter in _listeners)
            {
                streamWriter.WriteAsync(new ChatMessage
                {
                    Message = message
                });
            }
        }

        public override async Task<ChatRequest> Send(ChatMessage request, 
            ServerCallContext context)
        {
            var chatMessage = new Database.Models.ChatMessage
            {
                Message = request.Message
            };

            await _chatRoomManager.AddMessageAsync(chatMessage);           

            return new ChatRequest();
        }
    }
}
