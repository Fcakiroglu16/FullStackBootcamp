namespace OOPConcept.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var product = Product.Create("Kalem 1", 300);


            var product2 = Product.Create("Kalem 2", 300);
            ;
            var product3 = Product.Create("Kalem 3", 300);

            var productService = new ProductService(new ProductRepository());

            productService.Save(product);
            productService.Save(product2);
            productService.Save(product3);

            foreach (var item in productService.GetProducts())
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}