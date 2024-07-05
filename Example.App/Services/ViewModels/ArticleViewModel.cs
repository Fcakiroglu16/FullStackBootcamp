using Example.App.Repositories;

namespace Example.App.Services.ViewModels
{
    public record ArticleViewModel(
        int Id,
        string Title,
        string Content,
        List<TagViewModel>? Tags,
        List<ArticleCommentViewModel>? Comments);
}