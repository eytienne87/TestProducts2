using API.Controllers;
using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using XUnitTests.TestsHelper;

namespace XUnitTests
{
    public class BenefitsControllerTest
    {
        private readonly BenefitsController _controller;
        private readonly TestHelper _testHelper;

        public BenefitsControllerTest()
        {
            _testHelper = new TestHelper();
            _testHelper.TestSeedData();
            _controller = new BenefitsController(_testHelper.ServiceManager);
        }

        [Fact]
        public async Task GetAllTest()
        {
            var result = await _controller.GetAll();
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<BenefitReadDto>>(list.Value);

            var listBenefits = list.Value as List<BenefitReadDto>;

            Assert.True(listBenefits.Any());
        }

        [Theory]
        [InlineData(1, 10)]
        public async Task GetByIdTest(int validId, int invalidId)
        {
            var validResult = await _controller.GetById(validId);
            var invalidResult = await _controller.GetById(invalidId);

            Assert.IsType<OkObjectResult>(validResult.Result);
            var validItem = validResult.Result as OkObjectResult;

            Assert.IsType<NotFoundResult>(invalidResult.Result);
            //var invalidItem = invalidResult.Result as OkObjectResult;

            Assert.IsType<BenefitReadDto>(validItem.Value);
            var benefitReadDto = validItem.Value as BenefitReadDto;

            //Assert.IsType<BenefitReadDto>(invalidItem.Value);
            //var invalidModel = invalidItem.Value as BenefitReadDto;

            Assert.Equal(validId, benefitReadDto.Id);
        }

        [Fact]
        public async Task CreateTest()
        {
            //Arrange
            BenefitCreateDto completeBenefit = GenerateCreateDto();

            //Act
            var result = await _controller.Create(completeBenefit);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

           
            var castedResult = result.Result as OkObjectResult;
            Assert.IsType<BenefitReadDto>(castedResult.Value);

          
            var benefitReadDto = castedResult.Value as BenefitReadDto;
            Assert.Equal(completeBenefit.ProductType, benefitReadDto.ProductType);
            //Assert.Equal(completeBenefit.Category, benefitReadDto.CategoryId);


            //Arrange
            var incompleteBenefit = new BenefitCreateDto()
            {
                CategoryId = 1
            };

            //Act
            _controller.ModelState.AddModelError("Product Type", "Product Type is a required filed");

            //Assert
            var badResponse = _controller.Create(incompleteBenefit);
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
            //Assert.Equal(1, _testHelper.ServiceManager.BenefitService.GetAll().Count());
            Assert.Single(await _testHelper.ServiceManager.BenefitService.GetAll());

            //Act
            var noContentResult = _controller.Delete(validId);

            //Assert
            Assert.IsType<NoContentResult>(noContentResult);
            //Assert.Equal(0, _testHelper.ServiceManager.BenefitService.GetAll().Count());
            Assert.Empty(await _testHelper.ServiceManager.BenefitService.GetAll());
        }       
        
        //[Theory]
        //[InlineData(1, 10)]
        //public void UpdateTest(int validId, int invalidId)
        //{
        //    //Arrange
        //    BenefitUpdateDto benefitDto = GenerateUpdateDto();

        //    //Act
        //    var result = _controller.Update(validId, benefitDto);

        //    //Assert
        //    Assert.IsType<OkObjectResult>(result.Result);
        //    var okObjectResult = result.Result as OkObjectResult;

        //    Assert.IsType<BenefitReadDto>(okObjectResult.Value);
        //    var benefitReadDto = okObjectResult.Value as BenefitReadDto;

        //    Assert.Equal(benefitDto.ProductType, benefitReadDto.ProductType);

        //    var invalidResult = _controller.Update(invalidId, benefitDto);
        //    Assert.IsType<NotFoundResult>(invalidResult.Result);
        //    //Arrange
        //    var incompleteBenefit = new BenefitUpdateDto()
        //    {
        //        CategoryId = 1
        //    };

        //    //Act
        //    _controller.ModelState.AddModelError("Product Type", "Product Type is a required filed");

        //    //Assert
        //    var badResponse = _controller.Update(validId, incompleteBenefit);
        //    Assert.IsType<BadRequestObjectResult>(badResponse.Result);

        //    var nullResponse = _controller.Create(null);
        //    Assert.IsType<BadRequestObjectResult>(nullResponse.Result);
        //}        
        
        [Theory]
        [InlineData(1)]
        public async Task UpdateTest_ValidId_ValidDto_ReturnsOkObject(int validId)
        {
            BenefitUpdateDto benefitDto = GenerateUpdateDto();
            var result = await _controller.Update(validId, benefitDto);

            Assert.IsType<OkObjectResult>(result.Result);
            var okObjectResult = result.Result as OkObjectResult;

            Assert.IsType<BenefitReadDto>(okObjectResult.Value);
            var benefitReadDto = okObjectResult.Value as BenefitReadDto;

            Assert.Equal(benefitDto.ProductType, benefitReadDto.ProductType);
        } 
        
