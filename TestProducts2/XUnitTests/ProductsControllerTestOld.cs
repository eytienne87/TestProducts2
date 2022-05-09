using API.Controllers;
using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using XUnitTests.TestsHelper;

namespace XUnitTests
{
    public class ProductsControllerTestOld
    {
        private readonly ProductsController _controller;
        private readonly TestHelper _testHelper;

        public ProductsControllerTestOld()
        {
            _testHelper = new TestHelper();
            _testHelper.TestSeedData();
            _controller = new ProductsController(_testHelper.ServiceManager);
        }

        [Fact]
        public async Task GetAllTest()
        {
            var result = await _controller.GetAll();
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<ProductReadDto>>(list.Value);

            var listProducts = list.Value as List<ProductReadDto>;

            Assert.True(listProducts.Any());
        }

        [Theory]
        [InlineData(10)]
        public void GetByIdTest_ReturnsNotFound(int invalidId)
        {
            var invalidResult = _controller.GetById(invalidId);

            Assert.IsType<NotFoundResult>(invalidResult.Result);
        }     
        
        [Theory]
        [InlineData(1)]
        public async Task GetByIdTest_ReturnsOkObject(int validId)
        {
            var validResult = await _controller.GetById(validId);

            Assert.IsType<OkObjectResult>(validResult.Result);
            var validItem = validResult.Result as OkObjectResult;

            Assert.IsType<ProductReadDto>(validItem.Value);
            var productReadDto = validItem.Value as ProductReadDto;

            Assert.Equal(validId, productReadDto.Id);
        }

        [Fact]
        public async Task CreateTest()
        {
            ProductCreateDto completeProduct = GenerateCreateDto();

            var result = await _controller.Create(completeProduct);

            Assert.IsType<OkObjectResult>(result.Result);

            var castedResult = result.Result as OkObjectResult;
            Assert.IsType<ProductReadDto>(castedResult.Value);

          
            var ProductReadDto = castedResult.Value as ProductReadDto;
            Assert.Equal(completeProduct.ProductType, ProductReadDto.ProductType);

            var incompleteProduct = new ProductCreateDto()
            {
                AbrasionId = 1
            };

            _controller.ModelState.AddModelError("Product Type", "Product Type is a required filed");

            var badResponse = _controller.Create(incompleteProduct);
            Assert.IsType<BadRequestObjectResult>(badResponse.Result);
            
            var nullResponse = _controller.Create(null);
            Assert.IsType<BadRequestObjectResult>(nullResponse.Result);
        }

        [Theory]
        [InlineData(1, 10)]
        public async Task DeleteTest(int validId, int invalidId)
        {
            //Arrange

            //Act
            var notFoundResult = _controller.Delete(invalidId);

            //Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
            //Assert.Equal(1, _testHelper.ServiceManager.ProductService.GetAll().Count());
            Assert.Single(await _testHelper.ServiceManager.ProductService.GetAll());

            //Act
            var noContentResult = _controller.Delete(validId);

            //Assert
            Assert.IsType<NoContentResult>(noContentResult);
            //Assert.Equal(0, _testHelper.ServiceManager.ProductService.GetAll().Count());
            Assert.Empty(await _testHelper.ServiceManager.ProductService.GetAll());
        }       
        
        [Theory]
        [InlineData(1)]
        public async Task UpdateTest_ValidId_ValidDto_ReturnsOkObject(int validId)
        {
            ProductUpdateDto productDto = GenerateUpdateDto();
            var result = await _controller.Update(validId, productDto);

            Assert.IsType<OkObjectResult>(result.Result);
            var okObjectResult = result.Result as OkObjectResult;

            Assert.IsType<ProductReadDto>(okObjectResult.Value);
            var productReadDto = okObjectResult.Value as ProductReadDto;

            Assert.Equal(productDto.ProductType, productReadDto.ProductType);
        } 
        
        [Theory]
        [InlineData(1)]
        public void UpdateTest_InvalidDto_ReturnsBadRequest(int validId)
        {
            var incompleteProduct = new ProductUpdateDto() { AbrasionId = 1 };
            _controller.ModelState.AddModelError("Product Type", "Product Type is a required filed");

            var badResponse = _controller.Update(validId, incompleteProduct);
            Assert.IsType<BadRequestObjectResult>(badResponse.Result);
        } 
        
