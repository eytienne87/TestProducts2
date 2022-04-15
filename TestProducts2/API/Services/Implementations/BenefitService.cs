using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using TestProducts2.Common;
using TestProducts2.Dtos.Create;
using TestProducts2.Dtos.Read;
using TestProducts2.Dtos.Update;
using TestProducts2.Services.Abstractions;

namespace TestProducts2.Services.Implementations
{
    public class BenefitService : IBenefitService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public BenefitService(IRepositoryManager repositoryManager, IMapper mapper) {

            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public BenefitReadDto Create(BenefitCreateDto benefitDto)
        {
            if (benefitDto == null)
                throw new Exception("The format of the benefit DTO was invalid");

            var benefit = _mapper.Map<Benefit>(benefitDto);

            SetBenefitNavigations(benefit, benefitDto);

            _repositoryManager.BenefitRepository.Create(benefit);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<BenefitReadDto>(benefit);
        }

        public void Delete(int id)
        {
            var benefit = _repositoryManager.BenefitRepository.GetById(id);
            if (benefit == null)
            {
                throw new Exception($"The benefit with the identifier {id} could not be found");
            }

            _repositoryManager.BenefitRepository.Delete(benefit);
            _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public IEnumerable<BenefitReadDto> GetAll(LanguageClass? lang)
        {
            var benefits = _repositoryManager.BenefitRepository.GetAll();

            var mappedBenefits = _mapper.Map<IEnumerable<BenefitReadDto>>(benefits, opt => opt.Items["lang"] = lang);

            return mappedBenefits;
        }

        public BenefitReadDto GetById(int id, LanguageClass? lang)
        {
            var benefit = _repositoryManager.BenefitRepository.GetById(id);

            if (benefit == null)
            {
                throw new Exception($"The benefit with the identifier {id} could not be found");
            }

            var benefitDto = (_mapper.Map<BenefitReadDto>(benefit, opt => opt.Items["lang"] = lang));

            return benefitDto;
        }

        public BenefitReadDto PartialUpdate(int id, JsonPatchDocument<BenefitUpdateDto> patchDoc)
        {
            var benefit = _repositoryManager.BenefitRepository.GetById(id);

            if (benefit == null)
            {
                throw new Exception($"The benefit with the identifier {id} could not be found");
            }

            var benefitToPatch = _mapper.Map<BenefitUpdateDto>(benefit);
            patchDoc.ApplyTo(benefitToPatch);

            benefitToPatch.Id = benefit.Id;
            _mapper.Map(benefitToPatch, benefit);

            SetBenefitNavigations(benefit, benefitToPatch);

            _repositoryManager.BenefitRepository.Update(benefit);

            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<BenefitReadDto>(benefit);
        }


        public BenefitReadDto Update(int id, BenefitUpdateDto benefitDto)
        {
            if (benefitDto == null)
                throw new Exception("The format of the benefit DTO was invalid");                

            var benefit = _repositoryManager.BenefitRepository.GetById(id);

            if (benefit == null)
            {
                throw new Exception($"The benefit with the identifier {id} could not be found");
            }

            benefitDto.Id = benefit.Id;
            _mapper.Map(benefitDto, benefit);

            SetBenefitNavigations(benefit, benefitDto);

            _repositoryManager.BenefitRepository.Update(benefit);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<BenefitReadDto>(benefit);
        }



        private void SetBenefitNavigations(Benefit benefit, object benefitDto)
        {
            benefit.Category = _repositoryManager.CategoryOfBenefitRepository.GetById((int)Helper.GetDynamicValue(benefitDto, "CategoryId")!);

            benefit.MarketSegments = new HashSet<MarketSegment>();
            var marketSegmentsFromDto = Helper.GetDynamicValue(benefitDto, "MarketSegments");

            SetBenefitMarketSegments(benefit, marketSegmentsFromDto);
        }

        private void SetBenefitMarketSegments(Benefit benefit, dynamic? marketSegments)
        {
            if (marketSegments == null)
                return;

            foreach (var marketSegment in marketSegments)
            {
                var marketSegmentModel = _repositoryManager.MarketSegmentRepository.GetById((int)Helper.GetDynamicValue(marketSegment, "Id"));
                if (marketSegmentModel != null)
                {
                    benefit.MarketSegments.Add(marketSegmentModel);
                }
            }
        }
    }
}
