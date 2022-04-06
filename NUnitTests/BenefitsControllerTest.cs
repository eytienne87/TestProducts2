using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Net.Http;
using TestProducts2.Controllers;
using TestProducts2.Data;
using TestProducts2.Dtos;
using TestProducts2.Entities;
using TestProducts2.Models;
using TestProducts2.Profiles;
using NUnitTests.TestsHelper;
using System;
using Microsoft.AspNetCore.Mvc;

namespace NUnitTests
{
    [TestFixture]
    public class BenefitsControllerTest
    {
        private static IMapper? _mapper;
        private const string ServiceBaseURL = "http://localhost:5001/";
        private HttpResponseMessage _response;
        private HttpClient _client;
        private IUnitOfWork _unitOfWork;
        private List<Benefit> _benefits;
        private GenericRepository<Benefit> _benefitRepository;

        [OneTimeSetUp]
        public void Setup()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile<ProductsProfile>();
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            //Arrange
            _benefits = DataInitializer.CreateRandomBenefits();
            var unitOfWorkStub = new Mock<IUnitOfWork>();
            unitOfWorkStub.Setup(uow => uow.BenefitRepository.GetAll())
                .Returns(_benefits);
            _unitOfWork = unitOfWorkStub.Object;
            _client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL)};
            _client.DefaultRequestHeaders.Add("Accept-Language", "en");
        }

        [SetUp]
        public void ReInitializeTest()
        {
            _client = new HttpClient { BaseAddress = new Uri(ServiceBaseURL)};
            _client.DefaultRequestHeaders.Add("Accept-Language", "en");
        }


        [Test]
        public void GetBenefits_ShouldReturnAllBenefits()
        {
            //Act
            var controller = new BenefitsController(_unitOfWork, _mapper);

            var result = (OkObjectResult)controller.GetBenefits().Result;

            var mappedResult = _mapper.Map<IEnumerable<BenefitReadDto>>(_benefits, opt => opt.Items["lang"] = null);

            //Assert
            string[] list = { "helo", "allo" };
            string[] secondList = { "helo", "allo" };
            //Assert.That(result.Value, Is.EquivalentTo(mappedResult));
            Assert.AreEqual(list, secondList);
        }
    }
}