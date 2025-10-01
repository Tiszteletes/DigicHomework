Solution expect 3 command line arguments: employee_json, order_by_field, direction (asc/desc)

Employee json example:
{
  "Employees" : [
  {
  "userId":"esnowden",
  "jobTitleName":"Developer",
  "firstName":"Edward",
  "lastName":"Snowden",
  "preferredFullName":"Edward Snowden",
  "employeeCode":"E1",
  "phoneNumber":"408-1234567",
  "emailAddress":"edward.snowden@cia.com"
  },
  {
  "userId":"thanks",
  "jobTitleName":"Program Directory",
  "firstName":"Tom",
  "lastName":"Hanks",
  "preferredFullName":"Tom Hanks",
  "employeeCode":"E2",
  "phoneNumber":"408-2222222",
  "emailAddress":"tomhanks@hollywood.com"
  }
  ]
}

Output: ordered json string

Example call:
.\DigicHomework.exe "{\"Employees\": [{\"emailAddress\": \"edward.snowden@cia.com\", \"employeeCode\": \"E1\", \"firstName\": \"Edward\", \"jobTitleName\": \"Developer\", \"lastName\": \"Snowden\", \"phoneNumber\": \"408-1234567\", \"preferredFullName\": \"Edward Snowden\", \"userId\": \"esnowden\"}, {\"emailAddress\": \"tomhanks@hollywood.com\", \"employeeCode\": \"E2\", \"firstName\": \"Tom\", \"jobTitleName\": \"Program Directory\", \"lastName\": \"Hanks\", \"phoneNumber\": \"408-2222222\", \"preferredFullName\": \"Tom Hanks\", \"userId\": \"thanks\"}]}" employeeCode desc
