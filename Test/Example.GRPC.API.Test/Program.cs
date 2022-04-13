using Example.GRPC.API.ApplicationCore.Protos;
using Grpc.Net.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7145");
var client = new StatusInvest.StatusInvestClient(channel);

var action = await client.ListActionAsync(new Empty());
var fii = await client.ListFIIAsync(new Empty());

Console.WriteLine($"Action: {action}");
Console.WriteLine($"FII: {fii}");