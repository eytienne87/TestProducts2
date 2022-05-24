using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitTests.TestsHelper;
using static XUnitTests.TestsHelper.RoutesHelper;

namespace XUnitTests
{
    public class BenefitsControllerTest
    {

        private HttpClient _client = new HttpClient();
        private string Controller = "benefits";

        public BenefitsControllerTest()
        {
            var application = new TestApiApplication();
            _client = application.CreateClient();
        }

        [Theory]
        [InlineData(1)]
        public async Task GetById_Success(int Id)
        {
            var response = await _client.GetAsync($"{TestServerName}/{Controller}/{Id}");
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var result = await GetTestJsonObject<BenefitReadDto>(response);

            Assert.Equal(Id, result.Id);
            Assert.Equal(2, result.Descriptions.Count);
            Assert.NotEmpty(result.ProductType);
        }      
        
        [Fact]
        public async Task GetAll_Success()
        {
            var response = await _client.GetAsync($"{TestServerName}/{Controller}");
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var results = await GetTestJsonObject<IEnumerable<BenefitReadDto>>(response);

            Assert.True(results.Any());
        }      
       
        
        [Theory]
        [InlineData(100)]
        public async Task GetById_Failure(int Id)
        {
            var response = await _client.GetAsync($"{TestServerName}/{Controller}/{Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Create_Success()
        {
            var body = GenerateCreateDto();
            var response = await _client.PostAsJsonAsync($"{TestServerName}/{Controller}", body);
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var result = await GetTestJsonObject<BenefitReadDto>(response);

            Assert.Equal(2, result.Descriptions.Count);
            Assert.NotEmpty(result.ProductType);
        }
        [Fact]
        public async Task Create_Failure()
        {
            var response = await _client.PostAsJsonAsync($"{TestServerName}/{Controller}", new { });
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        public async Task Update_Success(int Id)
        {
            var body = GenerateUpdateDto();
            var response = await _client.PutAsJsonAsync($"{TestServerName}/{Controller}/{Id}", body);
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }       
        
        [Theory]
        [InlineData(100)]
        public async Task Update_NotFound_Failure(int Id)
        {
            var body = GenerateUpdateDto();
            var response = await _client.PutAsJsonAsync($"{TestServerName}/{Controller}/{Id}", body);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        
        [Theory]
        [InlineData(1)]
        public async Task Update_BadRequest_Failure(int Id)
        {
            var response = await _client.PutAsJsonAsync($"{TestServerName}/{Controller}/{Id}", new { });

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Theory]
        [InlineData(1)]
        public async Task Delete_Success(int Id)
        {
            var response = await _client.DeleteAsync($"{TestServerName}/{Controller}/{Id}");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Theory]
        [InlineData(100)]
        public async Task Delete_Failure(int Id)
        {
            var response = await _client.DeleteAsync($"{TestServerName}/{Controller}/{Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        
        [Theory]
        [InlineData(1)]
        public async Task Partial_Update_Success(int Id)
        {
            var patchDoc = new JsonPatchDocument<BenefitUpdateDto>();
            patchDoc.Replace(e => e.ProductType, "1, 2 & X");

            var serializedDoc = JsonConvert.SerializeObject(patchDoc);
            var requestContent = new StringContent(serializedDoc, Encoding.UTF8, "application/json-patch+json");

            var patchResponse = await _client.PatchAsync($"{TestServerName}/{Controller}/{Id}", requestContent);
            patchResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, patchResponse.StatusCode);

            var getResponse = await _client.GetAsync($"{TestServerName}/{Controller}/{Id}");
            getResponse.EnsureSuccessStatusCode();
            var result = await GetTestJsonObject<BenefitReadDto>(getResponse);

            Assert.Equal("1, 2 & X", result.ProductType);
        }
        
        [Theory]
        [InlineData(100)]
        public async Task Partial_Update_NotFound_Failure(int Id)
        {
            var patchDoc = new JsonPatchDocument<BenefitUpdateDto>();
            patchDoc.Replace(e => e.ProductType, "1, 2 & X");

            var serializedDoc = JsonConvert.SerializeObject(patchDoc);
            var requestContent = new StringContent(serializedDoc, Encoding.UTF8, "application/json-patch+json");

            var patchResponse = await _client.PatchAsync($"{TestServerName}/{Controller}/{Id}", requestContent);
            Assert.Equal(HttpStatusCode.NotFound, patchResponse.StatusCode);
        }

        private BenefitCreateDto GenerateCreateDto()
        {
            return new BenefitCreateDto
            {
                ProductType = "1",
                Descriptions = new HashSet<BenefitDescriptionCreateDto>()
                                {
                                    new BenefitDescriptionCreateDto() { Language = LanguageClass.en, Description = "Really Convenient and easy to assemble" },
                                    new BenefitDescriptionCreateDto() { Language = LanguageClass.fr, Description = "Très pratique et facile à assembler" }
                                },
                MarketSegments = new HashSet<MarketSegmentCreateDto>()
                                {
                                    new MarketSegmentCreateDto() {
                                        Descriptions = new HashSet<MarketSegmentDescriptionCreateDto>()
                                        {
                                            new MarketSegmentDescriptionCreateDto { Language = LanguageClass.en, Description = "Residential"  },
                                            new MarketSegmentDescriptionCreateDto { Language = LanguageClass.fr, Description = "Résidentiel"  }
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
                Category = new CategoryOfBenefitCreateDto
                {
                    Descriptions = new HashSet<CategoryOfBenefitDescriptionCreateDto>()
                                    {
                                        new CategoryOfBenefitDescriptionCreateDto { Language = LanguageClass.en, Description = "Easy" },
                                        new CategoryOfBenefitDescriptionCreateDto { Language = LanguageClass.fr, Description = "Facile" }
                                    },
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Today.AddDays(1)
                },
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Today.AddDays(1)
            };
        } 
        private BenefitUpdateDto GenerateUpdateDto()
        {
            return new BenefitUpdateDto
            {
                ProductType = "1",
                Descriptions = new HashSet<BenefitDescriptionUpdateDto>()
                                {
                                    new BenefitDescriptionUpdateDto() { Language = LanguageClass.en, Description = "Really Convenient and easy to assemble" },
                                    new BenefitDescriptionUpdateDto() { Language = LanguageClass.fr, Description = "Très pratique et facile à assembler" }
                                },
                MarketSegments = new HashSet<MarketSegmentUpdateDto>()
                                {
                                    new MarketSegmentUpdateDto() {
                                        Descriptions = new HashSet<MarketSegmentDescriptionUpdateDto>()
                                        {
                                            new MarketSegmentDescriptionUpdateDto { Language = LanguageClass.en, Description = "Residential"  },
                                            new MarketSegmentDescriptionUpdateDto { Language = LanguageClass.fr, Description = "Résidentiel"  }
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
                Category = new CategoryOfBenefitUpdateDto
                {
                    Descriptions = new HashSet<CategoryOfBenefitDescriptionUpdateDto>()
                                    {
                                        new CategoryOfBenefitDescriptionUpdateDto { Language = LanguageClass.en, Description = "Easy" },
                                        new CategoryOfBenefitDescriptionUpdateDto { Language = LanguageClass.fr, Description = "Facile" }
                                    },
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Today.AddDays(1)
                },
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Today.AddDays(1)
            };
        }
    }
}

