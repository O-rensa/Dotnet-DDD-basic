namespace Domain.Employee
{
    public record EmployeeName
    {
        public string FName { get; private set; } = string.Empty;

        public string? MName { get; private set; }

        public string LName { get; private set; } = string.Empty;   

        private EmployeeName() { }

        public static EmployeeName EmployeeNameCreate(string lastName, string firstName, string? middleName = null)
        {
            return new EmployeeName()
            {
                FName = firstName,
                MName = middleName,
                LName = lastName
            };
        }

        public string GetFullName(bool useMiddleInitial = false)
        {
            if (MName is not null)
            {
                var middle = useMiddleInitial ? MName.First().ToString() : MName;

                return FName + " " + middle + " " + LName;
            }

            return FName + " " + LName;
        }
    }
}
