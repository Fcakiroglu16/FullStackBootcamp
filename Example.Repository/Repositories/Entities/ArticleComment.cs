namespace Example.Repository.Repositories.Entities
{
    public class ArticleComment : BaseEntity<int>, IAuditCreated
    {
        public string Name { get; set; } = default!;
        public string Content { get; set; } = default!;

        public int ArticleId { get; set; }

        public DateTime Created { get; set; }

        public static ArticleComment Create(string name, string content, int articleId)
        {
            return new ArticleComment
            {
                Name = name,
                Content = content,
                ArticleId = articleId,
                Created = DateTime.Now
            };
        }
    }
}