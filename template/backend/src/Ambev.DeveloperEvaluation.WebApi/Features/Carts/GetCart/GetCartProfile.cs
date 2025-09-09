using Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;
using Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetAllCarts;

public class GetCartProfile : Profile
{
    public GetCartProfile()
    {
        CreateMap<GetCartRequest, GetCartCommand>();
        CreateMap<GetCartResult, GetCartResponse>();
    }
}
