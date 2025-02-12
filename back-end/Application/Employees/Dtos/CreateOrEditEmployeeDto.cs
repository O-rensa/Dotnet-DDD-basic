using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employees.Dtos
{
    public class CreateOrEditEmployeeDto
    {
        public Guid? Id { get; set; }

        [Required] public string Firstname { get; set; } = string.Empty;

        public string? Middlename { get; set; }

        [Required] public string Lastname { get; set; } = string.Empty;

        [Required] public string Email { get; set; } = string.Empty;

        [Required][Range(18, 100)] public int Age { get; set; }
    }
}
