using Ambev.DeveloperEvaluation.Application.ProductsCategory.GetProductCategories;
using Ambev.DeveloperEvaluation.Application.ProductsCategory.GetProductsByCategory;
using Ambev.DeveloperEvaluation.WebApi.Features.ProductsCategory.GetProductCategories;
using Ambev.DeveloperEvaluation.WebApi.Features.ProductsCategory.GetProductsByCategory;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductsCategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductsCategoryController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetProductCategoriesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCategories(CancellationToken ct = default)
    {
        var result = await _mediator.Send(new GetProductCategoriesCommand(), ct);
        var dto = _mapper.Map<GetProductCategoriesResponse>(result);
        return Ok(dto);
    }

    [HttpGet("category/{category}")]
    [ProducesResponseType(typeof(GetProductsByCategoryPageResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductsByCategory(
    string category,
    [FromQuery(Name = "_page")] int page = 1,
    [FromQuery(Name = "_size")] int size = 10,
    [FromQuery(Name = "_order")] string? order = null,
    CancellationToken ct = default)
    {
        var result = await _mediator.Send(new GetProductsByCategoryCommand(category, page, size, order), ct);
        var dto = _mapper.Map<GetProductsByCategoryPageResponse>(result);
        return Ok(dto);
    }
}
