

namespace XianaCore.Application.Tests.Implements
{
    using Moq;

    using NUnit.Framework;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    using XianaCore.Application.Abstract;
    using XianaCore.Application.DTO;
    using XianaCore.Application.Implements;
    using XianaCore.Common.Mapper;
    using XianaCore.Domian.Facade;
    using XianaCore.Domian.IRepository;
    using XianaCore.Infrastructure.Entities;

    [TestFixture]
    public class EmployeesServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IEmployeesRepository> mockEmployeesRepositorypRepository;
        private Mock<ICalculatedAnnualSalaryService> mockICalculatedAnnualSalaryService;
        private Mock<IExternalServiceFacade> mockExternalServiceFacade;
        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockEmployeesRepositorypRepository = this.mockRepository.Create<IEmployeesRepository>();
            this.mockICalculatedAnnualSalaryService = this.mockRepository.Create<ICalculatedAnnualSalaryService>();
            this.mockExternalServiceFacade = this.mockRepository.Create<IExternalServiceFacade>();
        }

        private EmployeesService CreateService()
        {
            SettingAutomapper.CreateMaps();
            return new EmployeesService(
                this.mockEmployeesRepositorypRepository.Object,
                  this.mockICalculatedAnnualSalaryService.Object
                );
      
        }

        [Test]
        [Author("Alex Jhoel Aicardi")]
        public async Task Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange

            var service = this.CreateService();
          
            
            this.mockEmployeesRepositorypRepository.Setup(s => s.GetEmployees()).ReturnsAsync(GetAllEmployees());

            this.mockICalculatedAnnualSalaryService.Setup(s => s.GetSalary(It.IsAny<EmployeesDto>()));
            // this.mockICalculatedAnnualSalaryService.Setup(s => s.GetSalary(It.IsAny<EmployeesDto>())).ReturnsAsync(Task.CompletedTask);



            // Act
            var result = await service.GetEmployees();

            // Assert
            Assert.AreEqual(1, result);
            this.mockRepository.VerifyAll();
        }

        internal virtual IEnumerable<Employees> GetAllEmployees()
        {

            return new List<Employees>
             {
                new Employees()
                {
                      Id=1,
                      Name = "Juan"


                },
                new Employees()
                {
                     Id=2,
                     Name = "Sebastian"

                }
            };
        }


    }
}
