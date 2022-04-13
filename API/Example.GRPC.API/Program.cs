var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<Example.GRPC.API.Controllers.V1.StatusInvestController>();

app.Run();