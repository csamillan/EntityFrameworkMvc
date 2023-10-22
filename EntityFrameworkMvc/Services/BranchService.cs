using AutoMapper;
using EntityFrameworkMvc.Dtos;
using EntityFrameworkMvc.Model;
using FluentValidation;

namespace EntityFrameworkMvc.Services
{
    public class BranchService : IBranchService
    {
        private readonly ModelDBContext _dbContext;

        private readonly IMapper _mapper;

        private readonly IValidator<SaveBranchDto> _validator;

        public BranchService(ModelDBContext dbContext, IMapper mapper, IValidator<SaveBranchDto> validator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validator = validator;
        }

        public IList<BranchDto> Get()
        {
            var list = _dbContext.Branches.ToList();

            return _mapper.Map<IList<BranchDto>>(list);
        }

        public void Save(SaveBranchDto dto)
        {
            _validator.ValidateAndThrow(dto);

            var Branch = _mapper.Map<Branch>(dto);
            _dbContext.Branches.Add(Branch);
            _dbContext.SaveChanges();
        }

        public void Update(int id, SaveBranchDto dto)
        {
            _validator.ValidateAndThrow(dto);

            var currentBranch = _dbContext.Branches.Find(id);

            if (currentBranch != null && currentBranch.Id == dto.Id)
            {
                _mapper.Map(dto, currentBranch);
                _dbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var currentBranch = _dbContext.Branches.Find(id);

            if (currentBranch != null)
            {
                _dbContext.Remove(currentBranch);
                _dbContext.SaveChanges();
            }
        }
    }

    public interface IBranchService
    {
        IList<BranchDto> Get();

        void Save(SaveBranchDto dto);

        void Update(int id, SaveBranchDto dto);

        void Delete(int id);

    }
}
