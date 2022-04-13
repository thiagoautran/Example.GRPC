namespace Example.GRPC.API.ApplicationCore.ProtoEntities
{
    public class FIIEntity
    {
        public Guid Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Ticker { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}