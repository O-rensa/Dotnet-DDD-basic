namespace Application.Employees.Dtos
{
    public class GetEmployeeSummaryDto
    {
        public Guid? Id { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public int? Age { get; set; }
    }
}
