namespace Example.App.Repositories
{
    public interface IAuditCreated
    {
        // TODO : Private set olarak işaretlenecek
        DateTime Created { get; set; }
    }
}