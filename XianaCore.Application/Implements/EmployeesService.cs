

namespace XianaCore.Application.Implements
{
    using AutoMapper;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    using XianaCore.Application.Abstract;
    using XianaCore.Application.DTO;
    using XianaCore.Domian.IRepository;
    public class EmployeesService: IEmployeesService
    {
        private readonly IEmployeesRepository repository;
        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            this.repository = employeesRepository;
        }

        public async Task<IEnumerable<EmployeesDto>> GetEmployees()
        {   
            var entityList = await this.repository.GetEmployees();
            return Mapper.Map<IEnumerable<EmployeesDto>>(entityList);
        }
    }
}
