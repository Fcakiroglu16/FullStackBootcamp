namespace MVC.Repository.Data
{
    public interface IAuditByDate
    {
        DateTime Created { get; set; }
        DateTime? Updated { get; set; }
    }

    public interface IAuditByUser
    {
        Guid? CreatedByUser { get; set; }

        Guid? UpdatedByUser { get; set; }
    }
}