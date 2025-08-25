using MediatR;
using Application.DTOs;

namespace Application.Commands
{
    public class AcceptInviteCommand : IRequest<string> // redirect URL dönecek
    {
        public AcceptInviteDto AcceptInviteDto { get; set; }

        public AcceptInviteCommand(AcceptInviteDto dto)
        {
            AcceptInviteDto = dto;
        }
    }
}
