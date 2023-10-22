using AutoMapper;
using EntityFrameworkMvc.Dtos;
using EntityFrameworkMvc.Model;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMvc.Services
{
    public class InventaryService : IInventaryService
    {
        private readonly ModelDBContext _dbContext;

        private readonly IMapper _mapper;

        private readonly IValidator<SaveInventaryDto> _validator;

        public InventaryService(ModelDBContext dbContext, IMapper mapper, IValidator<SaveInventaryDto> validator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
        }

        public IList<InventaryDto> Get()
        {
            var list = _dbContext.Inventaries
                                .Include(x => x.Branch)
                                .Include(x => x.Book)
                                .Include(x => x.Book.Editorial)
                                .ToList();

            return _mapper.Map<IList<InventaryDto>>(list);
        }

        public void Save(SaveInventaryDto dto)
        {
            _validator.ValidateAndThrow(dto);

            var Inventary = _mapper.Map<Inventary>(dto);
            _dbContext.Inventaries.Add(Inventary);
            _dbContext.SaveChanges();
        }

        public void Update(int id, SaveInventaryDto dto)
        {
            _validator.ValidateAndThrow(dto);

            var currentInventary = _dbContext.Inventaries.Find(id);

            if (currentInventary != null && currentInventary.Id == dto.Id)
            {
                _mapper.Map(dto, currentInventary);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var currentInventary = _dbContext.Inventaries.Find(id);

            if (currentInventary != null)
            {
                _dbContext.Remove(currentInventary);
                _dbContext.SaveChanges();
            }
        }
    }

    public interface IInventaryService
    {
        IList<InventaryDto> Get();

        void Save(SaveInventaryDto dto);

        void Update(int id, SaveInventaryDto dto);

        void Delete(int id);
    }
}
