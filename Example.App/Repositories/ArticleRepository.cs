using Example.App.Repositories.Entities;

namespace Example.App.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private static List<Article> articleList = new();


        static ArticleRepository()
        {
            articleList.Add(new Article
            {
                Id = 1,
                Title = "Article 1",
                Content = "Content 1",
                Tags = new List<ArticleTag>
                {
                    new ArticleTag
                    {
                        Id = 1,
                        TagId = 1,
                        ArticleId = 1
                    }
                },
            });
            articleList.Add(new Article
            {
                Id = 2,
                Title = "Article 2",
                Content = "Content 2",
                Tags = new List<ArticleTag>
                {
                    new ArticleTag
                    {
                        Id = 2,
                        TagId = 2,
                        ArticleId = 1
                    }
                }
            });
        }


        public List<Article> Get()
        {
            return articleList;
        }

        public Article? Get(int id)
        {
            return articleList.SingleOrDefault(x => x.Id == id);
        }

        public Article? GetWithDependency(int id)
        {
            return articleList.SingleOrDefault(x => x.Id == id);
        }

        public Article Create(Article article)
        {
            article.Id = articleList.Max(x => x.Id) + 1;
            articleList.Add(article);
            return article;
        }
    }
}