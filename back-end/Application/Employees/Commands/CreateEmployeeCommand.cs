using Domain.Employee;
using Domain.Repositories;
using MediatR;
using MediatR.Pipeline;

namespace Application.Employees.Commands
{
    public record CreateEmployeeCommand(Employee PEmployee) : IRequest<Employee>;

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPublisher _mediator;

        public CreateEmployeeCommandHandler(
                IEmployeeRepository employeeRepository,
                IPublisher mediator
            )
        {
            _employeeRepository = employeeRepository;
            _mediator = mediator;
        }

        public Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
