namespace main.Domain;

public class Order
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required double Amount { get; set; }
    public IEnumerable<Product>? Products { get; set; }
    public required DateTime OrderPlacedOnThisTime { get; set; }
    public DateTime OrderFulfilledOnThisTime { get; set; }


}