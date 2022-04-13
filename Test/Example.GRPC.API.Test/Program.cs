using Example.GRPC.API.ApplicationCore.ProtoServices.StatusInvest;
using Grpc.Net.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7145");
var client = new StatusInvest.StatusInvestClient(channel);

var actions = await client.ListActionAsync(new Empty());
var fiis = await client.ListFIIAsync(new Empty());

Console.WriteLine($"Action: {actions}");
Console.WriteLine($"FII: {fiis}");