using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;

public class GetAllSalesProfile : Profile
{
    public GetAllSalesProfile()
    {
        CreateMap<Sale, GetAllSalesResult>()
            .ForMember(d => d.Items, opt => opt.MapFrom(s => s.Items));
    }
}
