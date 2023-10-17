using AutoMapper;
using EntityFrameworkMvc.Dtos;
using EntityFrameworkMvc.Model;

namespace EntityFrameworkMvc.Mappers
{
    internal class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Book, BookDto>();
            CreateMap<SaveBookDto, Book>();
        }
    }
}
