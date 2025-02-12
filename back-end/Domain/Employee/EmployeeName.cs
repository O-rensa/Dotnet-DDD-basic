namespace Domain.Employee
{
    public record EmployeeName(string Lastname, string Firstname, string? Middlename = null)
    {
        public string GetFullName(bool useMiddleInitial = false)
        {
            if (Middlename is not null)
            {
                var middle = useMiddleInitial ? Middlename.First().ToString() : Middlename;

                return Firstname + " " + middle + " " + Lastname;
            }

            return Firstname + " " + Lastname;
        }
    }
}
