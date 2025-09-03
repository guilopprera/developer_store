using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<GetSaleItemResult, GetSaleItemResponse>();
        CreateMap<GetSaleResult, GetSaleResponse>()
            .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));
    }
}
