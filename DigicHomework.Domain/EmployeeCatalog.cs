using System.Linq.Dynamic.Core;

namespace DigicHomework.Domain
{
    public class EmployeeCatalog
    {
        public List<Employee> Employees { get; set; }

        public void Import(string json)
        {
            var employeeCatalog = System.Text.Json.JsonSerializer.Deserialize<EmployeeCatalog>(json);
            
            if (employeeCatalog?.Employees != null)
            {
                Employees = employeeCatalog.Employees;
            }
        }

        public string Export(string orderBy, string direction)
        {
            // Nice to have: parameter validation
            direction = EmployeeSorter.ParseDirection(direction);
            Employees = [.. Employees.AsQueryable().OrderBy($"{orderBy} {direction}")];
            var optins = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true
            };
            return System.Text.Json.JsonSerializer.Serialize(this, optins);
        }
    }
}
