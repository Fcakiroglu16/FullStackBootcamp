namespace Example.Repository.Repositories.Entities
{
    public interface IAuditCreated
    {
        // TODO : Private set olarak işaretlenecek
        DateTime Created { get; set; }
    }
}