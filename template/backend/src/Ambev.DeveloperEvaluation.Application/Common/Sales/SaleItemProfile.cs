using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Common.Sales
{
    public class SaleItemProfile : Profile
    {
        public SaleItemProfile()
        {
            CreateMap<SaleItemDto, SaleItem>();
            CreateMap<SaleItem, SaleItemDto>();
        }
    }
}
