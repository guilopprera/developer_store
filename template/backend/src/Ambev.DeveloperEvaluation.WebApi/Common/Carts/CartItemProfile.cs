using Ambev.DeveloperEvaluation.Application.Common.Carts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Common.Carts
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItemDto, CartItemResponse>();
        }
    }
}
