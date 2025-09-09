using Ambev.DeveloperEvaluation.Application.Common.Carts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartProfile : Profile
{
    public CreateCartProfile()
    {
        CreateMap<CreateCartCommand, Cart>()
            .ConstructUsing((src, ctx) =>
                new Cart(
                    src.UserId,
                    src.Date,
                    src.Items?.Select(i => ctx.Mapper.Map<CartItem>(i)).ToList()
                        ?? new List<CartItem>()))
            .ForMember(d => d.Items, o => o.Ignore())
            .ForMember(d => d.Id, o => o.Ignore());

        CreateMap<Cart, CreateCartResult>()
            .ForMember(d => d.Items, o => o.MapFrom(s => s.Items));
    }
}
