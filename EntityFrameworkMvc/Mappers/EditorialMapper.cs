using AutoMapper;
using EntityFrameworkMvc.Dtos;
using EntityFrameworkMvc.Model;

namespace EntityFrameworkMvc.Mappers
{
    internal class EditorialMapper : Profile
    {
        public EditorialMapper()
        {
            CreateMap<Editorial, EditorialDto>();
            CreateMap<SaveEditorialDto, Editorial>();
        }
    }
}
