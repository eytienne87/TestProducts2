//using API.Controllers;
//using API.Dtos.Create;
//using API.Dtos.Read;
//using API.Dtos.Update;
//using Domain.Shared;
//using Microsoft.AspNetCore.JsonPatch;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Xunit;
//using XUnitTests.TestsHelper;

//namespace XUnitTests
//{
//    public class BenefitsControllerTest
//    {
//        private readonly BenefitsController _controller;
//        private readonly TestHelper _testHelper;

//        public BenefitsControllerTest()
//        {
//            _testHelper = new TestHelper();
//            _testHelper.TestSeedData();
//            _controller = new BenefitsController(_testHelper.ServiceManager);
//        }

//        [Fact]
//        public async Task GetAllTest()
//        {
//            var result = await _controller.GetAll();
//            Assert.IsType<OkObjectResult>(result.Result);

//            var list = result.Result as OkObjectResult;

//            Assert.IsType<List<BenefitReadDto>>(list.Value);

//            var listBenefits = list.Value as List<BenefitReadDto>;

//            Assert.True(listBenefits.Any());
//        }

//        [Theory]
//        [InlineData(10)]
//        public void GetByIdTest_ReturnsNotFound(int invalidId)
//        {
//            var invalidResult = _controller.GetById(invalidId);

//            Assert.IsType<NotFoundResult>(invalidResult.Result);
//        }     
        
//        [Theory]
//        [InlineData(1)]
//        public async Task GetByIdTest_ReturnsOkObject(int validId)
//        {
//            var validResult = await _controller.GetById(validId);

//            Assert.IsType<OkObjectResult>(validResult.Result);
//            var validItem = validResult.Result as OkObjectResult;

//            Assert.IsType<BenefitReadDto>(validItem.Value);
//            var productReadDto = validItem.Value as BenefitReadDto;

//            Assert.Equal(validId, productReadDto.Id);
//        }

//        [Fact]
//        public async Task CreateTest()
//        {
//            BenefitCreateDto completeBenefit = GenerateCreateDto();

//            var result = await _controller.Create(completeBenefit);

//            Assert.IsType<OkObjectResult>(result.Result);

//            var castedResult = result.Result as OkObjectResult;
//            Assert.IsType<BenefitReadDto>(castedResult.Value);

          
//            var BenefitReadDto = castedResult.Value as BenefitReadDto;
//            Assert.Equal(completeBenefit.ProductType, BenefitReadDto.ProductType);

//            var incompleteBenefit = new BenefitCreateDto()
//            {
//                AbrasionId = 1
//            };

//            _controller.ModelState.AddModelError("Benefit Type", "Benefit Type is a required filed");

//            var badResponse = _controller.Create(incompleteBenefit);
//            Assert.IsType<BadRequestObjectResult>(badResponse.Result);
            
//            var nullResponse = _controller.Create(null);
//            Assert.IsType<BadRequestObjectResult>(nullResponse.Result);
//        }

//        [Theory]
//        [InlineData(1, 10)]
//        public async Task DeleteTest(int validId, int invalidId)
//        {
//            //Arrange

//            //Act
//            var notFoundResult = _controller.Delete(invalidId);

//            //Assert
//            Assert.IsType<NotFoundResult>(notFoundResult);
//            //Assert.Equal(1, _testHelper.ServiceManager.BenefitService.GetAll().Count());
//            Assert.Single(await _testHelper.ServiceManager.BenefitService.GetAll());

//            //Act
//            var noContentResult = _controller.Delete(validId);

//            //Assert
//            Assert.IsType<NoContentResult>(noContentResult);
//            //Assert.Equal(0, _testHelper.ServiceManager.BenefitService.GetAll().Count());
//            Assert.Empty(await _testHelper.ServiceManager.BenefitService.GetAll());
//        }       
        
//        [Theory]
//        [InlineData(1)]
//        public async Task UpdateTest_ValidId_ValidDto_ReturnsOkObject(int validId)
//        {
//            BenefitUpdateDto productDto = GenerateUpdateDto();
//            var result = await _controller.Update(validId, productDto);

//            Assert.IsType<OkObjectResult>(result.Result);
//            var okObjectResult = result.Result as OkObjectResult;

//            Assert.IsType<BenefitReadDto>(okObjectResult.Value);
//            var productReadDto = okObjectResult.Value as BenefitReadDto;

//            Assert.Equal(productDto.ProductType, productReadDto.ProductType);
//        } 
        
//        [Theory]
//        [InlineData(1)]
//        public void UpdateTest_InvalidDto_ReturnsBadRequest(int validId)
//        {
//            var incompleteBenefit = new BenefitUpdateDto() { AbrasionId = 1 };
//            _controller.ModelState.AddModelError("Benefit Type", "Benefit Type is a required filed");

