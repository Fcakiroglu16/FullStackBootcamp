namespace MVC.Repository
{
    public class BaseEntity<T>
    {
        public T Id { get; set; } = default!;
    }
}