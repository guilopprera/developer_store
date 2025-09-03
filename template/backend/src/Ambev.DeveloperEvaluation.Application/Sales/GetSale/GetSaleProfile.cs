using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetAllSalesProfile : Profile
{
    public GetAllSalesProfile()
    {
        CreateMap<SaleItem, GetSaleItemResult>();
        CreateMap<Sale, GetSaleResult>()
            .ForMember(d => d.Items, opt => opt.MapFrom(s => s.Items));
    }
}
