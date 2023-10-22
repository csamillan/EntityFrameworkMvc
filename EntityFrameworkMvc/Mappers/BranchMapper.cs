using AutoMapper;
using EntityFrameworkMvc.Dtos;
using EntityFrameworkMvc.Model;

namespace EntityFrameworkMvc.Mappers
{
    public class BranchMapper :Profile
    {
        public BranchMapper() 
        {
            CreateMap<Branch, BranchDto>();
            CreateMap<SaveBranchDto, Branch>();
        }
    }
}
