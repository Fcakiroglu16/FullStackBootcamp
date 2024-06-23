namespace MVC.Web.Models
{
    public class IndexPageViewModel
    {
        public int Number { get; set; }
        public List<int> Numbers { get; set; } = default!;
        public string Name { get; set; } = default!;
        public List<string> Names { get; set; } = default!;
    }
}