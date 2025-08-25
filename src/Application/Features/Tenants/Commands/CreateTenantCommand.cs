using Application.DTOs;
using MediatR;

namespace Application.Features.Tenants.Commands
{
    public class CreateTenantCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid UserId { get; set; } // bu JWT’den gelecek

        public static CreateTenantCommand FromDto(CreateTenantDto dto, Guid userId)
        {
            return new CreateTenantCommand
            {
                Name = dto.Name,
                UserId = userId
            };
        }
    }
}
