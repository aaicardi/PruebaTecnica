

namespace XianaCore.Application.Tests.Implements
{
    using Moq;

    using NUnit.Framework;

    using System.Threading.Tasks;

    using XianaCore.Domian.IRepository;
    [TestFixture]
    public class EmployeesServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IEmployeesRepository> mockEmployeesRepositorypRepository;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockEmployeesRepositorypRepository = this.mockRepository.Create<IEmployeesRepository>();
        }

        //private EmployeesService CreateService()
        //{
        //    //return new IEmployeesService(
        //    //    this.mockCategoryGroupRepository.Object);
        //    return new IEmployeesService();
        //}

        [Test]
        [Author("Alex Jhoel Aicardi")]
        public async Task Add_StateUnderTest_ExpectedBehavior()
        {
            //// Arrange
            //var service = this.CreateService();
            //CategoryGroupDto dto = new CategoryGroupDto()
            //{
            //    Id = 1,
            //    Description = "Obrero"
            //};

            //this.mockCategoryGroupRepository.Setup(s => s.Add(It.IsAny<CategoryGroup>())).ReturnsAsync(1);

            //// Act
            //var result = await service.Add(
            //    dto);

            //// Assert
            //Assert.AreEqual(1, result);
            //this.mockRepository.VerifyAll();
        }


    }
}