//            var badResponse = _controller.Update(validId, incompleteBenefit);
//            Assert.IsType<BadRequestObjectResult>(badResponse.Result);
//        } 
        
//        [Theory]
//        [InlineData(1)]
//        public void UpdateTest_Null_ReturnsBadRequest(int validId)
//        {
//            var nullResponse = _controller.Update(validId, null);
//            Assert.IsType<BadRequestObjectResult>(nullResponse.Result);
//        } 
        
//        [Theory]
//        [InlineData(10)]
//        public void UpdateTest_InvalidId_ReturnsNotFound(int invalidId)
//        {
//            BenefitUpdateDto productDto = GenerateUpdateDto();
//            var invalidResult = _controller.Update(invalidId, productDto);
//            Assert.IsType<NotFoundResult>(invalidResult.Result);
//        }

//        [Theory]
//        [InlineData(1)]
//        public async Task PartialUpdateTest_ValidId_ValidPatchDoc_ReturnsOkObJect(int validId) 
//        {
//            JsonPatchDocument<BenefitUpdateDto> patchDoc = new JsonPatchDocument<BenefitUpdateDto>();
//            patchDoc.Replace(e => e.ProductType, "a patched product type");

//            var result = await _controller.PartialUpdate(validId, patchDoc);

//            Assert.IsType<OkObjectResult>(result.Result);
//            var okObjectResult = result.Result as OkObjectResult;

//            //Assert.IsType<BenefitReadDto>(okObjectResult.Value);
//            //var BenefitReadDto = okObjectResult.Value as BenefitReadDto;

//            //Assert.Equal(BenefitDto.BenefitType, BenefitReadDto.BenefitType);
//        }

//        private BenefitCreateDto GenerateCreateDto() {

//            return new BenefitCreateDto
//            {
//                ProductType = "1",
//                StyleCode = "1",
//                StyleName = "1",
//                AbrasionId = 1,
//                Benefits = new HashSet<BenefitCreateDto>()
//                                {
//                                    new BenefitCreateDto() {
//                                        Descriptions = new HashSet<BenefitDescriptionCreateDto>()
//                                        {
//                                            new BenefitDescriptionCreateDto { Language = LanguageClass.en, Description = "Economical"  },
//                                            new BenefitDescriptionCreateDto { Language = LanguageClass.fr, Description = "Économique"  }
//                                        },
//                                    },
//                                    new BenefitCreateDto() {
//                                        Descriptions = new HashSet<BenefitDescriptionCreateDto>()
//                                        {
//                                            new BenefitDescriptionCreateDto { Language = LanguageClass.en, Description = "Safe"  },
//                                            new BenefitDescriptionCreateDto { Language = LanguageClass.fr, Description = "Sécuritaire"  }
//                                        },
//                                    },
//                                },    
//                Warranties = new HashSet<WarrantyCreateDto>()
//                                {
//                                    new WarrantyCreateDto() {
//                                        WarrantyTitleId = 1,
//                                        WarrantyLengthId = 1,
//                                        WarrantyNotabeneId = 1,
//                                    },
//                                },
//            };
//        }       
//        private BenefitUpdateDto GenerateUpdateDto() {

//            return new BenefitUpdateDto
//            {
//                ProductType = "1",
//                StyleCode = "1",
//                StyleName = "1",
//                AbrasionId = 1,
//                Benefits = new HashSet<BenefitUpdateDto>()
//                                {
//                                    new BenefitUpdateDto() {
//                                        Descriptions = new HashSet<BenefitDescriptionUpdateDto>()
//                                        {
//                                            new BenefitDescriptionUpdateDto { Language = LanguageClass.en, Description = "Economical"  },
//                                            new BenefitDescriptionUpdateDto { Language = LanguageClass.fr, Description = "Économique"  }
//                                        },
//                                    },
//                                    new BenefitUpdateDto() {
//                                        Descriptions = new HashSet<BenefitDescriptionUpdateDto>()
//                                        {
//                                            new BenefitDescriptionUpdateDto { Language = LanguageClass.en, Description = "Safe"  },
//                                            new BenefitDescriptionUpdateDto { Language = LanguageClass.fr, Description = "Sécuritaire"  }
//                                        },
//                                    },
//                                },
//                Warranties = new HashSet<WarrantyUpdateDto>()
//                                {
//                                    new WarrantyUpdateDto() {
//                                        WarrantyTitleId = 1,
//                                        WarrantyLengthId = 1,
//                                        WarrantyNotabeneId = 1,
//                                    },
//                                },
//            };
//        }
//    } 
//}
    