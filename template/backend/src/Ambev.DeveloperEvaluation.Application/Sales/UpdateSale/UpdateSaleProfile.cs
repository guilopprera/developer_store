using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public sealed class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<SaleItem, UpdateSaleItemResult>();
        CreateMap<Sale, UpdateSaleResult>()
            .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));
    }
}
