using Asp_Lesson3.Models;
using Asp_Lesson3.Models.Dto;
using AutoMapper;

namespace Asp_Lesson1.Repositories
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductGroup, ProductGroupModel>().ReverseMap();
            CreateMap<Store, StoreModel>().ReverseMap();
        }
    }
}
