using Delegates;

public class Employee 
{
    public string Name { get; set; }
    public float Salary { get; set; }
    
    public List<TaxDelegate>? Taxes { get; set; }

    // public float CalculateAllTaxes()
    // {
    //    return Taxes?.Sum(tax => tax(Salary)) ?? 0f;
    // }
    
    public Employee(string name, float salary, List<TaxDelegate>? taxes=null)
    {
        Name = name;
        Salary = salary;
        Taxes = taxes;
    }
}