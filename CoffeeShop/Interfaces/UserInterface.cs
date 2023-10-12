using CoffeeShop.Models;
using CoffeeShop.Models.DTOs;
using Spectre.Console;

namespace CoffeeShop.Interfaces;

static internal class UserInterface
{
    internal static void ShowProduct(Product product)
    {
        var panel = new Panel($@"Id: {product.ProductId} Name: {product.Name} Category:{product.Category.Name}");
        panel.Header = new PanelHeader("Product Info");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        Console.WriteLine("Press any key to continue");

        Console.ReadLine();

        Console.Clear();
    }
    static internal void ShowProductTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");
        table.AddColumn("Category");

        foreach (var product in products)
        {
            table.AddRow(
                product.ProductId.ToString(),
                product.Name,
                product.Price.ToString(),
                product.Category.Name
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");

        Console.ReadLine();

        Console.Clear();
    }
    static internal void ShowCategoryTable(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (Category category in categories)
        {
            table.AddRow(
                category.CategoryId.ToString(),
                category.Name
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");

        Console.ReadLine();

        Console.Clear();
    }
    internal static void ShowCategory(Category category)
    {
        var panel = new Panel($@"Id: {category.CategoryId} Name: {category.Name} Product Count:{category.Products.Count}");
        panel.Header = new PanelHeader($"{category.Name}");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);

        ShowProductTable(category.Products);

        Console.WriteLine("Press any key to continue");

        Console.ReadLine();

        Console.Clear();
    }
    internal static void showOrderTable(List<Order> orders)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Date");
        table.AddColumn("Count");
        table.AddColumn("Total Price");


        foreach (Order order in orders)
        {
            table.AddRow(
                order.OrderId.ToString(),
                order.CreatedDate.ToString(),
                order.OrderProducts.Sum(x => x.Quantity).ToString(),
                order.TotalPrice.ToString()
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press any key to continue");

        Console.ReadLine();

        Console.Clear();
    }
    internal static void ShowOrder(Order order)
    {
        var panel = new Panel($@"Id: {order.OrderId}
Date: {order.CreatedDate}
Product Count: {order.OrderProducts.Sum(x => x.Quantity)}");
        panel.Header = new PanelHeader($"Order #{order.OrderId}");
        panel.Padding = new Padding(2, 2, 2, 2);

        AnsiConsole.Write(panel);
    }
    internal static void ShowProductForOrderTable(List<ProductForOrderViewDTO> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Category");
        table.AddColumn("Price");
        table.AddColumn("Quantity");
        table.AddColumn("Total Price");

        foreach (var product in products)
        {
            table.AddRow(
                product.Id.ToString(),
                product.Name,
                product.CategoryName,
                product.Price.ToString(),
                product.Quantity.ToString(),
                product.TotalPrice.ToString()
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Press Any Key to Return to Menu");
        Console.ReadLine();
        Console.Clear();
    }
    internal static void ShowReportByMonth(List<MontlyReportDTO> report)
    {
        var table = new Table();
        table.AddColumn("Month");
        table.AddColumn("Total Quantity");
        table.AddColumn("Total Sales");

        foreach (var item in report)
        {
            table.AddRow(
                item.Month,
                item.TotalQuantity.ToString(),
                item.TotalPrice.ToString()
                );
        }

        AnsiConsole.Write(table);
    }
}
