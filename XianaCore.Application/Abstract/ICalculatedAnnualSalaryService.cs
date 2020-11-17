

namespace XianaCore.Application.Abstract
{

    using XianaCore.Application.DTO;
    public interface ICalculatedAnnualSalaryService
    {
        long GetSalary(EmployeesDto employeesDto);
    }
}
