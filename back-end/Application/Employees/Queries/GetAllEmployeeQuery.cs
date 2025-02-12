using Application.Employees.Dtos;
using Domain.Repositories;
using MediatR;

namespace Application.Employees.Queries
{
    public record GetAllEmployeeQuery() : IRequest<IEnumerable<GetEmployeeSummaryDto>>;

    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<GetEmployeeSummaryDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeeQueryHandler(
                IEmployeeRepository employeeRepository
            )
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<GetEmployeeSummaryDto>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.GetAllEmployees();

            return result.Select(e => new GetEmployeeSummaryDto
                {
                    Id = e.Id.Value,
                    FullName = e.Name.GetFullName(),
                    Email = e.Email,
                    Age = e.Age
                })
                .ToList(); 
        }
    }
}
