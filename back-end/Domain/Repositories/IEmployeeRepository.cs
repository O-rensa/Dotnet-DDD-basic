using Domain.Employee;

namespace Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeId> CreateEmployee(Employee.Employee payload);

        Task<bool> UpdateEmployee(Employee.Employee payload);

        Task DeleteEmployee(EmployeeId id);

        Task<IEnumerable<EmployeeReadModel>> GetAllEmployees();

        Task<EmployeeReadModel?> GetByEmployeeId(EmployeeId id);
    }
}
