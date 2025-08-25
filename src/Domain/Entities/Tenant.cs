namespace Domain.Entities
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<TenantUser> Members { get; set; }
    }
}