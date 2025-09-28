using Grpc.Net.Client;
using static store_app_be_portal.Greeter;

namespace store_app_be_portal.gRPCClient
{
    public class GreeterClient : Greeter.GreeterClient
    {
        private readonly Greeter.GreeterClient _client;

        public GreeterClient(IConfiguration configuration)
        {
            var channel = GrpcChannel.ForAddress(configuration["GrpcServices:ProductService"]);
            _client = new Greeter.GreeterClient(channel);
        }

        public async Task<string> SayHelloAsync(string name)
        {
            var request = new HelloRequest { Name = name };
            var reply = await _client.SayHelloAsync(request);
            return reply.Message;
        }
    }
}
