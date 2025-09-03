using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using AppGet = Ambev.DeveloperEvaluation.Application.Products.GetProduct;
using AppUpdate = Ambev.DeveloperEvaluation.Application.Products.UpdateProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetAllProductsPageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(
    [FromQuery(Name = "_page")] int page = 1,
    [FromQuery(Name = "_size")] int size = 10,
    [FromQuery(Name = "_order")] string? order = null,
    CancellationToken ct = default)
    {
        var result = await _mediator.Send(new GetAllProductsCommand(page, size, order), ct);
        var dto = _mapper.Map<GetAllProductsPageResponse>(result);
        return Ok(dto);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(GetProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var result = await _mediator.Send(new AppGet.GetProductCommand(id), ct);
        var dto = _mapper.Map<GetProductResponse>(result);
        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateProductResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request, CancellationToken ct)
    {
        var cmd = _mapper.Map<CreateProductCommand>(request);
        var result = await _mediator.Send(cmd, ct);
        var response = _mapper.Map<CreateProductResponse>(result);

        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(UpdateProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductRequest request, CancellationToken ct)
    {
        var cmd = _mapper.Map<AppUpdate.UpdateProductCommand>(request);
        cmd.Id = id;

        var result = await _mediator.Send(cmd, ct);
        var dto = _mapper.Map<UpdateProductResponse>(result);
        return Ok(dto);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var command = _mapper.Map<DeleteProductCommand>(id);
        var result = await _mediator.Send(command, ct);

        return Ok(result.Message);
    }
}
