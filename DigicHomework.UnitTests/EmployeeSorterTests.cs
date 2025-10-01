using DigicHomework.Domain;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DigicHomework.UnitTests
{
    public class EmployeeSorterTests
    {
        private string input = @"{
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
                },
                {
                ""userId"":""nobody"",
                ""jobTitleName"":""Anywhere"",
                ""firstName"":""No"",
                ""lastName"":""Body"",
                ""preferredFullName"":""No Body"",
                ""employeeCode"":""E3"",
                ""phoneNumber"":""112-2222222"",
                ""emailAddress"":""nobody@email.com""
                }
                ]
            }";

        [Fact]
        public void EmployeeSorter_SortEmployees_EmployeeCode_Asc_Should_Return_Original_Order()
        {
            // Arrange
            var expected = JToken.Parse(input).ToString(Formatting.None);

            // Act
            var actual = JToken.Parse(EmployeeSorter.SortEmployees(input, "employeeCode", "asc")).ToString(Formatting.None);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void EmployeeSorter_SortEmployees_EmployeeCode_Desc_Should_Return_Reverse_Order()
        {
            // Arrange
            var expected = JToken.Parse(@"{
                ""Employees"" : [
                {
                ""userId"":""nobody"",
                ""jobTitleName"":""Anywhere"",
                ""firstName"":""No"",
                ""lastName"":""Body"",
                ""preferredFullName"":""No Body"",
                ""employeeCode"":""E3"",
                ""phoneNumber"":""112-2222222"",
                ""emailAddress"":""nobody@email.com""
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
                },
                {
                ""userId"":""esnowden"",
                ""jobTitleName"":""Developer"",
                ""firstName"":""Edward"",
                ""lastName"":""Snowden"",
                ""preferredFullName"":""Edward Snowden"",
                ""employeeCode"":""E1"",
                ""phoneNumber"":""408-1234567"",
                ""emailAddress"":""edward.snowden@cia.com""
                }
                ]
            }").ToString(Formatting.None);

            // Act
            var actual = JToken.Parse(EmployeeSorter.SortEmployees(input, "employeeCode", "desc")).ToString(Formatting.None);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("asc")]
        [InlineData("ascending")]
        [InlineData("kismacska")]
        [InlineData("")]
        public void EmployeeSorter_ParseDirection_Should_Return_Asc(string input)
        {
            // Arrange
            var expected = "asc";

            // Act
            var actual = EmployeeSorter.ParseDirection(input);

            // Assert
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("desc")]
        [InlineData("descending")]
        public void EmployeeSorter_ParseDirection_Should_Return_Desc(string input)
        {
            // Arrange
            var expected = "desc";

            // Act
            var actual = EmployeeSorter.ParseDirection(input);

            // Assert
            actual.Should().Be(expected);
        }
    }
}