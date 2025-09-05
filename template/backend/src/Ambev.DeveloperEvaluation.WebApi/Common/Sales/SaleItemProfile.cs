using Ambev.DeveloperEvaluation.Application.Common.Sales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Common.Sales
{
    public class SaleItemProfile : Profile
    {
        public SaleItemProfile()
        {
            CreateMap<SaleItemDto, SaleItemResponse>();
        }
    }
}
