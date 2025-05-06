namespace main.Domain;


public class Product 
{

    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public required int Price { get; set; }
    public required string Category { get; set; }
    public IEnumerable<Order>? orders { get; set; }
}      