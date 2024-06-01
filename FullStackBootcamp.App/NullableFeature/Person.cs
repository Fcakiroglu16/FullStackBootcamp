namespace FullStackBootcamp.App.NullableFeature
{
    internal class Person
    {
        public int? Age { get; set; }

        public string? Name { get; set; }

        public string Surname { get; set; } = default!;
    }

    public class PersonService
    {
        void Method1()
        {
            var person = new Person() { Age = 20, Name = null, Surname = "yıldız" };

            if (person.Age.HasValue)
            {
                int age = person.Age.Value;
            }
        }
    }
}