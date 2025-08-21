using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    //username varmýþ identityde sildim burdan 
    public string Name { get; set; }
    public string Surname { get; set; }
}