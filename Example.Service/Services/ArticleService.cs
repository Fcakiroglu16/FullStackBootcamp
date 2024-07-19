using Example.App.Services;
using Example.Repository.Repositories;
using Example.Repository.Repositories.Entities;
using Example.Service.Services.ViewModels;

namespace Example.Service.Services
{
    public class ArticleService(IArticleRepository articleRepository, ITagRepository tagRepository) : IArticleService
    {
        // created method

        public async Task<ServiceResult<NoContent>> Create(ArticleCreateViewModel model)
        {
            if (model.TagIds == null)
            {
                articleRepository.Create(Article.Create(model.Title, model.Content, model.CategoryId));


                return ServiceResult<NoContent>.Success();
            }

            var tags = tagRepository.Get().Where(tag => model.TagIds.Contains(tag.Id)).ToList();
            var articleTagList = tags.Select(x => ArticleTag.Create(x.Id)).ToList();
            articleRepository.Create(Article.Create(model.Title, model.Content, articleTagList, model.CategoryId));
            return ServiceResult<NoContent>.Success();
        }

        public ServiceResult<ArticleViewModel> Get(int id)
        {
            var article = articleRepository.GetWithDependency(id);
            if (article == null)
            {
                return ServiceResult<ArticleViewModel>.Failure("Article not found");
            }

            var articleViewModel = new ArticleViewModel(article.Id, article.Title, article.Content, null, null);


            return ServiceResult<ArticleViewModel>.Success(articleViewModel);
        }
    }
}