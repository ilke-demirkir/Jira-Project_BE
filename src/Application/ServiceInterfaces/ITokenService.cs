using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces
{
    public interface ITokenService
    {
     string GenerateTenantToken(Tenant tenant);  // TENANT TOKENİ DAVET LİNKLERİ İÇİN
     string GenerateUserToken(ApplicationUser user); //KULLANICI TOKENI İÇİN LOGİN AUTH İÇİN 
    }
}
