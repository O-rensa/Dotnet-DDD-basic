using Domain.Employee;
using Domain.Repositories;
using MediatR;

namespace Application.Employees.Commands
{
    public record DeleteEmployeeCommand(Guid id) : IRequest<bool>;

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _uow;

        public DeleteEmployeeCommandHandler(
                IEmployeeRepository employeeRepository,
                IUnitOfWork uow
            )
        {
            _employeeRepository = employeeRepository;
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            await _employeeRepository.DeleteEmployee(new EmployeeId(request.id));

            await _uow.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
