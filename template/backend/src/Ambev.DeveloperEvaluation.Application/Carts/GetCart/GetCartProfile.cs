using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCarts;

public class GetCartProfile : Profile
{
    public GetCartProfile()
    {
        CreateMap<Cart, GetCartResult>();
    }
}