using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using API.Services.Abstractions;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Shared;
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

        public MarketSegmentReadDto Create(MarketSegmentCreateDto marketSegmentDto)
        {
            if (marketSegmentDto == null)
                throw new Exception("The format of the marketSegment DTO was invalid");

            var marketSegment = _mapper.Map<MarketSegment>(marketSegmentDto);

            _repositoryManager.MarketSegmentRepository.Create(marketSegment);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<MarketSegmentReadDto>(marketSegment);
        }

        public void Delete(int id)
        {
            var model = _repositoryManager.MarketSegmentRepository.GetById(id);
            if (model == null)
            {
                throw new Exception($"The marketSegment with the identifier {id} could not be found");
            }

            _repositoryManager.MarketSegmentRepository.Delete(model);
            _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public IEnumerable<MarketSegmentReadDto> GetAll(LanguageClass? lang)
        {
            var marketSegments = _repositoryManager.MarketSegmentRepository.GetAll();

            var mappedMarketSegments = _mapper.Map<IEnumerable<MarketSegmentReadDto>>(marketSegments, opt => opt.Items["lang"] = lang);

            return mappedMarketSegments;
        }

        public MarketSegmentReadDto GetById(int id, LanguageClass? lang)
        {
            var marketSegment = _repositoryManager.MarketSegmentRepository.GetById(id);

            if (marketSegment == null)
            {
                throw new Exception($"The marketSegment with the identifier {id} could not be found");
            }

            var marketSegmentDto = _mapper.Map<MarketSegmentReadDto>(marketSegment, opt => opt.Items["lang"] = lang);

            return marketSegmentDto;
        }

        public MarketSegmentReadDto PartialUpdate(int id, JsonPatchDocument<MarketSegmentUpdateDto> patchDoc)
        {
            var marketSegment = _repositoryManager.MarketSegmentRepository.GetById(id);

            if (marketSegment == null)
            {
                throw new Exception($"The marketSegment with the identifier {id} could not be found");
            }

            var marketSegmentToPatch = _mapper.Map<MarketSegmentUpdateDto>(marketSegment);
            patchDoc.ApplyTo(marketSegmentToPatch);

            marketSegmentToPatch.Id = marketSegment.Id;
            _mapper.Map(marketSegmentToPatch, marketSegment);

            _repositoryManager.MarketSegmentRepository.Update(marketSegment);

            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<MarketSegmentReadDto>(marketSegment);
        }


        public MarketSegmentReadDto Update(int id, MarketSegmentUpdateDto marketSegmentDto)
        {
            if (marketSegmentDto == null)
                throw new Exception("The format of the marketSegment DTO was invalid");

            var marketSegment = _repositoryManager.MarketSegmentRepository.GetById(id);

            if (marketSegment == null)
            {
                throw new Exception($"The marketSegment with the identifier {id} could not be found");
            }

            marketSegmentDto.Id = marketSegment.Id;
            _mapper.Map(marketSegmentDto, marketSegment);

            _repositoryManager.MarketSegmentRepository.Update(marketSegment);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<MarketSegmentReadDto>(marketSegment);
        }
    }
}
