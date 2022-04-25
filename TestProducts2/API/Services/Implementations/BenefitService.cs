using API.Common;
using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using API.Services.Abstractions;
using AutoMapper;
using Domain.Base;
using Domain.Interfaces;
using Domain.Models;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;

namespace API.Services.Implementations
{
    public class BenefitService : IBenefitService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public BenefitService(IRepositoryManager repositoryManager, IMapper mapper)
        {

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


        public IEnumerable<BenefitReadDto> GetAll()
        {
            var benefits = _repositoryManager.BenefitRepository.GetAll();

            //var mappedBenefits = _mapper.Map<IEnumerable<BenefitReadDto>>(benefits, opt => opt.Items["lang"] = lang);
            var mappedBenefits = _mapper.Map<IEnumerable<BenefitReadDto>>(benefits);

            return mappedBenefits;
        }

        public BenefitReadDto? GetById(int id)
        {
            var benefit = _repositoryManager.BenefitRepository.GetById(id);

            if (benefit == null)
            {
                //throw new Exception($"The benefit with the identifier {id} could not be found");
                Console.WriteLine($"The benefit with the identifier {id} could not be found");
                return null;
            }

            var benefitDto = _mapper.Map<BenefitReadDto>(benefit);

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
            //Type typeMarketSegment = Helper.GetDynamicValue(benefitDto, "MarketSegments").GetType().GetGenericArguments().Single();
            //benefit.MarketSegments = ((HashSet<typeof(typeMarketSegment)>)Helper.GetDynamicValue(benefitDto, "MarketSegments")!)
            //    .Where(x => _repositoryManager.MarketSegmentRepository.GetById(x.Id) != null)
            //    .Select(x => _repositoryManager.MarketSegmentRepository.GetById(x.Id)) as ICollection<MarketSegment> ?? new HashSet<MarketSegment>();
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
