using Example.Repository.Repositories.Entities;

namespace Example.Repository.Repositories;

public interface ITagRepository
{
    List<Tag> Get();
}