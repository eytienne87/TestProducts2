using API.Dtos.Create;
using API.Dtos.Read;
using API.Dtos.Update;
using Domain.Shared;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
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
    public class ProductsControllerTest
    {

        private HttpClient _client = null!;
        private string Controller = "products";

        public ProductsControllerTest()
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
            var result = await GetTestJsonObject<ProductReadDto>(response);

            Assert.Equal(Id, result.Id);
            Assert.Equal(2, result.Abrasion.Descriptions.Count);
            Assert.NotEmpty(result.ProductType);
        }

        [Fact]
        public async Task GetAll_Success()
        {
            var response = await _client.GetAsync($"{TestServerName}/{Controller}");
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var results = await GetTestJsonObject<IEnumerable<ProductReadDto>>(response);

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
            var result = await GetTestJsonObject<ProductReadDto>(response);

            Assert.Equal(2, result.Abrasion.Descriptions.Count);
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
            var patchDoc = new JsonPatchDocument<ProductUpdateDto>();
            patchDoc.Replace(e => e.ProductType, "1, 2 & X");

            var serializedDoc = JsonConvert.SerializeObject(patchDoc);
            var requestContent = new StringContent(serializedDoc, Encoding.UTF8, "application/json-patch+json");

            var patchResponse = await _client.PatchAsync($"{TestServerName}/{Controller}/{Id}", requestContent);
            patchResponse.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.NoContent, patchResponse.StatusCode);

            var getResponse = await _client.GetAsync($"{TestServerName}/{Controller}/{Id}");
            getResponse.EnsureSuccessStatusCode();
            var result = await GetTestJsonObject<ProductReadDto>(getResponse);

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

        private ProductCreateDto GenerateCreateDto()
        {

            return new ProductCreateDto
            {
                ProductType = "1",
                StyleCode = "1",
                StyleName = "1",
                AbrasionId = 1,
                Benefits = new HashSet<BenefitCreateDto>()
                                {
                                    new BenefitCreateDto() {
                                        Descriptions = new HashSet<BenefitDescriptionCreateDto>()
                                        {
                                            new BenefitDescriptionCreateDto { Language = LanguageClass.en, Description = "Economical"  },
                                            new BenefitDescriptionCreateDto { Language = LanguageClass.fr, Description = "Économique"  }
                                        },
                                    },
                                    new BenefitCreateDto() {
                                        Descriptions = new HashSet<BenefitDescriptionCreateDto>()
                                        {
                                            new BenefitDescriptionCreateDto { Language = LanguageClass.en, Description = "Safe"  },
                                            new BenefitDescriptionCreateDto { Language = LanguageClass.fr, Description = "Sécuritaire"  }
                                        },
                                    },
                                },
                Warranties = new HashSet<WarrantyCreateDto>()
                                {
                                    new WarrantyCreateDto() {
                                        WarrantyTitleId = 1,
                                        WarrantyLengthId = 1,
                                        WarrantyNotabeneId = 1,
                                    },
                                },
            };
        }
        private ProductUpdateDto GenerateUpdateDto()
        {

            return new ProductUpdateDto
            {
                ProductType = "1",
                StyleCode = "1",
                StyleName = "1",
                AbrasionId = 1,
                Benefits = new HashSet<BenefitUpdateDto>()
                                {
                                    new BenefitUpdateDto() {
                                        Descriptions = new HashSet<BenefitDescriptionUpdateDto>()
                                        {
                                            new BenefitDescriptionUpdateDto { Language = LanguageClass.en, Description = "Economical"  },
                                            new BenefitDescriptionUpdateDto { Language = LanguageClass.fr, Description = "Économique"  }
                                        },
                                    },
                                    new BenefitUpdateDto() {
                                        Descriptions = new HashSet<BenefitDescriptionUpdateDto>()
                                        {
                                            new BenefitDescriptionUpdateDto { Language = LanguageClass.en, Description = "Safe"  },
                                            new BenefitDescriptionUpdateDto { Language = LanguageClass.fr, Description = "Sécuritaire"  }
                                        },
                                    },
                                },
                Warranties = new HashSet<WarrantyUpdateDto>()
                                {
                                    new WarrantyUpdateDto() {
                                        WarrantyTitleId = 1,
                                        WarrantyLengthId = 1,
                                        WarrantyNotabeneId = 1,
                                    },
                                },
            };
        }

    }
}

