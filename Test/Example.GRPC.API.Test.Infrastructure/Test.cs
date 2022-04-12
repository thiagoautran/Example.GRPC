using Grpc.Net.Client;

namespace Example.GRPC.API.Test.Infrastructure
{
    public class Test
    {
        public async Task SayHelloAsync()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7145");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(new HelloRequest
            {
                Name = "Thiago"
            });

            Console.WriteLine($"Result: {reply.Message}");
        }
    }
}