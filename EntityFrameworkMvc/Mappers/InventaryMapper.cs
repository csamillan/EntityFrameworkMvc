using AutoMapper;
using EntityFrameworkMvc.Dtos;
using EntityFrameworkMvc.Model;

namespace EntityFrameworkMvc.Mappers
{
    public class InventaryMapper : Profile
    {
        public InventaryMapper() 
        {
            CreateMap<Inventary, InventaryDto>();
            CreateMap<SaveInventaryDto, Inventary>();
        }
    }
}
