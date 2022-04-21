using API.Controllers;
using API.Dtos.Create;
using API.Dtos.Profiles;
using API.Dtos.Read;
using API.Services.Abstractions;
using API.Services.Implementations;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnitTests.TestsHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTests
{
    public class BenefitsControllerTest
    {
        private readonly BenefitsController _controller;
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;
        private readonly IEnumerable<Benefit> _benefits;

        public BenefitsControllerTest()
        {
            _mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile<BenefitsProfile>();
                mc.AddProfile<MarketSegmentsProfile>();
                mc.AddProfile<CategoryOfBenefitsProfile>();
            }).CreateMapper();

            _benefits = DataInitializer.CreateRandomBenefits();

            var repositoryManagerStub = new Mock<IRepositoryManager>();

            repositoryManagerStub.Setup(rm => rm.BenefitRepository.GetAll())
                .Returns(_benefits);

            repositoryManagerStub.Setup(rm => rm.BenefitRepository.GetById(It.IsAny<int>()))
                .Returns((int id) => _benefits.FirstOrDefault(q => q.Id == id));

            repositoryManagerStub.Setup(rm => rm.CategoryOfBenefitRepository.GetById(It.IsAny<int>()))
                .Returns((int id) => _benefits.FirstOrDefault(q => q.Id == id));

            _serviceManager = new ServiceManager(repositoryManagerStub.Object, _mapper);
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

            Assert.True(listBenefits.Any());
        }

        [Theory]
        [InlineData(1, 10)]
        public void GetByIdTest(int validId, int invalidId)
        {
            //Arrange

            //Act
            var validResult = _controller.GetById(validId);
            var invalidResult = _controller.GetById(invalidId);

            //Assert
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
        public void CreateTest()
        {
            //OK RESULT TEST START

            //Arrange
            BenefitCreateDto completeBenefit = GenerateBenefit();

            //Act
            var result = _controller.Create(completeBenefit);

            //Assert
            Assert.IsType<OkObjectResult>(result);

            //value of the result
            var castedResult = result.Result as OkObjectResult;
            Assert.IsType<BenefitReadDto>(castedResult.Value);

            //check value of this book
            var benefitReadDto = castedResult.Value as BenefitReadDto;
            Assert.Equal(completeBenefit.ProductType, benefitReadDto.ProductType);

            //OK RESULT TEST END

            //BADREQUEST AND MODELSTATE ERROR TEST START

            //Arrange
            //var incompleteBook = new Book()
            //{
            //    Author = "Author",
            //    Description = "Description"
            //};

            //Act
            //_controller.ModelState.AddModelError("Title", "Title is a requried filed");
            //var badResponse = _controller.Post(incompleteBook);

            //Assert
            //Assert.IsType<BadRequestObjectResult>(badResponse);



            //BADREQUEST AND MODELSTATE ERROR TEST END
        }

        private BenefitCreateDto GenerateBenefit() {

            BenefitCreateDto benefit = new BenefitCreateDto
            {
                ProductType = "1",
                CategoryId = 1,
                //Descriptions = new HashSet<BenefitDescription>()
                //                {
                //                    new BenefitDescription() { Language = LanguageClass.en, Description = "Really Convenient and easy to assemble" },
                //                    new BenefitDescription() { Language = LanguageClass.fr, Description = "Très pratique et facile à assembler" }
                //                },
                //MarketSegments = new HashSet<MarketSegment>()
                //                {
                //                    new MarketSegment() {
                //                        UrlName = "/residential",
                //                        Descriptions = new HashSet<MarketSegmentDescription>()
                //                        {
                //                            new MarketSegmentDescription { Language = LanguageClass.en, Description = "Residential"  },
                //                            new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Résidentiel"  }
                //                        },
                //                    },
                //                    new MarketSegment() {
                //                        UrlName = "/government",
                //                        Descriptions = new HashSet<MarketSegmentDescription>()
                //                        {
                //                            new MarketSegmentDescription { Language = LanguageClass.en, Description = "Government"  },
                //                            new MarketSegmentDescription { Language = LanguageClass.fr, Description = "Gouvernement"  }
                //                        },
                //                    },
                //                },
                //Category = new CategoryOfBenefit
                //{
                //    Descriptions = new HashSet<CategoryOfBenefitDescription>()
                //                    {
                //                        new CategoryOfBenefitDescription { Language = LanguageClass.en, Description = "Easy" },
                //                        new CategoryOfBenefitDescription { Language = LanguageClass.fr, Description = "Facile" }
                //                    },
                //    CreatedDate = DateTime.Now,
                //    UpdatedDate = DateTime.Today.AddDays(1)
                //},
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Today.AddDays(1)
            };
            return benefit;
        }
    } 
}
    