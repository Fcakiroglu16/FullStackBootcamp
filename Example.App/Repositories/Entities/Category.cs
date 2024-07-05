namespace Example.App.Repositories
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
    }
}