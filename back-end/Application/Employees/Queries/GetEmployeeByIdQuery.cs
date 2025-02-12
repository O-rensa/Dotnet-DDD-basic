using Application.Employees.Dtos;
using Domain.Repositories;
using MediatR;
using Domain.Employee;

namespace Application.Employees.Queries
{
    public record GetEmployeeByIdQuery(Guid id) : IRequest<GetEmployeeDto?>;

    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, GetEmployeeDto?>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(
                IEmployeeRepository employeeRepository
            )
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<GetEmployeeDto?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.GetByEmployeeId(new EmployeeId(request.id));

            if (result is not null)
            {
                return new GetEmployeeDto
                {
                    Id = result.Id.Value,
                    Firstname = result.Name.Firstname,
                    Middlename = result.Name.Middlename,
                    Lastname = result.Name.Lastname,
                    Email = result.Email,
                    Age = result.Age,
                };
            }

            return null;
        }
    }
}
