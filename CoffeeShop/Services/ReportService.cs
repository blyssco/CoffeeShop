using CoffeeShop.Controllers;
using CoffeeShop.Interfaces;
using CoffeeShop.Models.DTOs;
using System.Globalization;

namespace CoffeeShop.Services;

internal class ReportService
{
    internal static void CreateReport()
    {
        var orders = OrderController.GetOrders();

        var report = orders.GroupBy(x => new
        {
            x.CreatedDate.Month,
            x.CreatedDate.Year,
        })
            .Select(grp => new MontlyReportDTO
            {
                Month = $"{CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(grp.Key.Month)}/{grp.Key.Year}",
                TotalPrice = grp.Sum(x => x.TotalPrice),
                TotalQuantity = grp.Sum(x => x.OrderProducts.Sum(x => x.Quantity))
            })
            .ToList();

        UserInterface.ShowReportByMonth(report);
    }
}