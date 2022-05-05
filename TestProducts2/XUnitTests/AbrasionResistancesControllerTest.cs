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
    public class AbrasionResistancesControllerTest
    {
        private readonly AbrasionResistancesController _controller;
        private readonly TestHelper _testHelper;

        public AbrasionResistancesControllerTest()
        {
            _testHelper = new TestHelper();
            _testHelper.TestSeedData();
            _controller = new AbrasionResistancesController(_testHelper.ServiceManager);
        }

        [Fact]
        public async Task GetAllTest()
        {
            var result = await _controller.GetAll();

            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<AbrasionResistanceReadDto>>(list.Value);

            var listAbrasionResistances = list.Value as List<AbrasionResistanceReadDto>;

            Assert.True(listAbrasionResistances.Any());
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

            Assert.IsType<AbrasionResistanceReadDto>(validItem.Value);
            var abrasionReadDto = validItem.Value as AbrasionResistanceReadDto;

            //Assert.IsType<AbrasionResistanceReadDto>(invalidItem.Value);
            //var invalidModel = invalidItem.Value as AbrasionResistanceReadDto;

            Assert.Equal(validId, abrasionReadDto.Id);
        }

        [Fact]
        public async Task CreateTest()
        {
            //Arrange
            AbrasionResistanceCreateDto completeAbrasion = GenerateCreateDto();

            //Act
            var result = await _controller.Create(completeAbrasion);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);


            var castedResult = result.Result as OkObjectResult;
            Assert.IsType<AbrasionResistanceReadDto>(castedResult.Value);


            var abrasionReadDto = castedResult.Value as AbrasionResistanceReadDto;
            Assert.Equal(completeAbrasion.ProductType, abrasionReadDto.ProductType);
            //Assert.Equal(completeAbrasionResistance.Category, abrasionReadDto.CategoryId);


            //Arrange
            var incompleteAbrasion = new AbrasionResistanceCreateDto()
            {
                Descriptions = new HashSet<AbrasionResistanceDescriptionCreateDto>()
                                {
                                    new AbrasionResistanceDescriptionCreateDto() { Language = LanguageClass.en, Description = "Really Convenient and easy to assemble" },
                                    new AbrasionResistanceDescriptionCreateDto() { Language = LanguageClass.fr, Description = "Très pratique et facile à assembler" }
                                }
            };

            //Act
            _controller.ModelState.AddModelError("Product Type", "Product Type is a required filed");

            //Assert
            var badResponse = _controller.Create(incompleteAbrasion);
            Assert.IsType<BadRequestObjectResult>(badResponse.Result);

            var nullResponse = _controller.Create(null);
            Assert.IsType<BadRequestObjectResult>(nullResponse.Result);
        }

        [Theory]
        [InlineData(1, 10)]
        public async Task DeleteTest(int validId, int invalidId)
        {
            var notFoundResult = _controller.Delete(invalidId);

            Assert.IsType<NotFoundResult>(notFoundResult);

            Assert.Single(await _testHelper.ServiceManager.AbrasionResistanceService.GetAll());

            var noContentResult = _controller.Delete(validId);

            Assert.IsType<NoContentResult>(noContentResult);

            Assert.Empty(await _testHelper.ServiceManager.AbrasionResistanceService.GetAll());
        }

        //[Theory]
        //[InlineData(1, 10)]
        //public void UpdateTest(int validId, int invalidId)
        //{
        //    //Arrange
        //    AbrasionResistanceUpdateDto abrasionDto = GenerateUpdateDto();

        //    //Act
        //    var result = _controller.Update(validId, abrasionDto);

        //    //Assert
        //    Assert.IsType<OkObjectResult>(result.Result);
        //    var okObjectResult = result.Result as OkObjectResult;

        //    Assert.IsType<AbrasionResistanceReadDto>(okObjectResult.Value);
        //    var abrasionReadDto = okObjectResult.Value as AbrasionResistanceReadDto;

        //    Assert.Equal(abrasionDto.ProductType, abrasionReadDto.ProductType);

        //    var invalidResult = _controller.Update(invalidId, abrasionDto);
        //    Assert.IsType<NotFoundResult>(invalidResult.Result);
        //    //Arrange
        //    var incompleteAbrasionResistance = new AbrasionResistanceUpdateDto()
        //    {
        //        CategoryId = 1
        //    };

        //    //Act
        //    _controller.ModelState.AddModelError("Product Type", "Product Type is a required filed");

        //    //Assert
        //    var badResponse = _controller.Update(validId, incompleteAbrasionResistance);
        //    Assert.IsType<BadRequestObjectResult>(badResponse.Result);

        //    var nullResponse = _controller.Create(null);
        //    Assert.IsType<BadRequestObjectResult>(nullResponse.Result);
        //}        

        [Theory]
        [InlineData(1)]
        public async Task UpdateTest_ValidId_ValidDto_ReturnsOkObject(int validId)
        {
            AbrasionResistanceUpdateDto abrasionDto = GenerateUpdateDto();
            var result = await _controller.Update(validId, abrasionDto);

            Assert.IsType<OkObjectResult>(result.Result);
            var okObjectResult = result.Result as OkObjectResult;

            Assert.IsType<AbrasionResistanceReadDto>(okObjectResult.Value);
            var abrasionReadDto = okObjectResult.Value as AbrasionResistanceReadDto;

            Assert.Equal(abrasionDto.ProductType, abrasionReadDto.ProductType);
        }

        [Theory]
        [InlineData(1)]
        public void UpdateTest_InvalidDto_ReturnsBadRequest(int validId)
        {
            var incompleteAbrasion = new AbrasionResistanceUpdateDto()
            {
                Descriptions = new HashSet<AbrasionResistanceDescriptionUpdateDto>()
                                {
                                    new AbrasionResistanceDescriptionUpdateDto() { Language = LanguageClass.en, Description = "Really Convenient and easy to assemble" },
                                    new AbrasionResistanceDescriptionUpdateDto() { Language = LanguageClass.fr, Description = "Très pratique et facile à assembler" }
                                }
            };
            _controller.ModelState.AddModelError("Product Type", "Product Type is a required filed");

            var badResponse = _controller.Update(validId, incompleteAbrasion);
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
            AbrasionResistanceUpdateDto abrasionDto = GenerateUpdateDto();
            var invalidResult = _controller.Update(invalidId, abrasionDto);
            Assert.IsType<NotFoundResult>(invalidResult.Result);
        }

        [Theory]
        [InlineData(1)]
        public async Task PartialUpdateTest_ValidId_ValidPatchDoc_ReturnsOkObJect(int validId)
        {
            JsonPatchDocument<AbrasionResistanceUpdateDto> patchDoc = new JsonPatchDocument<AbrasionResistanceUpdateDto>();
            patchDoc.Replace(e => e.ProductType, "a patched product type");

            var result = await _controller.PartialUpdate(validId, patchDoc);

            Assert.IsType<OkObjectResult>(result.Result);
            var okObjectResult = result.Result as OkObjectResult;

            //Assert.IsType<AbrasionResistanceReadDto>(okObjectResult.Value);
            //var abrasionReadDto = okObjectResult.Value as AbrasionResistanceReadDto;

            //Assert.Equal(abrasionDto.ProductType, abrasionReadDto.ProductType);
        }

        private AbrasionResistanceCreateDto GenerateCreateDto()
        {

            return new AbrasionResistanceCreateDto
            {
                ProductType = "1",
                Descriptions = new HashSet<AbrasionResistanceDescriptionCreateDto>()
                                {
                                    new AbrasionResistanceDescriptionCreateDto() { Language = LanguageClass.en, Description = "Really Convenient and easy to assemble" },
                                    new AbrasionResistanceDescriptionCreateDto() { Language = LanguageClass.fr, Description = "Très pratique et facile à assembler" }
                                },
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Today.AddDays(1)
            };
        }  
        
        private AbrasionResistanceUpdateDto GenerateUpdateDto()
        {

            return new AbrasionResistanceUpdateDto
            {
                ProductType = "1",
                Descriptions = new HashSet<AbrasionResistanceDescriptionUpdateDto>()
                                {
                                    new AbrasionResistanceDescriptionUpdateDto() { Language = LanguageClass.en, Description = "Really Convenient and easy to assemble" },
                                    new AbrasionResistanceDescriptionUpdateDto() { Language = LanguageClass.fr, Description = "Très pratique et facile à assembler" }
                                },
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Today.AddDays(1)
            };
        }
    } 
}
    