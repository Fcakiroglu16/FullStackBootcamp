using Example.Repository.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Repository.Repositories
{
    public class ArticleRepository(AppDbContext context) : IArticleRepository
    {
        public List<Article> Get()
        {
            return context.Articles.ToList();
        }

        public Article? Get(int id)
        {
            return context.Articles.SingleOrDefault(x => x.Id == id);
        }

        public Article? GetWithDependency(int id)
        {
            return context.Articles.Include(x => x.Comments).Include(x => x.Tags).SingleOrDefault(x => x.Id == id);
        }

        public Article Create(Article article)
        {
            context.Articles.Add(article);
            return article;
        }
    }
}