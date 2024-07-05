namespace Example.App.Repositories.Entities
{
    public class Article : BaseEntity<int>, IAuditCreated, IAuditUpdated
    {
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;

        public int CategoryId { get; set; }

        public Category Category { get; set; } = default;


        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public List<ArticleTag>? Tags { get; set; }
        public List<ArticleComment>? Comments { get; set; }


        // static factory method
        public static Article Create(string title, string content, List<ArticleTag> tags)
        {
            return new Article
            {
                Title = title,
                Content = content,
                Created = DateTime.Now,
                Tags = tags
            };
        }


        public static Article Create(string title, string content)
        {
            return new Article
            {
                Title = title,
                Content = content,
                Created = DateTime.Now
            };
        }
    }
}