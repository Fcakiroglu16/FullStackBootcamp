using Example.Repository.Repositories.Entities;

namespace Example.Repository.Repositories
{
    public class TagRepository(AppDbContext context) : ITagRepository
    {
        public List<Tag> Get() => context.Tags.ToList();
    }
}