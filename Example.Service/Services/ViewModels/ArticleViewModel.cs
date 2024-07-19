namespace Example.Service.Services.ViewModels
{
    public record ArticleViewModel(
        int Id,
        string Title,
        string Content,
        List<TagViewModel>? Tags,
        List<ArticleCommentViewModel>? Comments);
}