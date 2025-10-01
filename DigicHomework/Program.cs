using DigicHomework.Domain;

try
{
    if (args.Length != 3)
    {
        throw new ArgumentException("Invalid number of parameters. Please provide exactly three parameters: <inputJson> <orderBy> <direction>");
    }

    var result = EmployeeSorter.SortEmployees(args[0], args[1], args[2]);
    Console.WriteLine($"Result: {result}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error occured during the employee sorting: {ex.Message}");
}
