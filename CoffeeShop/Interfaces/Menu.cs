using CoffeeShop.Services;
using Spectre.Console;
using static CoffeeShop.Models.Enums;

namespace CoffeeShop.Interfaces
{
    internal class Menu
    {
        static internal void MainMenu()
        {
            var IsAppRunning = true;

            while (IsAppRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<MainMenuOptions>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        MainMenuOptions.ManageCategories,
                        MainMenuOptions.ManageProducts,
                        MainMenuOptions.ManageOrders,
                        MainMenuOptions.CreateReport,
                        MainMenuOptions.Quit
                ));

                switch (option)
                {
                    case MainMenuOptions.ManageCategories:
                        CategoriesMenu();
                        break;
                    case MainMenuOptions.ManageProducts:
                        ProductsMenu();
                        break;
                    case MainMenuOptions.ManageOrders:
                        OrdersMenu();
                        break;
                    case MainMenuOptions.CreateReport:
                        ReportService.CreateReport();
                        Console.ReadLine();
                        break;
                    case MainMenuOptions.Quit:
                        Console.WriteLine("Goodbye");
                        IsAppRunning = false;
                        break;
                }
            }
        }
        private static void CategoriesMenu()
        {
            var isCategoriesMenuRunning = true;

            while (isCategoriesMenuRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<CategoryMenu>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        CategoryMenu.AddCategory,
                        CategoryMenu.DeleteCategory,
                        CategoryMenu.UpdateCategory,
                        CategoryMenu.ViewAllCategories,
                        CategoryMenu.ViewCategory,
                        CategoryMenu.GoBack
                ));

                switch (option)
                {
                    case CategoryMenu.AddCategory:
                        CategoryService.InsertCategory();
                        break;
                    case CategoryMenu.DeleteCategory:
                        CategoryService.DeleteCategory();
                        break;
                    case CategoryMenu.UpdateCategory:
                        CategoryService.UpdateCategory();
                        break;
                    case CategoryMenu.ViewAllCategories:
                        CategoryService.GetCategories();
                        break;
                    case CategoryMenu.ViewCategory:
                        CategoryService.GetCategory();
                        break;
                    case CategoryMenu.GoBack:
                        isCategoriesMenuRunning = false;
                        break;
                }
            }
        }
        static internal void ProductsMenu()
        {
            var isProductMenuRunning = true;

            while (isProductMenuRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<ProductMenu>()
                    .Title("What would you like to do?")
                    .AddChoices(
                        ProductMenu.AddProduct,
                        ProductMenu.DeleteProduct,
                        ProductMenu.UpdateProduct,
                        ProductMenu.ViewAllProducts,
                        ProductMenu.ViewProduct,
                        ProductMenu.GoBack
                ));

                switch (option)
                {
                    case ProductMenu.AddProduct:
                        ProductService.InsertProduct();
                        break;
                    case ProductMenu.DeleteProduct:
                        ProductService.DeleteProduct();
                        break;
                    case ProductMenu.UpdateProduct:
                        ProductService.UpdateProduct();
                        break;
                    case ProductMenu.ViewAllProducts:
                        ProductService.GetProducts();
                        break;
                    case ProductMenu.ViewProduct:
                        ProductService.GetProduct();
                        break;
                    case ProductMenu.GoBack:
                        isProductMenuRunning = false;
                        break;
                }
            }
        }
        private static void OrdersMenu()
        {
            var isOrderMenuRunning = true;

            while (isOrderMenuRunning)
            {
                Console.Clear();
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<OrderMenu>()
                    .Title("Orders menu")
                    .AddChoices(
                        OrderMenu.AddOrder,
                        OrderMenu.GetOrders,
                        OrderMenu.GetOrder,
                        OrderMenu.GoBack
                ));

                switch (option)
                {
                    case OrderMenu.AddOrder:
                        OrderService.InsertOrder();
                        break;
                    case OrderMenu.GetOrders:
                        OrderService.GetOrders();
                        break;
                    case OrderMenu.GetOrder:
                        OrderService.GetOrder();
                        break;
                    case OrderMenu.GoBack:
                        isOrderMenuRunning = false;
                        break;
                }
            }
        }
    }
}
