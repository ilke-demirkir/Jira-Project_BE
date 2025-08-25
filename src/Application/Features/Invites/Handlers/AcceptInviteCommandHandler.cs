using Application.Commands;
using Application.DTOs;
using Application.ServiceInterfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class AcceptInviteCommandHandler : IRequestHandler<AcceptInviteCommand, string>
    {
        private readonly IInviteService _inviteService;

        public AcceptInviteCommandHandler(IInviteService inviteService)
        {
            _inviteService = inviteService;
        }

        public Task<string> Handle(AcceptInviteCommand request, CancellationToken cancellationToken)
        {
            // Token ile invite kabul edilir ve tenant bilgisi alınır
            var tenant = _inviteService.AcceptInvite(request.AcceptInviteDto.Token);

            // Kullanıcı yönlendirilecek URL oluşturulur
            var redirectUrl = $"https://{tenant.Name}.mysite.com/onboarding";

            return Task.FromResult(redirectUrl);
        }
    }
}
