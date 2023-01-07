using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ProductInfo.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() {
            CreateMap<Entities.Product, Model.ProductDto>();
            CreateMap<Model.ProductForCreationDto,Entities.Product>();
            CreateMap<Model.ProductForUpdateDto,Entities.Product>();
            CreateMap<Entities.Product, Model.ProductForUpdateDto>();
        }


    }
}
