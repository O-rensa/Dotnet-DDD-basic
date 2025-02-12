namespace Application.Employees.Dtos
{
    public class GetEmployeeDto
    {
        public Guid? Id { get; set; }

        public string? Firstname { get; set; }

        public string? Middlename { get; set; }

        public string? Lastname { get; set; }

        public string? Email { get; set; }

        public int? Age { get; set; }
    }
}
