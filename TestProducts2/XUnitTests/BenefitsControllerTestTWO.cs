using API.Dtos.Read;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;
using XUnitTests.TestsHelper;

namespace XUnitTests
{
    public class BenefitsControllerTestTWO
    {

        private HttpClient _httpClient = null!;

        [Theory]
        [InlineData(1)]
        public async Task GetById_HappyPath(int Id)
        {
            await using var application = new TestApiApplication();
            var client = application.CreateClient();
            var response = await client.GetFromJsonAsync<ActionResult<BenefitReadDto>>($"http://localhost:5001/api/benefits/{Id}");
            Assert.NotNull(response);
        }

        //[Fact]
        //public Task GetProfile_ProfileNotFoundException_404()
        //{
        //    return AssertThatGetFullProfileHandlesGivenException(
        //        givenException: new ProfileNotFoundException("foo"),
        //        resultingStatusCode: HttpStatusCode.NotFound);
        //}

        //[Fact]
        //public Task GetProfile_StorageUnavailableException_503()
        //{
        //    return AssertThatGetFullProfileHandlesGivenException(
        //        givenException: new StorageUnavailableException($"database is down"),
        //        resultingStatusCode: HttpStatusCode.ServiceUnavailable);
        //}

        //[Fact]
        //public Task GetProfile_EmployerServiceUnavailableException_503()
        //{
        //    return AssertThatGetFullProfileHandlesGivenException(
        //        givenException: new EmployerServiceUnavailableException($"database is down"),
        //        resultingStatusCode: HttpStatusCode.ServiceUnavailable);
        //}

        //private async Task AssertThatGetFullProfileHandlesGivenException(Exception givenException, HttpStatusCode resultingStatusCode)
        //{
        //    var username = "foo";

        //    _profileServiceMock.Setup(profileService => profileService.GetFullProfile(username))
        //        .ThrowsAsync(givenException);

        //    var response = await _httpClient.GetAsync($"api/profile/{username}");
        //    Assert.Equal(resultingStatusCode, response.StatusCode);
        //}
    }

}

