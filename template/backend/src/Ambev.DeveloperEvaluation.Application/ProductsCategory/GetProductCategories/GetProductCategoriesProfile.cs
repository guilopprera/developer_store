using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.ProductsCategory.GetProductCategories;

public class GetProductCategoriesProfile : Profile
{
    public GetProductCategoriesProfile()
    {
        CreateMap<GetProductCategoriesCommand, GetProductCategoriesResult>();
    }
}