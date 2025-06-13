// all orders of user named Elvin
// Во первых мы ищем Id, пользователя которого зовут Elvin
// Мы делаем LINQ запрос к Order в таком формате 

/*
Market m = new();
List<User> users = new();
string id = "Тут какой-то Guid"; // Assume we have Elvin's UserId


var userInfo = users.FirstOrDefault(u => u.UserId == id);
var allOrders = m.Orders.Where(o => o.UserId == id);
*/

class User
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    // public List<Order> Orders { get; set; }
}

class Market
{
    public List<Order> Orders { get; set; }
}

class Order
{
    public Guid OrderId { get; set; }
    // public Guid UserId { get; set; }
    public List<Product> Products { get; set; }
    public float TotalAmount { get; set; }
    public float TotalVAT { get; set; }
}

class UserOrders
{
    public Guid UserId { get; set; }
    public Guid OrderId { get; set; }
}

class Product
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public float VAT { get; set; }
}


    