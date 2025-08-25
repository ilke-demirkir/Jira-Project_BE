using Application.Commands;
using Application.DTOs;
using Application.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class CreateInviteCommandHandler : IRequestHandler<CreateInviteCommand, InviteResponseDto>
    {
        private readonly IInviteService _inviteService;

        public CreateInviteCommandHandler(IInviteService inviteService)
        {
            _inviteService = inviteService;
        }

        public Task<InviteResponseDto> Handle(CreateInviteCommand request, CancellationToken cancellationToken)
        {
            var link = _inviteService.CreateInvite(request.CreateInviteDto.TenantId);
            return Task.FromResult(new InviteResponseDto { InviteLink = link });
        }
    }
}
