namespace Shared2
{
    public class X
    {
        public X()
        {
            var manager = new Manager();
            // manager.Name = "xx";
        }
    }

    public class BasePerson
    {
        protected private string? Name { get; set; }

        public BasePerson()
        {
        }
    }

    public class Manager : BasePerson
    {
        public Manager()
        {
            var manager = new Manager();
            manager.Name = "aa";
        }
    }
}