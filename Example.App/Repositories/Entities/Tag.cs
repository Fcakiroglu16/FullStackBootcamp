namespace Example.App.Repositories.Entities
{
    public class Tag : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
    }
}