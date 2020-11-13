

namespace XianaCore.Application.Abstract
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using XianaCore.Application.DTO;
    public interface IEmployeesService
    {
        Task<IEnumerable<EmployeesDto>> GetEmployees();
    }
}
