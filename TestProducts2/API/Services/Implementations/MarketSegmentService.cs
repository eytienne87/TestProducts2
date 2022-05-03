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
    public class MarketSegmentService : IMarketSegmentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public MarketSegmentService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<MarketSegmentReadDto> CreateAsync(MarketSegmentCreateDto segmentDto)
        {
            if (segmentDto == null)
                throw new BadRequestException("The format of the segment DTO was invalid");

            var segment = _mapper.Map<MarketSegment>(segmentDto);

            _repositoryManager.MarketSegmentRepository.Create(segment);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<MarketSegmentReadDto>(segment);
        }

        public async Task DeleteAsync(int id)
        {
            var segment = await _repositoryManager.MarketSegmentRepository.GetByIdAsync(id);
            if (segment == null)
                throw new NotFoundException($"The segment with the identifier {id} could not be found");

            _repositoryManager.MarketSegmentRepository.Delete(segment);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return;
        }


        public async Task<IEnumerable<MarketSegmentReadDto>> GetAllAsync()
        {
            var segments = await _repositoryManager.MarketSegmentRepository.GetAllAsync();
            var mappedMarketSegments = _mapper.Map<IEnumerable<MarketSegmentReadDto>>(segments);

            return mappedMarketSegments;
        }

        public async Task<MarketSegmentReadDto>? GetByIdAsync(int id)
        {
            var segment = await _repositoryManager.MarketSegmentRepository.GetByIdAsync(id);

            if (segment == null)
                throw new NotFoundException($"The segment with the identifier {id} could not be found");

            var segmentDto = _mapper.Map<MarketSegmentReadDto>(segment);

            return segmentDto;
        }

        public async Task<MarketSegmentReadDto> PartialUpdateAsync(int id, JsonPatchDocument<MarketSegmentUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                throw new BadRequestException("The Patch Document provided was invalid");

            var segment = await _repositoryManager.MarketSegmentRepository.GetByIdAsync(id);

            if (segment == null)
                throw new NotFoundException($"The segment with the identifier {id} could not be found");

            var segmentToPatch = _mapper.Map<MarketSegmentUpdateDto>(segment);
            patchDoc.ApplyTo(segmentToPatch);

            segmentToPatch.Id = segment.Id;
            _mapper.Map(segmentToPatch, segment);

            _repositoryManager.MarketSegmentRepository.Update(segment);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<MarketSegmentReadDto>(segment);
        }


        public async Task<MarketSegmentReadDto> UpdateAsync(int id, MarketSegmentUpdateDto segmentDto)
        {
            if (segmentDto == null)
                throw new BadRequestException("The MarketSegment DTO provided was invalid");

            var segment = await _repositoryManager.MarketSegmentRepository.GetByIdAsync(id);

            if (segment == null)
                throw new NotFoundException($"The segment with the identifier {id} could not be found");

            segmentDto.Id = segment.Id;
            _mapper.Map(segmentDto, segment);

            _repositoryManager.MarketSegmentRepository.Update(segment);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<MarketSegmentReadDto>(segment);
        }

    }
}