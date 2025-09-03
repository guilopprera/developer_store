using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public class GetAllSalesProfile : Profile
{
    public GetAllSalesProfile()
    {
        CreateMap<SaleItem, GetAllSalesItemResult>();
        CreateMap<Sale, GetAllSalesResult>()
            .ForMember(d => d.Items, opt => opt.MapFrom(s => s.Items));
    }
}
