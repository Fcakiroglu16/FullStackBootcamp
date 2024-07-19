using Example.Repository.Repositories.Entities;

namespace Example.Repository.Repositories;

public interface IArticleRepository
{
    List<Article> Get();

    Article? Get(int id);

    Article? GetWithDependency(int id);

    Article Create(Article article);
}