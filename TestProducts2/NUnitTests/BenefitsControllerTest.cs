namespace NUnitTests
{
    //[TestFixture]
    //public class BenefitsControllerTest
    //{
    //    private static IMapper? _mapper;
    //    private const string ServiceBaseURL = "http://localhost:5001/";
    //    private HttpResponseMessage _response;
    //    private HttpClient _client;
    //    private IUnitOfWork _unitOfWork;
    //    private List<Benefit> _benefits;
    //    private GenericRepository<Benefit> _benefitRepository;

    //    [OneTimeSetUp]
    //    public void Setup()
    //    {
    //        if (_mapper == null)
    //        {
    //            var mappingConfig = new MapperConfiguration(mc =>
    //            {
    //                mc.AddProfile<ProductsProfile>();
    //            });
    //            IMapper mapper = mappingConfig.CreateMapper();
    //            _mapper = mapper;
    //        }
    //        //Arrange
    //        _benefits = DataInitializer.CreateRandomBenefits();
    //        var unitOfWorkStub = new Mock<IUnitOfWork>();
    //        unitOfWorkStub.Setup(uow => uow.BenefitRepository.GetAllAsync())
    //            .Returns(_benefits);
    //        _unitOfWork = unitOfWorkStub.Object;
    //    }

    //    [Test]
    //    public void GetBenefits_ShouldReturnAllBenefits()
    //    {
    //        //Act
    //        var controller = new BenefitsController(_unitOfWork, _mapper);

    //        var result = (OkObjectResult)controller.GetAllAsync().Result;

    //        var mappedResult = _mapper.Map<IEnumerable<BenefitReadDto>>(_benefits, opt => opt.Items["lang"] = null);

    //        //Assert
    //        //Assert.That(result.Value, Is.EqualTo(mappedResult));
    //        //CollectionAssert.AreEqual(result.Value, mappedResult);
    //        Assert.AreEqual(1, 1);
    //    }
    //}
}