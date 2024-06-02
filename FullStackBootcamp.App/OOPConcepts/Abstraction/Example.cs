using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackBootcamp.App.OOPConcepts.Abstraction
{
    public interface IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public abstract class BasePerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetFullName => $"{FirstName} {LastName}";


        public string GetFullName3
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public string GetFullName4
        {
            get => $"{FirstName} {LastName}";
        }

        public string GetFullName2()
        {
            return $"{FirstName} {LastName}";
        }

        public abstract string Save();
    }

    public class Manager : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Teacher : BasePerson
    {
        public override string Save()
        {
            throw new NotImplementedException();
        }
    }


    public class Student : BasePerson
    {
        public override string Save()
        {
            throw new NotImplementedException();
        }
    }
}