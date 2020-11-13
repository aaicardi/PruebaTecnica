

namespace XianaCore.Domian.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using XianaCore.Domian.Facade;
    using XianaCore.Domian.IRepository;
    using XianaCore.Infrastructure.Entities;

    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly IExternalServiceFacade _externalServiceFacade;
        public EmployeesRepository(IExternalServiceFacade externalServiceFacade)
        {
            _externalServiceFacade = externalServiceFacade;
        }

        public async Task<IEnumerable<Employees>> GetEmployees()
        {

            try
            {
                var objHeaders = new Dictionary<string, string>
            {
                { string.Empty, string.Empty }
            };

                var result = await _externalServiceFacade
                    .GetRestServiceAsync<ServiceResponse<List<Employees>>>(string.Empty,
                        string.Empty, new Dictionary<string, string>(), objHeaders, string.Empty);
            }
            catch
            {
                // ignored
            }

            return new List<Employees>();
        }
    }
}
