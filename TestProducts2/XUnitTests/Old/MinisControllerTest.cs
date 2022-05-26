//using API.Controllers;
//using API.Dtos.Profiles;
//using API.Dtos.Read;
//using API.Services.Abstractions;
//using API.Services.Implementations;
//using AutoMapper;
//using Domain.Interfaces;
//using Domain.Models;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using System.Collections.Generic;
//using System.Linq;
//using Xunit;
//using XUnitTests.TestsHelper;

//namespace XUnitTests
//{
//    public class MinisControllerTest
//    {
//        private readonly ProductMinisController _controller;
//        private readonly IServiceManager _serviceManager;
//        private readonly IMapper _mapper;
//        private readonly IEnumerable<Mini> _minis;

//        public MinisControllerTest()
//        {
//            _mapper = new MapperConfiguration(mc =>
//            {
//                mc.AddProfile<BenefitsProfile>();
//                mc.AddProfile<ProductMinisProfile>();
//            }).CreateMapper();

//            _minis = DataInitializer.CreateRandomMinis();

//            var repositoryManagerStub = new Mock<IRepositoryManager>();

//            repositoryManagerStub.Setup(rm => rm.MiniRepository.GetAll())
//                .Returns(_minis);

//            _serviceManager = new ServiceManager(repositoryManagerStub.Object, _mapper);
//            _controller = new ProductMinisController(_serviceManager);
//        }

//        [Fact]
//        public void GetAllTest()
//        {
//            //Arrange
//            var result = _controller.GetAll();
//            //Act
//            //Assert
//            Assert.IsType<OkObjectResult>(result.Result);

//            var list = result.Result as OkObjectResult;

//            Assert.IsType<List<ProductMiniReadDto>>(list.Value);

//            var listMinis = list.Value as List<ProductMiniReadDto>;

//            Assert.True(listMinis.Any());
//        }
//    } 
//}
    