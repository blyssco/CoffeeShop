using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Models;

internal class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }
}