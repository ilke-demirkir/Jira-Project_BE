namespace Domain.Entities
{
    public class TenantToken
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public string Link { get; set; }
    }
}