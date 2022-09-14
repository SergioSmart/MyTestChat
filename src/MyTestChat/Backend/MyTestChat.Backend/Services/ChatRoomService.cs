using Grpc.Core;
using MyTestChat.Protos;

namespace MyTestChat.Backend.Services
{
    public class ChatRoomService : ChatRoom.ChatRoomBase
    {
        public override async Task JoinChat(ChatRequest request, IServerStreamWriter<ChatMessage> responseStream, ServerCallContext context)
        {

        }

        public override async Task<ChatRequest> Send(ChatMessage request, ServerCallContext context)
        {

        }
    }
}
