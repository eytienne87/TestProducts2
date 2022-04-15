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
    public class WarrantyTitleService : IWarrantyTitleService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public WarrantyTitleService(IRepositoryManager repositoryManager, IMapper mapper) {

            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public WarrantyTitleReadDto Create(WarrantyTitleCreateDto titleDto)
        {
            if (titleDto == null)
                throw new Exception("The format of the title DTO was invalid");

            var title = _mapper.Map<WarrantyTitle>(titleDto);

            _repositoryManager.WarrantyTitleRepository.Create(title);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyTitleReadDto>(title);
        }

        public void Delete(int id)
        {
            var model = _repositoryManager.WarrantyTitleRepository.GetById(id);
            if (model == null)
            {
                throw new Exception($"The title with the identifier {id} could not be found");
            }

            _repositoryManager.WarrantyTitleRepository.Delete(model);
            _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public IEnumerable<WarrantyTitleReadDto> GetAll(LanguageClass? lang)
        {
            var titles = _repositoryManager.WarrantyTitleRepository.GetAll();

            var mappedWarrantyTitles = _mapper.Map<IEnumerable<WarrantyTitleReadDto>>(titles, opt => opt.Items["lang"] = lang);

            return mappedWarrantyTitles;
        }

        public WarrantyTitleReadDto GetById(int id, LanguageClass? lang)
        {
            var title = _repositoryManager.WarrantyTitleRepository.GetById(id);

            if (title == null)
            {
                throw new Exception($"The title with the identifier {id} could not be found");
            }

            var titleDto = (_mapper.Map<WarrantyTitleReadDto>(title, opt => opt.Items["lang"] = lang));

            return titleDto;
        }

        public WarrantyTitleReadDto PartialUpdate(int id, JsonPatchDocument<WarrantyTitleUpdateDto> patchDoc)
        {
            var title = _repositoryManager.WarrantyTitleRepository.GetById(id);

            if (title == null)
            {
                throw new Exception($"The title with the identifier {id} could not be found");
            }

            var titleToPatch = _mapper.Map<WarrantyTitleUpdateDto>(title);
            patchDoc.ApplyTo(titleToPatch);

            titleToPatch.Id = title.Id;
            _mapper.Map(titleToPatch, title);

            _repositoryManager.WarrantyTitleRepository.Update(title);

            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyTitleReadDto>(title);
        }


        public WarrantyTitleReadDto Update(int id, WarrantyTitleUpdateDto titleDto)
        {
            if (titleDto == null)
                throw new Exception("The format of the title DTO was invalid");                

            var title = _repositoryManager.WarrantyTitleRepository.GetById(id);

            if (title == null)
            {
                throw new Exception($"The title with the identifier {id} could not be found");
            }

            titleDto.Id = title.Id;
            _mapper.Map(titleDto, title);

            _repositoryManager.WarrantyTitleRepository.Update(title);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<WarrantyTitleReadDto>(title);
        }
    }
}
