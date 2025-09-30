using DigicHomework.Domain;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DigicHomework.UnitTests
{
    public class EmployeeCatalogTests
    {
        private EmployeeCatalog employeeCatalog = new();

        public EmployeeCatalogTests()
        {
            employeeCatalog.Employees =
            [
                CreateEmployee("esnowden", "Developer", "Edward", "Snowden", 1, "408-1234567", "edward.snowden@cia.com"),
                CreateEmployee("thanks", "Program Directory", "Tom", "Hanks", 2, "408-2222222", "tomhanks@hollywood.com"),
            ];
        }

        private Employee CreateEmployee(string userId, string jobTitleName, string firstName, string lastName, int employeeCode, string phoneNumber, string emailAddress)
        {
            return new Employee()
            {
                UserId = userId,
                JobTitleName = jobTitleName,
                FirstName = firstName,
                LastName = lastName,
                PreferredFullName = $"{firstName} {lastName}",
                EmployeeCode = $"E{employeeCode}",
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress
            };
        }

        [Fact]
        public void EmployeeCatalog_Import_Should_Create_Employees()
        {
            // Arrange
            var expected = new EmployeeCatalog();
            expected.Employees =
            [
                CreateEmployee("esnowden", "Developer", "Edward", "Snowden", 1, "408-1234567", "edward.snowden@cia.com"),
                CreateEmployee("thanks", "Program Directory", "Tom", "Hanks", 2, "408-2222222", "tomhanks@hollywood.com"),
            ];
            var actual = new EmployeeCatalog();
            var json = @"{
                ""Employees"" : [
                {
                ""userId"":""esnowden"",
                ""jobTitleName"":""Developer"",
                ""firstName"":""Edward"",
                ""lastName"":""Snowden"",
                ""preferredFullName"":""Edward Snowden"",
                ""employeeCode"":""E1"",
                ""phoneNumber"":""408-1234567"",
                ""emailAddress"":""edward.snowden@cia.com""
                },
                {
                ""userId"":""thanks"",
                ""jobTitleName"":""Program Directory"",
                ""firstName"":""Tom"",
                ""lastName"":""Hanks"",
                ""preferredFullName"":""Tom Hanks"",
                ""employeeCode"":""E2"",
                ""phoneNumber"":""408-2222222"",
                ""emailAddress"":""tomhanks@hollywood.com""
                }
                ]
            }";

            // Act
            actual.Import(json);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void EmployeeCatalog_Export_Should_Return_EmployeeCatalog_Json()
        {
            // Arrange
            var expected = JToken.Parse(@"{
                ""Employees"" : [
                {
                ""userId"":""esnowden"",
                ""jobTitleName"":""Developer"",
                ""firstName"":""Edward"",
                ""lastName"":""Snowden"",
                ""preferredFullName"":""Edward Snowden"",
                ""employeeCode"":""E1"",
                ""phoneNumber"":""408-1234567"",
                ""emailAddress"":""edward.snowden@cia.com""
                },
                {
                ""userId"":""thanks"",
                ""jobTitleName"":""Program Directory"",
                ""firstName"":""Tom"",
                ""lastName"":""Hanks"",
                ""preferredFullName"":""Tom Hanks"",
                ""employeeCode"":""E2"",
                ""phoneNumber"":""408-2222222"",
                ""emailAddress"":""tomhanks@hollywood.com""
                }
                ]
            }").ToString(Formatting.None);

            // Act
            var actual = JToken.Parse(employeeCatalog.Export("employeeCode", "asc")).ToString(Formatting.None);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("employeeCode", "asc", "Edward")]
        [InlineData("employeeCode", "desc", "No")]
        [InlineData("employeecode", "ascending", "Edward")]
        [InlineData("employeecode", "descending", "No")]
        [InlineData("jobTitleName", "asc", "No")]
        [InlineData("jobTitleName", "desc", "Tom")]
        public void EmployeeCatalog_Export_OrderBy_Should_Return_Correct_Order(string orderBy, string direction, string expected)
        {
            // Arrange
            employeeCatalog.Employees.Add(CreateEmployee("nobody", "Anywhere", "No", "Body", 3, "112-2222222", "nobody@email.com"));

            // Act
            var orderedEmployees = employeeCatalog.Export(orderBy, direction);
            var actual = new EmployeeCatalog();
            actual.Import(orderedEmployees);

            // Assert
            actual.Employees.First().FirstName.Should().BeEquivalentTo(expected);
        }
    }
}