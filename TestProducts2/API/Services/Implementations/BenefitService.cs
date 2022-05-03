using API.Common;
using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using API.Services.Abstractions;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Models;
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

        public async Task<BenefitReadDto> CreateAsync(BenefitCreateDto benefitDto)
        {
            if (benefitDto == null)
                throw new BadRequestException("The format of the benefit DTO was invalid");

            var benefit = _mapper.Map<Benefit>(benefitDto);

            await SetBenefitNavigationsAsync(benefit, benefitDto);

            _repositoryManager.BenefitRepository.Create(benefit);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<BenefitReadDto>(benefit);
        }

        public async Task DeleteAsync(int id)
        {
            var benefit = await _repositoryManager.BenefitRepository.GetByIdAsync(id);
            if (benefit == null)
            {
                throw new NotFoundException($"The benefit with the identifier {id} could not be found");
            }

            _repositoryManager.BenefitRepository.Delete(benefit);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return;
        }


        public async Task<IEnumerable<BenefitReadDto>> GetAllAsync()
        {
            var benefits = await _repositoryManager.BenefitRepository.GetAllAsync();
            var mappedBenefits = _mapper.Map<IEnumerable<BenefitReadDto>>(benefits);

            return mappedBenefits;
        }

        public async Task<BenefitReadDto> GetByIdAsync(int id)
        {
            var benefit = await _repositoryManager.BenefitRepository.GetByIdAsync(id);

            if (benefit == null)
                throw new NotFoundException($"The benefit with the identifier {id} could not be found");

            var benefitDto = _mapper.Map<BenefitReadDto>(benefit);

            return benefitDto;
        }

        public async Task<BenefitReadDto> PartialUpdateAsync(int id, JsonPatchDocument<BenefitUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                throw new BadRequestException("The Patch Document provided was invalid");

            var benefit = await _repositoryManager.BenefitRepository.GetByIdAsync(id);

            if (benefit == null)
                throw new NotFoundException($"The benefit with the identifier {id} could not be found");

            var benefitToPatch = _mapper.Map<BenefitUpdateDto>(benefit);
            patchDoc.ApplyTo(benefitToPatch);

            benefitToPatch.Id = benefit.Id;
            _mapper.Map(benefitToPatch, benefit);

            await SetBenefitNavigationsAsync(benefit, benefitToPatch);

            _repositoryManager.BenefitRepository.Update(benefit);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<BenefitReadDto>(benefit);
        }


        public async Task<BenefitReadDto> UpdateAsync(int id, BenefitUpdateDto benefitDto)
        {
            if (benefitDto == null)
                throw new BadRequestException("The Benefit DTO provided was invalid");

            var benefit = await _repositoryManager.BenefitRepository.GetByIdAsync(id);

            if (benefit == null)
                throw new NotFoundException($"The benefit with the identifier {id} could not be found");

            benefitDto.Id = benefit.Id;
            _mapper.Map(benefitDto, benefit);

            await SetBenefitNavigationsAsync(benefit, benefitDto);

            _repositoryManager.BenefitRepository.Update(benefit);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<BenefitReadDto>(benefit);
        }



        private async Task SetBenefitNavigationsAsync(Benefit benefit, object benefitDto)
        {
            benefit.Category = await _repositoryManager.CategoryOfBenefitRepository.GetByIdAsync((int)Helper.GetDynamicValue(benefitDto, "CategoryId")!);

            benefit.MarketSegments = new HashSet<MarketSegment>();
            var marketSegmentsFromDto = Helper.GetDynamicValue(benefitDto, "MarketSegments");
            await SetBenefitMarketSegmentsAsync(benefit, marketSegmentsFromDto);
        }

        private async Task SetBenefitMarketSegmentsAsync(Benefit benefit, dynamic? marketSegments)
        {
            if (marketSegments == null)
                return;

            foreach (var marketSegment in marketSegments)
            {
                var marketSegmentModel = await _repositoryManager.MarketSegmentRepository.GetByIdAsync((int)Helper.GetDynamicValue(marketSegment, "Id"));
                if (marketSegmentModel != null)
                {
                    benefit.MarketSegments.Add(marketSegmentModel);
                }
            }
        }
    }
}
