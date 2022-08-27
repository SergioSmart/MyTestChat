using Grpc.Core;
using MyTestChat.Backend;
using MyTestChat.Protos;

namespace MyTestChat.Backend.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;    
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "SMS from " + request.Name
            });
        }

        public override async Task JoinChat(
            HelloRequest request, 
            IServerStreamWriter<HelloReply> responseStream, 
            ServerCallContext context)
        {
            var messages = new string[]
            {
                "message1",
                "message2",
                "message3"
            };

            foreach (var message in messages)
            {
                await responseStream.WriteAsync(new HelloReply()
                {
                    Message = message
                });
            }

            int index = 4;

            while (!context.CancellationToken.IsCancellationRequested)
            {
                await responseStream.WriteAsync(new HelloReply
                {
                    Message = "Message" + index++
                });

                await Task.Delay(500, context.CancellationToken);
            }
        }
    }
}