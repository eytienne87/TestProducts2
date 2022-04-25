using API.Dtos.Read;
using API.Services.Abstractions;
using AutoMapper;
using Domain.Interfaces;

namespace API.Services.Implementations
{
    public class MiniService : IMiniService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public MiniService(IRepositoryManager repositoryManager, IMapper mapper)
        {

            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<ProductMiniReadDto> GetAll()
        {
            var minis = _repositoryManager.ProductRepository.GetAll();

            //var mappedMinis = _mapper.Map<IEnumerable<MiniReadDto>>(minis, opt => opt.Items["lang"] = lang);
            var mappedMinis = _mapper.Map<IEnumerable<ProductMiniReadDto>>(minis);

            return mappedMinis;
        }
    }
}
