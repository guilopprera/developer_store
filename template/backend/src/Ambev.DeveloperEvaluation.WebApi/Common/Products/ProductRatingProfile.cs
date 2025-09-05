using Ambev.DeveloperEvaluation.Application.Common.Products;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Common.Products
{
    public class ProductRatingProfile : Profile
    {
        public ProductRatingProfile()
        {
            CreateMap<ProductRatingDto, ProductRatingResponse>();
        }
    }
}