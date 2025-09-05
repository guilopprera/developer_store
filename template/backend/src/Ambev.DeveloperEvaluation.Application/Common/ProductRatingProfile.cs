using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Common;

public class ProductRatingProfile : Profile
{
    public ProductRatingProfile()
    {
        CreateMap<ProductRatingDto, ProductRating>();
        CreateMap<ProductRating, ProductRatingDto>();
    }
}
