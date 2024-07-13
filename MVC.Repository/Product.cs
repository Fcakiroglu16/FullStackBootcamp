namespace MVC.Repository
{
    public class Product : BaseEntity<int>, IAuditByDate
    {
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public int Stock { get; set; }


        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}