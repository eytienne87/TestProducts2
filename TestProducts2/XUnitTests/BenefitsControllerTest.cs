using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnitTests.TestsHelper;
using System.Collections.Generic;
using TestProducts2.Controllers;
using TestProducts2.Dtos.Profiles;
using TestProducts2.Services.Abstractions;
using TestProducts2.Services.Implementations;
using Xunit;

namespace XUnitTests
{
    public class BenefitsControllerTest
    {
        private readonly BenefitsController _controller;
        private readonly IServiceManager _serviceManager;

        public BenefitsControllerTest()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<BenefitsProfile>();
                mc.AddProfile<MarketSegmentsProfile>();
                mc.AddProfile<CategoryOfBenefitsProfile>();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            
            IEnumerable<Benefit> benefits = (IEnumerable<Benefit>)DataInitializer.CreateRandomBenefits();
            var repositoryManagerStub = new Mock<IRepositoryManager>();

            repositoryManagerStub.Setup(rm => rm.BenefitRepository.GetAll())
                .Returns(benefits);

            _serviceManager = new ServiceManager(repositoryManagerStub.Object, mapper);
            _controller = new BenefitsController(_serviceManager);
        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange
            var result = _controller.GetAll();
            //Act
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<Benefit>>(list.Value);

            var listBenefits = list.Value as List<Benefit>;

            Assert.Equal(5, listBenefits.Count);
        }
    }
}