        [Theory]
        [InlineData(1)]
        public void UpdateTest_Null_ReturnsBadRequest(int validId)
        {
            var nullResponse = _controller.Update(validId, null);
            Assert.IsType<BadRequestObjectResult>(nullResponse.Result);
        } 
        
        [Theory]
        [InlineData(10)]
        public void UpdateTest_InvalidId_ReturnsNotFound(int invalidId)
        {
            ProductUpdateDto productDto = GenerateUpdateDto();
            var invalidResult = _controller.Update(invalidId, productDto);
            Assert.IsType<NotFoundResult>(invalidResult.Result);
        }

        [Theory]
        [InlineData(1)]
        public async Task PartialUpdateTest_ValidId_ValidPatchDoc_ReturnsOkObJect(int validId) 
        {
            JsonPatchDocument<ProductUpdateDto> patchDoc = new JsonPatchDocument<ProductUpdateDto>();
            patchDoc.Replace(e => e.ProductType, "a patched product type");

            var result = await _controller.PartialUpdate(validId, patchDoc);

            Assert.IsType<OkObjectResult>(result.Result);
            var okObjectResult = result.Result as OkObjectResult;

            //Assert.IsType<ProductReadDto>(okObjectResult.Value);
            //var ProductReadDto = okObjectResult.Value as ProductReadDto;

            //Assert.Equal(ProductDto.ProductType, ProductReadDto.ProductType);
        }

        private ProductCreateDto GenerateCreateDto() {

            return new ProductCreateDto
            {
                ProductType = "1",
                StyleCode = "1",
                StyleName = "1",
                AbrasionId = 1,
                Benefits = new HashSet<BenefitCreateDto>()
                                {
                                    new BenefitCreateDto() {
                                        Descriptions = new HashSet<BenefitDescriptionCreateDto>()
                                        {
                                            new BenefitDescriptionCreateDto { Language = LanguageClass.en, Description = "Economical"  },
                                            new BenefitDescriptionCreateDto { Language = LanguageClass.fr, Description = "Économique"  }
                                        },
                                    },
                                    new BenefitCreateDto() {
                                        Descriptions = new HashSet<BenefitDescriptionCreateDto>()
                                        {
                                            new BenefitDescriptionCreateDto { Language = LanguageClass.en, Description = "Safe"  },
                                            new BenefitDescriptionCreateDto { Language = LanguageClass.fr, Description = "Sécuritaire"  }
                                        },
                                    },
                                },    
                Warranties = new HashSet<WarrantyCreateDto>()
                                {
                                    new WarrantyCreateDto() {
                                        WarrantyTitleId = 1,
                                        WarrantyLengthId = 1,
                                        WarrantyNotabeneId = 1,
                                    },
                                },
            };
        }       
        private ProductUpdateDto GenerateUpdateDto() {

            return new ProductUpdateDto
            {
                ProductType = "1",
                StyleCode = "1",
                StyleName = "1",
                AbrasionId = 1,
                Benefits = new HashSet<BenefitUpdateDto>()
                                {
                                    new BenefitUpdateDto() {
                                        Descriptions = new HashSet<BenefitDescriptionUpdateDto>()
                                        {
                                            new BenefitDescriptionUpdateDto { Language = LanguageClass.en, Description = "Economical"  },
                                            new BenefitDescriptionUpdateDto { Language = LanguageClass.fr, Description = "Économique"  }
                                        },
                                    },
                                    new BenefitUpdateDto() {
                                        Descriptions = new HashSet<BenefitDescriptionUpdateDto>()
                                        {
                                            new BenefitDescriptionUpdateDto { Language = LanguageClass.en, Description = "Safe"  },
                                            new BenefitDescriptionUpdateDto { Language = LanguageClass.fr, Description = "Sécuritaire"  }
                                        },
                                    },
                                },
                Warranties = new HashSet<WarrantyUpdateDto>()
                                {
                                    new WarrantyUpdateDto() {
                                        WarrantyTitleId = 1,
                                        WarrantyLengthId = 1,
                                        WarrantyNotabeneId = 1,
                                    },
                                },
            };
        }
    } 
}
    