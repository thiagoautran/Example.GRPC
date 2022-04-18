using System;
using Example.GRPC.API.ApplicationCore.ProtoServices.V1.StatusInvest;
using Grpc.Net.Client;

namespace Example.GRPC.API.Test
{
    internal class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new StatusInvest.StatusInvestClient(channel);

            var actions = await client.ListActionAsync(new Empty());
            var fiis = await client.ListFIIAsync(new Empty());

            Console.WriteLine($"Action: {actions}");
            Console.WriteLine($"FII: {fiis}");
        }
    }
}