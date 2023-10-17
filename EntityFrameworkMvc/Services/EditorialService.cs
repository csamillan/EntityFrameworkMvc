using AutoMapper;
using EntityFrameworkMvc.Dtos;
using EntityFrameworkMvc.Model;

namespace EntityFrameworkMvc.Services
{
    public class EditorialService : IEditorialService
    {
        private readonly ModelDBContext _dbContext;

        private readonly IMapper _mapper;

        public EditorialService(ModelDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IList<EditorialDto> Get()
        {
            var list = _dbContext.Editorials.ToList();
            return _mapper.Map<List<EditorialDto>>(list);
        }

        public void Save(SaveEditorialDto dto)
        {
            var editorial = _mapper.Map<Editorial>(dto);
            _dbContext.Editorials.Add(editorial);
            _dbContext.SaveChanges();
        }

        public void Update(int id, SaveEditorialDto dto)
        {
            var currentEditorial = _dbContext.Editorials.Find(id);

            if(currentEditorial != null && currentEditorial.Id == dto.Id)
            {
                _mapper.Map(dto, currentEditorial);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var currentEditorial = _dbContext.Editorials.Find(id);

            if(currentEditorial != null)
            {
                _dbContext.Remove(currentEditorial);
                _dbContext.SaveChanges();
            }
        }
    }

    public interface IEditorialService
    {
        IList<EditorialDto> Get();

        void Save(SaveEditorialDto dto);

        void Update(int id, SaveEditorialDto dto);

        void Delete(int id);
    }
}
