using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;
using Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;
using Ambev.DeveloperEvaluation.Application.Carts.UpdateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CartsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetAllCartsPageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
    [FromQuery(Name = "_page")] int page = 1,
    [FromQuery(Name = "_size")] int size = 10,
    [FromQuery(Name = "_order")] string? order = null,
    CancellationToken ct = default)
    {
        var result = await _mediator.Send(new GetAllCartsCommand(page, size, order), ct);
        var dto = _mapper.Map<GetAllCartsPageResponse>(result);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var command = _mapper.Map<GetCartCommand>(id);
        var result = await _mediator.Send(command, ct);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCartRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<CreateCartCommand>(request);
        var result = await _mediator.Send(command, ct);

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(UpdateCartResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCartRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<UpdateCartCommand>(request);
        command.Id = id;

        var result = await _mediator.Send(command, ct);
        var response = _mapper.Map<UpdateCartResponse>(result);
        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        await _mediator.Send(new DeleteCartCommand(id), ct);
        return NoContent();
    }
}
