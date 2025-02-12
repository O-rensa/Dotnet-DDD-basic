using Application.Employees.Dtos;
using Domain.Employee;
using Domain.Repositories;
using MediatR;

namespace Application.Employees.Commands
{
    public record UpdateEmployeeCommand(CreateOrEditEmployeeDto Employee): IRequest<bool>;

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _uow;

        public UpdateEmployeeCommandHandler(
                IEmployeeRepository employeeRepository,
                IUnitOfWork uow
            )
        {
            _employeeRepository = employeeRepository;
            _uow = uow;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeName = new EmployeeName(request.Employee.Lastname, request.Employee.Firstname, request.Employee.Middlename);
            var e = new Employee(new EmployeeId(request.Employee.Id!.Value), employeeName, request.Employee.Email, request.Employee.Age);
            var result = await _employeeRepository.UpdateEmployee(e);

            await _uow.SaveChangesAsync(cancellationToken);

            return result;
        }
    }
}
