using Example.App.Repositories.Entities;

namespace Example.App.Repositories;

public interface IArticleRepository
{
    List<Article> Get();

    Article? Get(int id);

    Article? GetWithDependency(int id);

    Article Create(Article article);
}