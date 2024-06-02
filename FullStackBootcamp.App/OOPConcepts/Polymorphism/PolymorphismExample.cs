using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FullStackBootcamp.App.OOPConcepts.Polymorphism
{
    internal abstract class BaseProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual void Write()
        {
        }


        public virtual void Save()
        {
            Console.WriteLine($"{Id} {Name} {Price}");
        }
    }


    internal class Phone : BaseProduct
    {
    }

    internal class Monitor : BaseProduct
    {
        public int Type { get; set; }


        public override void Save()
        {
            if (Type == 1)
            {
                var productAsJson = JsonSerializer.Serialize(this);

                Console.WriteLine(productAsJson);
            }
            else
            {
                base.Save();
            }
        }
    }

    internal class SuperMonitor : Monitor
    {
        public override void Write()
        {
            base.Write();
        }
    }
}