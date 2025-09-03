using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;

public class GetAllSalesProfile : Profile
{
    public GetAllSalesProfile()
    {
        CreateMap<GetAllSalesItemResult, SaleItemResponse>();
        CreateMap<GetAllSalesResult, GetAllSalesResponse>()
            .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));

        CreateMap<GetAllSalesPageResult, GetAllSalesPageResponse>();
    }
}