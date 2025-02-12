namespace Domain.Employee
{
    public record EmployeeReadModel(EmployeeId Id, EmployeeName Name, string Email, int Age);
}
