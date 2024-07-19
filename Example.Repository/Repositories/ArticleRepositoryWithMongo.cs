using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Repository.Repositories.Entities;

namespace Example.Repository.Repositories
{
    public class ArticleRepositoryWithMongo : IArticleRepository
    {
        public List<Article> Get()
        {
            throw new NotImplementedException();
        }

        public Article? Get(int id)
        {
            throw new NotImplementedException();
        }

        public Article? GetWithDependency(int id)
        {
            throw new NotImplementedException();
        }

        public Article Create(Article article)
        {
            throw new NotImplementedException();
        }
    }
}