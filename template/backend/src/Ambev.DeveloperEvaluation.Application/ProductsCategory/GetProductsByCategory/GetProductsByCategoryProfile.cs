using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.ProductsCategory.GetProductsByCategory;

public class GetProductsByCategoryProfile: Profile
{
    public GetProductsByCategoryProfile()
    {
        CreateMap<GetProductsByCategoryCommand, GetProductsByCategoryPageResult>();
        CreateMap<Product, GetProductsByCategoryResult>();
    }
}
