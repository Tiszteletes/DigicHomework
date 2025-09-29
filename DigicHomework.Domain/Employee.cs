using System.Text.Json.Serialization;

namespace DigicHomework.Domain
{
    public class Employee
    {
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("jobTitleName")]
        public string JobTitleName { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("preferredFullName")]
        public string PreferredFullName { get; set; }

        [JsonPropertyName("employeeCode")]
        public string EmployeeCode { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("emailAddress")]
        public string EmailAddress { get; set; }
    }
}
