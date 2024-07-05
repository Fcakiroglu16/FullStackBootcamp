using Example.App.Repositories.Entities;

namespace Example.App.Repositories;

public interface ITagRepository
{
    List<Tag> Get();
}