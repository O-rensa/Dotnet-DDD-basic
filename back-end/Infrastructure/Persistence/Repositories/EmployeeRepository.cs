using Domain.Employee;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _db;

        public EmployeeRepository(
                AppDbContext db
            )
        {
            _db = db;
        }

        public async Task<EmployeeId> CreateEmployee(Employee payload)
        {
            await _db.Employees.AddAsync(payload);
            return payload.Id;
        }

        public async Task<bool> UpdateEmployee(Employee payload)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(e => e.Id == payload.Id);

            if (employee is not null)
            {
                employee = new Employee(payload.Id, payload.Name, payload.Email, payload.Age);
            }

            return (employee is not null);
        }

        public async Task DeleteEmployee(EmployeeId id)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if (employee is not null)
            {
                _db.Employees.Remove(employee);
            }
        }

        public async Task<IEnumerable<EmployeeReadModel>> GetAllEmployees()
        {
            var result = await _db.Employees.Select(e => new EmployeeReadModel(e.Id, e.Name, e.Email, e.Age)).ToListAsync();

            return result.AsReadOnly();
        }

        public async Task<EmployeeReadModel?> GetByEmployeeId(EmployeeId id)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync();

            if (employee is not null)
            {
                return new EmployeeReadModel(employee.Id, employee.Name, employee.Email, employee.Age);
            }

            return null;
        }
    }
}
