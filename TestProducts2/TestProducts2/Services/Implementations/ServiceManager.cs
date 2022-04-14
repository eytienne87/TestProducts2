using AutoMapper;
using Domain.Interfaces;
using TestProducts2.Services.Abstractions;

namespace TestProducts2.Services.Implementations
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBenefitService> _benefitService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _benefitService = new Lazy<IBenefitService>(() => new BenefitService(repositoryManager, mapper));
        }

        public IBenefitService BenefitService => _benefitService.Value;
    }
}
