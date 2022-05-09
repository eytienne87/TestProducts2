using API.Controllers;
using API.Dtos.Read;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using XUnitTests.TestsHelper;

namespace XUnitTests
{
    public class SecondBenefitsControllerTest
    {
        private readonly ProductsController _controller;
        private readonly TestHelper _testHelper;

        public SecondBenefitsControllerTest()
        {
            _testHelper = new TestHelper();
            _testHelper.TestSeedData();
            _controller = new ProductsController(_testHelper.ServiceManager);
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
    }
}
