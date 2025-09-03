using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<SaleItem, CreateSaleItemResult>();
        CreateMap<Sale, CreateSaleResult>()
            .ForMember(d => d.Items, opt => opt.MapFrom(s => s.Items));
    }
}
