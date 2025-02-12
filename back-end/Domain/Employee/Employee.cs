namespace Domain.Employee
{
    public class Employee
    {
        public Employee(EmployeeId id, EmployeeName name, string email, int age)
        {
            Id = id;
            Name = name;
            Email = email;
            Age = age;
        }

        public EmployeeId Id { get; private set; } = null!;

        public EmployeeName Name { get; private set; } = null!;

        public string Email { get; private set; } = string.Empty;

        public int Age { get; private set; }
    }
}
