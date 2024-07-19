// See https://aka.ms/new-console-template for more information

using CleanCoding.App;

Console.WriteLine("Hello, World!");

var product = new Product() { Id = 1, Name = "kalem 1", Price = 100 };

var productService = new ProductService();
Console.WriteLine(product.Price);

productService.CalculateTax(product); // side effect

Console.WriteLine(product.Price);