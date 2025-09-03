using Ambev.DeveloperEvaluation.Application.ProductsCategory.GetProductCategories;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsCategory.GetProductCategories
{
    public class GetProductCategoriesProfile : Profile
    {
        public GetProductCategoriesProfile()
        {
            CreateMap<GetProductCategoriesResult, GetProductCategoriesResponse>()
            .ForMember(d => d.Categories, o => o.MapFrom(s => s.Categories));
        }
    }
}
