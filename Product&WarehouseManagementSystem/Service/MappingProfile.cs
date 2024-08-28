using Product_WarehouseManagementSystem.Models;
using AutoMapper;

namespace Product_WarehouseManagementSystem.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WarehouseProduct, WarehouseProductDto>().ReverseMap();
        }
    }
}
