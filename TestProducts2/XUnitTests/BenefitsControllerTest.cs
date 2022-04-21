using API.Controllers;
using API.Dtos.Profiles;
using API.Dtos.Read;
using API.Services.Abstractions;
using API.Services.Implementations;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnitTests.TestsHelper;
using System.Collections.Generic;
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

            Assert.IsType<List<BenefitReadDto>>(list.Value);

            var listBenefits = list.Value as List<BenefitReadDto>;

            Assert.True(listBenefits.Count > 0);
        }
    }
}