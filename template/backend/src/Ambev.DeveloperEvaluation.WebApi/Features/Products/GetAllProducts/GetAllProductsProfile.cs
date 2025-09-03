using Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetAllProducts;

public class GetAllProductsProfile : Profile
{
    public GetAllProductsProfile()
    {
        CreateMap<GetAllProductsResult, GetAllProductsResponse>();

        CreateMap<GetAllProductsPageResult, GetAllProductsPageResponse>()
            .ForMember(d => d.Products, o => o.MapFrom(s => s.Products))
            .ForMember(d => d.TotalItems, o => o.MapFrom(s => s.TotalItems))
            .ForMember(d => d.CurrentPage, o => o.MapFrom(s => s.CurrentPage))
            .ForMember(d => d.TotalPages, o => o.MapFrom(s => s.TotalPages));
    }
}
