namespace OOPConcept.Example;

internal class BaseProduct
{
    public int Id { get; set; }
}

internal class Product : BaseProduct
{
    public string Name { get; init; } = default!;
    public decimal Price { get; init; }


    private Product()
    {
    }


    // static factory method
    public static Product Create(string Name, decimal Price)
    {
        ArgumentException.ThrowIfNullOrEmpty(Name, nameof(Product.Name));


        CheckPrice(Price);

        return new Product() { Name = Name, Price = Price };
    }


    private static void CheckPrice(decimal Price)
    {
        if (Price > 3000)
        {
            throw new Exception("");
        }
    }
}