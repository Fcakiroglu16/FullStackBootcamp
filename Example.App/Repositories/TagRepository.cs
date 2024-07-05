using Example.App.Repositories.Entities;

namespace Example.App.Repositories
{
    public class TagRepository : ITagRepository
    {
        private static readonly List<Tag> tags = new();

        static TagRepository()
        {
            tags.Add(new Tag { Id = 1, Name = "C#" });
            tags.Add(new Tag { Id = 2, Name = "Java" });
            tags.Add(new Tag { Id = 3, Name = "Python" });
        }

        public List<Tag> Get() => tags;
    }
}