        [Theory]
        [InlineData(1)]
        public void UpdateTest_InvalidDto_ReturnsBadRequest(int validId)
        {
            var incompleteBenefit = new BenefitUpdateDto() { CategoryId = 1 };
            _controller.ModelState.AddModelError("Product Type", "Product Type is a required filed");

            var badResponse = _controller.Update(validId, incompleteBenefit);
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
            BenefitUpdateDto benefitDto = GenerateUpdateDto();
            var invalidResult = _controller.Update(invalidId, benefitDto);
            Assert.IsType<NotFoundResult>(invalidResult.Result);
        }

        [Theory]
        [InlineData(1)]
        public async Task PartialUpdateTest_ValidId_ValidPatchDoc_ReturnsOkObJect(int validId) 
        {
            JsonPatchDocument<BenefitUpdateDto> patchDoc = new JsonPatchDocument<BenefitUpdateDto>();
            patchDoc.Replace(e => e.ProductType, "a patched product type");

            var result = await _controller.PartialUpdate(validId, patchDoc);

            Assert.IsType<OkObjectResult>(result.Result);
            var okObjectResult = result.Result as OkObjectResult;

            //Assert.IsType<BenefitReadDto>(okObjectResult.Value);
            //var benefitReadDto = okObjectResult.Value as BenefitReadDto;

            //Assert.Equal(benefitDto.ProductType, benefitReadDto.ProductType);
        }

        private BenefitCreateDto GenerateCreateDto() {

            return new BenefitCreateDto
            {
                ProductType = "1",
                CategoryId = 1,
                Descriptions = new HashSet<BenefitDescriptionCreateDto>()
                                {
                                    new BenefitDescriptionCreateDto() { Language = LanguageClass.en, Description = "Really Convenient and easy to assemble" },
                                    new BenefitDescriptionCreateDto() { Language = LanguageClass.fr, Description = "Tr�s pratique et facile � assembler" }
                                },
                MarketSegments = new HashSet<MarketSegmentCreateDto>()
                                {
                                    new MarketSegmentCreateDto() {
                                        Descriptions = new HashSet<MarketSegmentDescriptionCreateDto>()
                                        {
                                            new MarketSegmentDescriptionCreateDto { Language = LanguageClass.en, Description = "Residential"  },
                                            new MarketSegmentDescriptionCreateDto { Language = LanguageClass.fr, Description = "R�sidentiel"  }
                                        },
                                    },
                                    new MarketSegmentCreateDto() {
                                        Descriptions = new HashSet<MarketSegmentDescriptionCreateDto>()
                                        {
                                            new MarketSegmentDescriptionCreateDto { Language = LanguageClass.en, Description = "Government"  },
                                            new MarketSegmentDescriptionCreateDto { Language = LanguageClass.fr, Description = "Gouvernement"  }
                                        },
                                    },
                                },
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Today.AddDays(1)
            };
        }       
        private BenefitUpdateDto GenerateUpdateDto() {

            return new BenefitUpdateDto
            {
                ProductType = "1",
                CategoryId = 1,
                Descriptions = new HashSet<BenefitDescriptionUpdateDto>()
                                {
                                    new BenefitDescriptionUpdateDto() { Language = LanguageClass.en, Description = "Really Convenient and easy to assemble" },
                                    new BenefitDescriptionUpdateDto() { Language = LanguageClass.fr, Description = "Tr�s pratique et facile � assembler" }
                                },
                MarketSegments = new HashSet<MarketSegmentUpdateDto>()
                                {
                                    new MarketSegmentUpdateDto() {
                                        Descriptions = new HashSet<MarketSegmentDescriptionUpdateDto>()
                                        {
                                            new MarketSegmentDescriptionUpdateDto { Language = LanguageClass.en, Description = "Residential"  },
                                            new MarketSegmentDescriptionUpdateDto { Language = LanguageClass.fr, Description = "R�sidentiel"  }
                                        },
                                    },
                                    new MarketSegmentUpdateDto() {
                                        Descriptions = new HashSet<MarketSegmentDescriptionUpdateDto>()
                                        {
                                            new MarketSegmentDescriptionUpdateDto { Language = LanguageClass.en, Description = "Government"  },
                                            new MarketSegmentDescriptionUpdateDto { Language = LanguageClass.fr, Description = "Gouvernement"  }
                                        },
                                    },
                                },
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Today.AddDays(1)
            };
        }
    } 
}
    