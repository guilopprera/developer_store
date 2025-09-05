using Ambev.DeveloperEvaluation.Application.ProductsCategory.GetProductsByCategory;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsCategory.GetProductsByCategory
{
    public class GetProductsByCategoryProfile : Profile
    {
        public GetProductsByCategoryProfile()
        {
            CreateMap<GetProductsByCategoryResult, GetProductsByCategoryResponse>();
            CreateMap<GetProductsByCategoryPageResult, GetProductsByCategoryPageResponse>();
        }
    }
}
