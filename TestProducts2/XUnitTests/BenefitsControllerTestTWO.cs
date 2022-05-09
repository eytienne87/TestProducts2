using API.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

public class BenefitsControllerTestTWO : IAsyncLifetime
{
    //private readonly Mock<IProfileService> _profileServiceMock = new();
    //private readonly AppTestFixture _fixture;

    private HttpClient _httpClient = null!;

    public async Task InitializeAsync()
    {
        using var hostBuilder = await new HostBuilder()
            .ConfigureWebHost(webHostBuilder =>
            {
                webHostBuilder.UseTestServer().ConfigureServices(services =>
                {
                    services.AddMyServices();
                })
                .Configure(app =>
                {
                    app.UseMiddleware<ExceptionMiddleware>();
                });
         }).StartAsync();

        _httpClient = hostBuilder.GetTestClient();
    }

    //public Task DisposeAsync()
    //{
    //    return Task.CompletedTask;
    //}

    [Theory]
    [InlineData(1)]
    public async Task GetById_HappyPath(int Id)
    {
        var response = await _httpClient.GetAsync($"/api/benefits/{Id}");
        var responseTwo = await _httpClient.GetAsync($"http://localhost:5001/api/benefits/{Id}");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        //var returnedJson = await response.Content.ReadAsStringAsync();
        //var returnedBenefit = JsonConvert.DeserializeObject<BenefitReadDto>(returnedJson);
        //Assert.Equal(profile, returnedBenefit);
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
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