namespace Example.App.Repositories.Entities
{
    public class ArticleTag : BaseEntity<int>
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }

        public static ArticleTag Create(int tagId)
        {
            return new ArticleTag { TagId = tagId };
        }
    }
}