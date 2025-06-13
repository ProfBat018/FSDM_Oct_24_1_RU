using Lesson8.Models;

Company company = new("Tech Innovations Inc.");

company.AddEmployee(new Employee
{
    Name = "Alice",
    Surname = "Johnson",
    Salary = 50000
});

company.AddEmployee(new Employee
{
    Name = "Bob",
    Surname = "Smith",
    Salary = 40000
});

company.AddEmployee(new Employee
{
    Name = "Charlie",
    Surname = "Brown",
    Salary = 80000
});

company.AddTax(salary => salary * 0.2f); 
company.AddTax(salary => 84f); 
company.AddTax(salary => 20f);

company.GiveSalary(company.Employees[0]);
