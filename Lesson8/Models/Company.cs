namespace Lesson8.Models;

class Company
{
    public string CompanyName { get; set; }
    public List<Employee> Employees { get; set; }
    public List<TaxDelegate> Taxes { get; set; }

    public event TaxDelegate OnSalaryPaid;

    public Company(string companyName)
    {
        CompanyName = companyName;
        Employees = new List<Employee>();
        Taxes = new List<TaxDelegate>();

        foreach (var tax in Taxes)
        {
            OnSalaryPaid += tax;
        }
    }
    
    public void AddEmployee(Employee employee)
    {
        Employees.Add(employee);
    }
    
    public void AddTax(TaxDelegate tax)
    {
        Taxes.Add(tax);
    }
    
    public float CalculateTax(Employee employee)
    {
        float totalTax = 0;
        foreach (var tax in Taxes)
        {
            totalTax += tax(employee.Salary);
        }
        return totalTax;
    }

    public float GiveSalary(Employee employee, float bonus = 0)
    {
        float totalSalary = employee.Salary + bonus;
        float tax = CalculateTax(employee);
        float salaryAfterTax = totalSalary - tax;

        OnSalaryPaid?.Invoke(salaryAfterTax);
        
        Console.WriteLine($"Salary paid to {employee.Name} {employee.Surname}\twith brutto salary: {totalSalary}, tax: {tax}, net salary: {salaryAfterTax}");

        return salaryAfterTax;
    }
}