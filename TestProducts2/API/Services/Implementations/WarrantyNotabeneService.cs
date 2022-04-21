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
    public class WarrantyNotabeneService : IWarrantyNotabeneService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WarrantyNotabeneService(IRepositoryManager repositoryManager, IMapper mapper)
        {

            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public WarrantyNotabeneReadDto Create(WarrantyNotabeneCreateDto notabeneDto)
        {
            if (notabeneDto == null)
                throw new Exception("The format of the notabene DTO was invalid");

            var notabene = _mapper.Map<WarrantyNotabene>(notabeneDto);

            _repositoryManager.WarrantyNotabeneRepository.Create(notabene);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyNotabeneReadDto>(notabene);
        }

        public void Delete(int id)
        {
            var model = _repositoryManager.WarrantyNotabeneRepository.GetById(id);
            if (model == null)
            {
                throw new Exception($"The notabene with the identifier {id} could not be found");
            }

            _repositoryManager.WarrantyNotabeneRepository.Delete(model);
            _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public IEnumerable<WarrantyNotabeneReadDto> GetAll(LanguageClass? lang)
        {
            var notabenes = _repositoryManager.WarrantyNotabeneRepository.GetAll();

            var mappedWarrantyNotabenes = _mapper.Map<IEnumerable<WarrantyNotabeneReadDto>>(notabenes, opt => opt.Items["lang"] = lang);

            return mappedWarrantyNotabenes;
        }

        public WarrantyNotabeneReadDto GetById(int id, LanguageClass? lang)
        {
            var notabene = _repositoryManager.WarrantyNotabeneRepository.GetById(id);

            if (notabene == null)
            {
                throw new Exception($"The notabene with the identifier {id} could not be found");
            }

            var notabeneDto = _mapper.Map<WarrantyNotabeneReadDto>(notabene, opt => opt.Items["lang"] = lang);

            return notabeneDto;
        }

        public WarrantyNotabeneReadDto PartialUpdate(int id, JsonPatchDocument<WarrantyNotabeneUpdateDto> patchDoc)
        {
            var notabene = _repositoryManager.WarrantyNotabeneRepository.GetById(id);

            if (notabene == null)
            {
                throw new Exception($"The notabene with the identifier {id} could not be found");
            }

            var notabeneToPatch = _mapper.Map<WarrantyNotabeneUpdateDto>(notabene);
            patchDoc.ApplyTo(notabeneToPatch);

            notabeneToPatch.Id = notabene.Id;
            _mapper.Map(notabeneToPatch, notabene);

            _repositoryManager.WarrantyNotabeneRepository.Update(notabene);

            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyNotabeneReadDto>(notabene);
        }


        public WarrantyNotabeneReadDto Update(int id, WarrantyNotabeneUpdateDto notabeneDto)
        {
            if (notabeneDto == null)
                throw new Exception("The format of the notabene DTO was invalid");

            var notabene = _repositoryManager.WarrantyNotabeneRepository.GetById(id);

            if (notabene == null)
            {
                throw new Exception($"The notabene with the identifier {id} could not be found");
            }

            notabeneDto.Id = notabene.Id;
            _mapper.Map(notabeneDto, notabene);

            _repositoryManager.WarrantyNotabeneRepository.Update(notabene);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyNotabeneReadDto>(notabene);
        }
    }
}
