namespace Domain.Entities
{
    internal class TenantToken
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public string Link { get; set; }
    }
}