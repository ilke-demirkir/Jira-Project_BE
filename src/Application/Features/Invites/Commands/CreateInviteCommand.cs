using MediatR;
using Application.DTOs;

namespace Application.Commands
{
    public class CreateInviteCommand : IRequest<InviteResponseDto>
    {
        public CreateInviteDto CreateInviteDto { get; set; }

        public CreateInviteCommand(CreateInviteDto dto)
        {
            CreateInviteDto = dto;
        }
    }
}
