namespace Example.Repository.Repositories.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
    }
}