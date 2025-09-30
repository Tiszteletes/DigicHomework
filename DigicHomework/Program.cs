using DigicHomework.Domain;

var employeeCatalog = new EmployeeCatalog();
try
{
    if (args.Length != 3)
    {
        throw new ArgumentException("Invalid number of parameters. Please provide exactly three parameters: <inputJson> <orderBy> <direction>");
    }

    employeeCatalog.Import(args[0]);
    var result = employeeCatalog.Export(args[1], args[2]);
    Console.WriteLine($"Result: {result}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error occured during the employee ordering process: {ex.Message}");
    return;
}
