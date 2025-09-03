using Ambev.DeveloperEvaluation.Application.ProductsCategory.GetProductsByCategory;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsCategory.GetProductsByCategory
{
    public class GetProductsByCategoryProfile : Profile
    {
        public GetProductsByCategoryProfile()
        {
            CreateMap<Product, GetProductsByCategoryResponse>();
            CreateMap<GetProductsByCategoryPageResult, GetProductsByCategoryPageResponse>();
        }
    }
}
