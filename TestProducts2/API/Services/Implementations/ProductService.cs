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

        public ProductReadDto Create(ProductCreateDto productDto)
        {
            if (productDto == null)
                throw new BadRequestException("The format of the product DTO was invalid");

            var product = _mapper.Map<Product>(productDto);

            SetProductNavigations(product, productDto);

            _repositoryManager.ProductRepository.Create(product);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<ProductReadDto>(product);
        }

        public void Delete(int id)
        {
            var product = _repositoryManager.ProductRepository.GetById(id);
            if (product == null)
            {
                throw new NotFoundException($"The product with the identifier {id} could not be found");
            }

            _repositoryManager.ProductRepository.Delete(product);
            _repositoryManager.UnitOfWork.SaveChanges();

            return;
        }


        public IEnumerable<ProductReadDto> GetAll()
        {
            var products = _repositoryManager.ProductRepository.GetAll();
            var mappedProducts = _mapper.Map<IEnumerable<ProductReadDto>>(products);

            return mappedProducts;
        }

        public ProductReadDto? GetById(int id)
        {
            var product = _repositoryManager.ProductRepository.GetById(id);

            if (product == null)
                throw new NotFoundException($"The product with the identifier {id} could not be found");

            var productDto = _mapper.Map<ProductReadDto>(product);

            return productDto;
        }

        public ProductReadDto PartialUpdate(int id, JsonPatchDocument<ProductUpdateDto> patchDoc)
        {
            if (patchDoc == null)
                throw new BadRequestException("The Patch Document provided was invalid");

            var product = _repositoryManager.ProductRepository.GetById(id);

            if (product == null)
                throw new NotFoundException($"The product with the identifier {id} could not be found");

            var productToPatch = _mapper.Map<ProductUpdateDto>(product);
            patchDoc.ApplyTo(productToPatch);

            productToPatch.Id = product.Id;
            _mapper.Map(productToPatch, product);

            SetProductNavigations(product, productToPatch);

            _repositoryManager.ProductRepository.Update(product);

            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<ProductReadDto>(product);
        }


        public ProductReadDto Update(int id, ProductUpdateDto productDto)
        {
            if (productDto == null)
                throw new BadRequestException("The Product DTO provided was invalid");

            var product = _repositoryManager.ProductRepository.GetById(id);

            if (product == null)
                throw new NotFoundException($"The product with the identifier {id} could not be found");

            productDto.Id = product.Id;
            _mapper.Map(productDto, product);

            SetProductNavigations(product, productDto);

            _repositoryManager.ProductRepository.Update(product);
            _repositoryManager.UnitOfWork.SaveChanges();

            return _mapper.Map<ProductReadDto>(product);
        }

        private void SetProductNavigations(Product product, object productDto)
        {
            product.Abrasion = _repositoryManager.AbrasionResistanceRepository.GetById((int)Helper.GetDynamicValue(productDto, "AbrasionId")!);

            product.Benefits = new HashSet<Benefit>();
            var benefitsFromDto = Helper.GetDynamicValue(productDto, "Benefits");
            SetProductBenefits(product, benefitsFromDto);

            product.Warranties = new HashSet<Warranty>();
            var warrantiesFromDto = Helper.GetDynamicValue(productDto, "Warranties");
            SetProductWarranties(product, warrantiesFromDto);
        }

        private void SetProductBenefits(Product product, dynamic? benefitsFromDto)
        {
            if (benefitsFromDto == null)
                return;

            foreach (var benefit in benefitsFromDto)
            {
                var benefitModel = _repositoryManager.BenefitRepository.GetById((int)Helper.GetDynamicValue(benefit, "Id"));
                if (benefitModel != null)
                {
                    product.Benefits.Add(benefitModel);
                }
            }
        }
        private void SetProductWarranties(Product product, dynamic? warrantiesFromDto)
        {
            if (warrantiesFromDto == null)
                return;

            foreach (var warranty in warrantiesFromDto)
            {
                int warrantyTitleId = (int)Helper.GetDynamicValue(warranty, "WarrantyTitleId");
                int warrantyLengthId = (int)Helper.GetDynamicValue(warranty, "WarrantyLengthId");
                int? warrantyNotabeneId = (int?)Helper.GetDynamicValue(warranty, "WarrantyNotabeneId");

                var warrantyModel = _repositoryManager.WarrantyRepository
                                        .Get(w => w.WarrantyTitle.Id == warrantyTitleId &&
                                                  w.WarrantyLength.Id == warrantyLengthId &&
                                                 (w.WarrantyNotabene != null ? w.WarrantyNotabene.Id : null) == warrantyNotabeneId)
                                        .FirstOrDefault();


                var warrantyTitleModel = _repositoryManager.WarrantyTitleRepository.GetById(warrantyTitleId);
                var warrantyLengthModel = _repositoryManager.WarrantyLengthRepository.GetById(warrantyLengthId);
                var warrantyNotabeneModel = _repositoryManager.WarrantyNotabeneRepository.GetById((int)warrantyNotabeneId);

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
    }
}
