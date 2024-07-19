namespace Example.Service.Services.ViewModels
{
    public record ArticleCreateViewModel(string Title, string Content, List<int>? TagIds, int CategoryId);
}