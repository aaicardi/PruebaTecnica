

namespace XianaCore.Backend.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using XianaCore.Application.Abstract;
    using XianaCore.Application.DTO;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService service;
        public EmployeesController(IEmployeesService service)
        {
            this.service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(EmployeesDto), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<EmployeesDto>> GetAll()
        {
            return await this.service.GetEmployees();
        }
    }
}
