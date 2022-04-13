using Example.GRPC.API.ApplicationCore.ProtoServices.StatusInvest.RequestResponse.ListAction;
using Example.GRPC.API.ApplicationCore.ProtoServices.StatusInvest.RequestResponse.ListFII;
using Example.GRPC.API.ApplicationCore.ProtoServices.StatusInvest;
using Grpc.Core;

namespace Example.GRPC.API.Services
{
    public class StatusInvestController : StatusInvest.StatusInvestBase
    {
        private readonly ILogger<StatusInvestController> _logger;

        public StatusInvestController(ILogger<StatusInvestController> logger)
        {
            _logger = logger;
        }

        public override Task<ReturnAction> ListAction(Empty request, ServerCallContext context)
        {
            var result = new ReturnAction();

            result.Actions.Add(new List<ApplicationCore.ProtoServices.StatusInvest.RequestResponse.ListAction.Action>
            {
                new ApplicationCore.ProtoServices.StatusInvest.RequestResponse.ListAction.Action
                {
                    Id = Guid.NewGuid().ToString(),
                    CompanyId = 1,
                    CompanyName = "Action",
                    Ticker = "10",
                    LastUpdate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow)
                }
            });

            return Task.FromResult(result);
        }

        public override Task<ReturnFII> ListFII(Empty request, ServerCallContext context)
        {
            var result = new ReturnFII();

            result.Fiis.Add(new List<ApplicationCore.ProtoServices.StatusInvest.RequestResponse.ListFII.FII>
            {
                new ApplicationCore.ProtoServices.StatusInvest.RequestResponse.ListFII.FII
                {
                    Id = Guid.NewGuid().ToString(),
                    CompanyId = 1,
                    CompanyName = "FII",
                    Ticker = "12",
                    LastUpdate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow)
                }
            });

            return Task.FromResult(result);
        }
    }
}