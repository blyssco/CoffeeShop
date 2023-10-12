namespace CoffeeShop.Models;

internal class OrderProduct // joint table
{
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity {  get; set; }

}
