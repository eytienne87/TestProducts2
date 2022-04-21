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
    public class WarrantyLengthService : IWarrantyLengthService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WarrantyLengthService(IRepositoryManager repositoryManager, IMapper mapper)
        {

            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public WarrantyLengthReadDto Create(WarrantyLengthCreateDto lengthDto)
        {
            if (lengthDto == null)
                throw new Exception("The format of the length DTO was invalid");

            var length = _mapper.Map<WarrantyLength>(lengthDto);

            _repositoryManager.WarrantyLengthRepository.Create(length);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyLengthReadDto>(length);
        }

        public void Delete(int id)
        {
            var model = _repositoryManager.WarrantyLengthRepository.GetById(id);
            if (model == null)
            {
                throw new Exception($"The length with the identifier {id} could not be found");
            }

            _repositoryManager.WarrantyLengthRepository.Delete(model);
            _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public IEnumerable<WarrantyLengthReadDto> GetAll(LanguageClass? lang)
        {
            var lengths = _repositoryManager.WarrantyLengthRepository.GetAll();

            var mappedWarrantyLengths = _mapper.Map<IEnumerable<WarrantyLengthReadDto>>(lengths, opt => opt.Items["lang"] = lang);

            return mappedWarrantyLengths;
        }

        public WarrantyLengthReadDto GetById(int id, LanguageClass? lang)
        {
            var length = _repositoryManager.WarrantyLengthRepository.GetById(id);

            if (length == null)
            {
                throw new Exception($"The length with the identifier {id} could not be found");
            }

            var lengthDto = _mapper.Map<WarrantyLengthReadDto>(length, opt => opt.Items["lang"] = lang);

            return lengthDto;
        }

        public WarrantyLengthReadDto PartialUpdate(int id, JsonPatchDocument<WarrantyLengthUpdateDto> patchDoc)
        {
            var length = _repositoryManager.WarrantyLengthRepository.GetById(id);

            if (length == null)
            {
                throw new Exception($"The length with the identifier {id} could not be found");
            }

            var lengthToPatch = _mapper.Map<WarrantyLengthUpdateDto>(length);
            patchDoc.ApplyTo(lengthToPatch);

            lengthToPatch.Id = length.Id;
            _mapper.Map(lengthToPatch, length);

            _repositoryManager.WarrantyLengthRepository.Update(length);

            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyLengthReadDto>(length);
        }


        public WarrantyLengthReadDto Update(int id, WarrantyLengthUpdateDto lengthDto)
        {
            if (lengthDto == null)
                throw new Exception("The format of the length DTO was invalid");

            var length = _repositoryManager.WarrantyLengthRepository.GetById(id);

            if (length == null)
            {
                throw new Exception($"The length with the identifier {id} could not be found");
            }

            lengthDto.Id = length.Id;
            _mapper.Map(lengthDto, length);

            _repositoryManager.WarrantyLengthRepository.Update(length);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyLengthReadDto>(length);
        }
    }
}
