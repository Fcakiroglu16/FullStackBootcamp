namespace Example.Repository.Repositories.Entities
{
    public class Tag : BaseEntity<int>
    {
        public string Name { get; set; } = default!;

        public List<ArticleTag> ArticleTags { get; set; }
    }
}