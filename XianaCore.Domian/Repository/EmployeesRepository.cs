

namespace XianaCore.Domian.Repository
{
    using Newtonsoft.Json;

    using System;
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
            var objHeaders = new Dictionary<string, string>
            {
                { "Accept", "application/json" }
            };
            var result = await _externalServiceFacade
                .GetRestServiceAsync<string>("http://masglobaltestapi.azurewebsites.net",
                    "api/Employees", new Dictionary<string, string>(), objHeaders, string.Empty);
            if (string.IsNullOrEmpty(result))
            {
                return new List<Employees>();
            }
            var serializer = JsonConvert.DeserializeObject<IEnumerable<Employees>>(result);
            return serializer;
        }
    }
}
