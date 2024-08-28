using AutoMapper;
using Warehouse.Models;

namespace Warehouse.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<WarehouseEntity, WarehouseDto>().ReverseMap();
        }
    }
}
