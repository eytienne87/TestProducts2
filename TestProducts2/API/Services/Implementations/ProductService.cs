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
using static API.Common.Helper;

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

        public async Task<ProductReadDto> Create (ProductCreateDto productDto)
        {
            await ValidateProduct(productDto);
            if (productDto == null)
                throw new BadRequestException("The format of the product DTO was invalid");

            var product = _mapper.Map<Product>(productDto);

            await SetProductNavigations(product, productDto);

            _repositoryManager.ProductRepository.Create(product);
            await _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<ProductReadDto>(product);
        }

        public async Task Delete(int id)
        {
            var product = await _repositoryManager.ProductRepository.GetById(id);
            if (product == null)
            {
                throw new NotFoundException($"The product with the identifier {id} could not be found");
            }

            _repositoryManager.ProductRepository.Delete(product);
            await _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public async Task<IEnumerable<ProductReadDto>> GetAll()
        {
            var products = await _repositoryManager.ProductRepository.GetAll();
            var productReadDtos = _mapper.Map<IEnumerable<ProductReadDto>>(products);
            foreach (var dto in productReadDtos)
            {
                dto.ColorName = await SetProductReadDto(dto);
            }

            return productReadDtos;
        }

        public async Task<ProductReadDto> GetById(int id)
        {
            var product = await _repositoryManager.ProductRepository.GetById(id);

            if (product == null)
                throw new NotFoundException($"The product with the identifier {id} could not be found");

            var productDto = _mapper.Map<ProductReadDto>(product);

            return productDto;
        }

        public async Task<ProductReadDto> PartialUpdate(int id, JsonPatchDocument<ProductUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                throw new BadRequestException("The Patch Document provided was invalid");

            var product = await _repositoryManager.ProductRepository.GetById(id);

            if (product == null)
                throw new NotFoundException($"The product with the identifier {id} could not be found");

            var productToPatch = _mapper.Map<ProductUpdateDto>(product);
            patchDoc.ApplyTo(productToPatch);

            productToPatch.Id = product.Id;
            _mapper.Map(productToPatch, product);

            await SetProductNavigations(product, productToPatch);

            _repositoryManager.ProductRepository.Update(product);

            await _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<ProductReadDto>(product);
        }


        public async Task<ProductReadDto> Update(int id, ProductUpdateDto productDto)
        {
            if (productDto == null)
                throw new BadRequestException("The Product DTO provided was invalid");

            var product = await _repositoryManager.ProductRepository.GetById(id);

            if (product == null)
                throw new NotFoundException($"The product with the identifier {id} could not be found");

            productDto.Id = product.Id;
            _mapper.Map(productDto, product);

            await SetProductNavigations(product, productDto);

            _repositoryManager.ProductRepository.Update(product);
            await _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<ProductReadDto>(product);
        }

        private async Task SetProductNavigations(Product product, object productDto)
        {
            product.Abrasion = await _repositoryManager.AbrasionResistanceRepository.GetById((int)Helper.GetDynamicValue(productDto, "AbrasionId")!);

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
                var benefitModel = await _repositoryManager.BenefitRepository.GetById((int)Helper.GetDynamicValue(benefit, "Id"));
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
                                        .FindOne(w => w.WarrantyTitle.Id == warrantyTitleId &&
                                                  w.WarrantyLength.Id == warrantyLengthId &&
                                                 (w.WarrantyNotabene != null ? w.WarrantyNotabene.Id : null) == warrantyNotabeneId);

                var warrantyTitleModel = await _repositoryManager.WarrantyTitleRepository.GetById(warrantyTitleId);
                var warrantyLengthModel = await _repositoryManager.WarrantyLengthRepository.GetById(warrantyLengthId);
                var warrantyNotabeneModel = await _repositoryManager.WarrantyNotabeneRepository.GetById((int)warrantyNotabeneId);

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
        private async Task ValidateProduct(object productDto)
        {
            var productType = GetDynamicValue(productDto, "ProductType") as string;
            var styleCode = GetDynamicValue(productDto, "StyleCode") as string;
            var backingCode = GetDynamicValue(productDto, "BackingCode") as string;
            var width = (decimal?)GetDynamicValue(productDto, "Width");
            var marketingProgram = GetDynamicValue(productDto, "MarketingProgram") as string;
            var colorCode = GetDynamicValue(productDto, "ColorCode") as string;

            if (productType != null && (productType.Trim().Length == 0 || productType.Trim().Length > 1))
                throw new ModelException("The product type entered was not valid");

            if (styleCode != null && (styleCode.Trim().Length == 0 || styleCode.Trim().Length > 5))
                throw new ModelException("The style code entered was not valid");

            var product = await _repositoryManager.ProductRepository.FindOne(p =>
                                p.ProductType == productType &&
                                p.StyleCode == styleCode &&
                                p.BackingCode == backingCode &&
                                p.Width == width &&
                                p.MarketingProgram == marketingProgram &&
                                p.ColorCode == colorCode
                            );
            if (product != null)
                throw new ConflictException("This product already exists in the database");
        }
        private async Task<ColorNameReadDto> SetProductReadDto(ProductReadDto productReadDto)
        {
            var colorName = await _repositoryManager.ColorNameRepository.FindOne(c => c.ProductType == productReadDto.ProductType);
            var colorNameDto = _mapper.Map<ColorNameReadDto>(colorName);
            return colorNameDto;
        }
    }
}