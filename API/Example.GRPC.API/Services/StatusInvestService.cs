using Example.GRPC.API.ApplicationCore.Protos;
using Grpc.Core;

namespace Example.GRPC.API.Services
{
    public class StatusInvestService : StatusInvest.StatusInvestBase
    {
        private readonly ILogger<StatusInvestService> _logger;

        public StatusInvestService(ILogger<StatusInvestService> logger)
        {
            _logger = logger;
        }

        public override Task<ApplicationCore.Protos.Action> ListAction(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new ApplicationCore.Protos.Action
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = 1,
                CompanyName = "Action",
                Ticker = "10",
                LastUpdate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow)
            });
        }

        public override Task<ApplicationCore.Protos.FII> ListFII(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new ApplicationCore.Protos.FII
            {
                Id = Guid.NewGuid().ToString(),
                CompanyId = 1,
                CompanyName = "FII",
                Ticker = "12",
                LastUpdate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow)
            });
        }
    }
}