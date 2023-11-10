using Warehouse.Client;

var clientWrapper = new WarehouseClientWrapper("http://localhost:5097");

Console.WriteLine("Adding product 1...");
var productID = await clientWrapper.AddProductAsync("1", "Jabón", "34");
if (!string.IsNullOrEmpty(productID))
{
    Console.WriteLine($"Product 1 added with Id: {productID}");
}
else
{
    Console.WriteLine("An error occurred or the product was not added.");
}

Console.WriteLine("Adding product 2...");
var productID2 = await clientWrapper.AddProductAsync("2", "Jamón", "15");
if (!string.IsNullOrEmpty(productID2))
{
    Console.WriteLine($"Product 2 added with Id: {productID}");
}
else
{
    Console.WriteLine("An error occurred or the product was not added.");
}

Console.WriteLine("Adding product 3...");
var productID3 = await clientWrapper.AddProductAsync("3", "Teclado", "5");
if (!string.IsNullOrEmpty(productID3))
{
    Console.WriteLine($"Product 3 added with Id: {productID}");
}
else
{
    Console.WriteLine("An error occurred or the product was not added.");
}

Console.WriteLine("Fetching product by Id with ID: 2");
var productById = await clientWrapper.GetProductByIdAsync("2");
if (productById != null)
{
    Console.WriteLine($"Product found: Id {productById.Id}, Name: {productById.Name}, Quantity: {productById.Quantity}");
}
else
{
    Console.WriteLine("An error occurred or the product was not added.");
}

Console.WriteLine("Fetching product by Name with ID: 2");
var productByName = await clientWrapper.GetProductByNameAsync("Jamones");
if (productByName != null)
{
    Console.WriteLine($"Product found: Id {productByName.Id}, Name: {productByName.Name}, Quantity: {productByName.Quantity}");
}
else
{
    Console.WriteLine("An error occurred or the product was not added.");
}

Console.WriteLine("Hasta la vista beibi");
Console.ReadKey();