using Example.GRPC.API.ApplicationCore.ProtoServices.V1.StatusInvest;
using Grpc.Net.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Example.GRPC.API.IntegrationTest.V1
{
    [TestClass]
    public class StatusInvestControllerTest : BaseGRPCTest<Startup>
    {
        [TestInitialize]
        public void TestInitialize() => base.Initialize();

        [TestCleanup]
        public void TestCleanup() => base.Dispose();

        [TestMethod]
        public async Task ListAction()
        {
            using var channel = GrpcChannel.ForAddress(HttpUrl);
            var client = new StatusInvest.StatusInvestClient(channel);

            var actions = await client.ListActionAsync(new Empty());

            Console.WriteLine($"Action: {actions}");
        }

        [TestMethod]
        public async Task ListFII()
        {
            using var channel = GrpcChannel.ForAddress(HttpsUrl);
            var client = new StatusInvest.StatusInvestClient(channel);

            var fiis = await client.ListFIIAsync(new Empty());

            Console.WriteLine($"FII: {fiis}");
        }
    }
}