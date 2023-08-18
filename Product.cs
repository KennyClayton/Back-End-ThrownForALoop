
//below is not a product, it is a TEMPLATE for creating any product
// This defines the class of Product in our system the same way bool, string, int are classes already. So we can use Product as a class of its own.
// What does this mean? It means Products is strictly, and only ever, the same three types (properties) listed in curly braces. The values change, but these three types in one sort of object is a "Product" class
using System.Diagnostics;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Sold { get; set; }
    public string Material { get; set; }
    public DateTime StockDate { get; set; }
    public int ManufactureYear { get; set; }
    public double Condition { get; set; }
}