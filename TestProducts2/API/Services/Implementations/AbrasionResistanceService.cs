﻿using API.Common;
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
    public class AbrasionResistanceService : IAbrasionResistanceService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AbrasionResistanceService(IRepositoryManager repositoryManager, IMapper mapper)
        {

            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public AbrasionResistanceReadDto Create(AbrasionResistanceCreateDto abrasionDto)
        {
            if (abrasionDto == null)
                throw new Exception("The format of the abrasion DTO was invalid");

            var abrasion = _mapper.Map<AbrasionResistance>(abrasionDto);

            _repositoryManager.AbrasionResistanceRepository.Create(abrasion);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<AbrasionResistanceReadDto>(abrasion);
        }

        public void Delete(int id)
        {
            var abrasion = _repositoryManager.AbrasionResistanceRepository.GetById(id);
            if (abrasion == null)
            {
                throw new Exception($"The abrasion with the identifier {id} could not be found");
            }

            _repositoryManager.AbrasionResistanceRepository.Delete(abrasion);
            _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public IEnumerable<AbrasionResistanceReadDto> GetAll()
        {
            var abrasions = _repositoryManager.AbrasionResistanceRepository.GetAll();

            //var mappedAbrasionResistances = _mapper.Map<IEnumerable<AbrasionResistanceReadDto>>(abrasions, opt => opt.Items["lang"] = lang);
            var mappedAbrasionResistances = _mapper.Map<IEnumerable<AbrasionResistanceReadDto>>(abrasions);

            return mappedAbrasionResistances;
        }

        public AbrasionResistanceReadDto? GetById(int id)
        {
            var abrasion = _repositoryManager.AbrasionResistanceRepository.GetById(id);

            if (abrasion == null)
            {
                //throw new Exception($"The abrasion with the identifier {id} could not be found");
                Console.WriteLine($"The abrasion with the identifier {id} could not be found");
                return null;
            }

            var abrasionDto = _mapper.Map<AbrasionResistanceReadDto>(abrasion);

            return abrasionDto;
        }

        public AbrasionResistanceReadDto PartialUpdate(int id, JsonPatchDocument<AbrasionResistanceUpdateDto> patchDoc)
        {
            var abrasion = _repositoryManager.AbrasionResistanceRepository.GetById(id);

            if (abrasion == null)
            {
                throw new Exception($"The abrasion with the identifier {id} could not be found");
            }

            var abrasionToPatch = _mapper.Map<AbrasionResistanceUpdateDto>(abrasion);
            patchDoc.ApplyTo(abrasionToPatch);

            abrasionToPatch.Id = abrasion.Id;
            _mapper.Map(abrasionToPatch, abrasion);

            _repositoryManager.AbrasionResistanceRepository.Update(abrasion);

            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<AbrasionResistanceReadDto>(abrasion);
        }


        public AbrasionResistanceReadDto Update(int id, AbrasionResistanceUpdateDto abrasionDto)
        {
            if (abrasionDto == null)
                throw new Exception("The format of the abrasion DTO was invalid");

            var abrasion = _repositoryManager.AbrasionResistanceRepository.GetById(id);

            if (abrasion == null)
            {
                throw new Exception($"The abrasion with the identifier {id} could not be found");
            }

            abrasionDto.Id = abrasion.Id;
            _mapper.Map(abrasionDto, abrasion);

            _repositoryManager.AbrasionResistanceRepository.Update(abrasion);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<AbrasionResistanceReadDto>(abrasion);
        }
    }
}
