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
    public class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryManager repositoryManager, IMapper mapper)
        {

            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ProductReadDto> CreateAsync (ProductCreateDto productDto)
        {
            if (productDto == null)
                throw new BadRequestException("The format of the product DTO was invalid");

            var product = _mapper.Map<Product>(productDto);

            SetProductNavigationsAsync(product, productDto);

            _repositoryManager.ProductRepository.Create(product);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductReadDto>(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _repositoryManager.ProductRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException($"The product with the identifier {id} could not be found");
            }

            _repositoryManager.ProductRepository.Delete(product);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return;
        }


        public async Task<IEnumerable<ProductReadDto>> GetAllAsync()
        {
            var products = await _repositoryManager.ProductRepository.GetAllAsync();
            var productReadDtos = _mapper.Map<IEnumerable<ProductReadDto>>(products);
            foreach (var dto in productReadDtos)
            {
                dto.ColorName = await SetProductReadDtoAsync(dto);
            }

            return productReadDtos;
        }

        public async Task<ProductReadDto> GetByIdAsync(int id)
        {
            var product = await _repositoryManager.ProductRepository.GetByIdAsync(id);

            if (product == null)
                throw new NotFoundException($"The product with the identifier {id} could not be found");

            var productDto = _mapper.Map<ProductReadDto>(product);

            return productDto;
        }

        public async Task<ProductReadDto> PartialUpdateAsync(int id, JsonPatchDocument<ProductUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                throw new BadRequestException("The Patch Document provided was invalid");

            var product = await _repositoryManager.ProductRepository.GetByIdAsync(id);

            if (product == null)
                throw new NotFoundException($"The product with the identifier {id} could not be found");

            var productToPatch = _mapper.Map<ProductUpdateDto>(product);
            patchDoc.ApplyTo(productToPatch);

            productToPatch.Id = product.Id;
            _mapper.Map(productToPatch, product);

            await SetProductNavigationsAsync(product, productToPatch);

            _repositoryManager.ProductRepository.Update(product);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductReadDto>(product);
        }


        public async Task<ProductReadDto> UpdateAsync(int id, ProductUpdateDto productDto)
        {
            if (productDto == null)
                throw new BadRequestException("The Product DTO provided was invalid");

            var product = await _repositoryManager.ProductRepository.GetByIdAsync(id);

            if (product == null)
                throw new NotFoundException($"The product with the identifier {id} could not be found");

            productDto.Id = product.Id;
            _mapper.Map(productDto, product);

            await SetProductNavigationsAsync(product, productDto);

            _repositoryManager.ProductRepository.Update(product);
            await _repositoryManager.UnitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductReadDto>(product);
        }

        private async Task SetProductNavigationsAsync(Product product, object productDto)
        {
            product.Abrasion = await _repositoryManager.AbrasionResistanceRepository.GetByIdAsync((int)Helper.GetDynamicValue(productDto, "AbrasionId")!);

            product.Benefits = new HashSet<Benefit>();
            var benefitsFromDto = Helper.GetDynamicValue(productDto, "Benefits");
            await SetProductBenefitsAsync(product, benefitsFromDto);

            product.Warranties = new HashSet<Warranty>();
            var warrantiesFromDto = Helper.GetDynamicValue(productDto, "Warranties");
            await SetProductWarrantiesAsync(product, warrantiesFromDto);
        }
        private async Task SetProductBenefitsAsync(Product product, dynamic? benefitsFromDto)
        {
            if (benefitsFromDto == null)
                return;

            foreach (var benefit in benefitsFromDto)
            {
                var benefitModel = await _repositoryManager.BenefitRepository.GetByIdAsync((int)Helper.GetDynamicValue(benefit, "Id"));
                if (benefitModel != null)
                {
                    product.Benefits.Add(benefitModel);
                }
            }
        }
        private async Task SetProductWarrantiesAsync(Product product, dynamic? warrantiesFromDto)
        {
            if (warrantiesFromDto == null)
                return;

            foreach (var warranty in warrantiesFromDto)
            {
                int warrantyTitleId = (int)Helper.GetDynamicValue(warranty, "WarrantyTitleId");
                int warrantyLengthId = (int)Helper.GetDynamicValue(warranty, "WarrantyLengthId");
                int? warrantyNotabeneId = (int?)Helper.GetDynamicValue(warranty, "WarrantyNotabeneId");

                var warrantyModel = await _repositoryManager.WarrantyRepository
                                        .GetAsync(w => w.WarrantyTitle.Id == warrantyTitleId &&
                                                  w.WarrantyLength.Id == warrantyLengthId &&
                                                 (w.WarrantyNotabene != null ? w.WarrantyNotabene.Id : null) == warrantyNotabeneId)
                                        .FirstOrDefault();


                var warrantyTitleModel = await _repositoryManager.WarrantyTitleRepository.GetByIdAsync(warrantyTitleId);
                var warrantyLengthModel = await _repositoryManager.WarrantyLengthRepository.GetByIdAsync(warrantyLengthId);
                var warrantyNotabeneModel = await _repositoryManager.WarrantyNotabeneRepository.GetByIdAsync((int)warrantyNotabeneId);

                if (warrantyModel != null)
                {
                    product.Warranties.Add(warrantyModel);
                }
                else if (warrantyTitleModel != null && warrantyLengthModel != null)
                {
                    product.Warranties.Add(new Warranty
                    {
                        WarrantyTitle = warrantyTitleModel,
                        WarrantyLength = warrantyLengthModel,
                        WarrantyNotabene = warrantyNotabeneModel
                    });
                }
            }
        }
        private async Task<ColorNameReadDto> SetProductReadDtoAsync(ProductReadDto productReadDto)
        {
            var colorName = await _repositoryManager.ColorNameRepository.GetAsync(c => c.ProductType == productReadDto.ProductType).FirstOrDefaultAsync();
            var colorNameDto = _mapper.Map<ColorNameReadDto>(colorName);
            return colorNameDto;
        }
    }
}