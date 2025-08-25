using Application.Commands;
using Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class InviteController : ControllerBase
{
    private readonly IMediator _mediator;

    public InviteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateInvite([FromBody] CreateInviteDto dto)
    {
        var command = new CreateInviteCommand(dto);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("accept")]
    public async Task<IActionResult> AcceptInvite([FromBody] AcceptInviteDto dto)
    {
        var command = new AcceptInviteCommand(dto);
        var redirectUrl = await _mediator.Send(command);
        return Redirect(redirectUrl);
    }
}
