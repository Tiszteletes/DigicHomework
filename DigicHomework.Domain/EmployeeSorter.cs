namespace DigicHomework.Domain
{
    public static class EmployeeSorter
    {
        public static string SortEmployees(string json, string orderBy, string direction)
        {
            var employeeCatalog = System.Text.Json.JsonSerializer.Deserialize<EmployeeCatalog>(json);
            if (employeeCatalog == null || employeeCatalog.Employees == null)
            {
                throw new ArgumentException("Invalid JSON input or no employees found.");
            }
            direction = ParseDirection(direction);
            return employeeCatalog.Export(orderBy, direction);
        }

        public static string ParseDirection(string direction)
        {
            if (direction.Contains("desc", StringComparison.InvariantCultureIgnoreCase))
            {
                return "desc";
            }
            else
            {
                return "asc";
            }
        }
    }
}
