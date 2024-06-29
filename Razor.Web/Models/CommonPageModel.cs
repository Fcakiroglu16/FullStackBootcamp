namespace Razor.Web.Models
{
    public class CommonPageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public void SetModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}