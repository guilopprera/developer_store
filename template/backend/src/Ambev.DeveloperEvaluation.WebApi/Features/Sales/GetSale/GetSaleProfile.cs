using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

public sealed class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<GetSaleItemResult, GetSaleItemResponse>();
        CreateMap<GetSaleResult, GetSaleResponse>()
            .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));
    }
}
