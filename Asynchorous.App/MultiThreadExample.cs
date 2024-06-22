using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous.App
{
    internal class MultiThreadExample
    {
        public void ParallelExample()
        {
            var names = new List<string>()
            {
                "ahmet", "hasan", "ömer", "furkan", "ayşe", "ali", "ahmet", "hasan", "ömer", "furkan", "ayşe", "ali",
                "ahmet", "hasan", "ömer", "furkan", "ayşe", "ali", "ahmet", "hasan", "ömer", "furkan", "ayşe", "ali"
            };

            Parallel.ForEach(names, x => { Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} {x}"); });


            //string[] names2 = { "ahmet", "hasan", "ömer", "furkan" };


            //Parallel.For(0, names2.Length, (x) =>
            //{
            //    var name = names2[x];
            //    Console.WriteLine(x);
            //});


            //foreach (var name in names)
            //{
            //    Task.Run(() => { });


            //    // TASK PARALLEL LIBRARY
            //}
        }

        public async Task TaskExample(string url)
        {
            // 100x100 //thumbnail
            // 100x200; //thumbnail
            //200x400; //thumbnail


            Task.Run(async () =>
            {
                await Task.Delay(3000);
                File.WriteAllText("example1.txt", "100x100px");
                //100x100
            }).ContinueWith(x =>
            {
                Console.WriteLine($"100x100px operasyon tamamlandı. durum :{x.IsFaulted}");

                if (x.IsFaulted)
                {
                    //loglama
                }
            });
            Task.Run(async () =>
            {
                await Task.Delay(5000);
                File.WriteAllText("example2.txt", "100x200px");
                //100x200
            }).ContinueWith(x => { Console.WriteLine($"100x200px operasyon tamamlandı. durum :{x.IsFaulted}"); });
            Task.Run(async () =>
            {
                await Task.Delay(8000);
                File.WriteAllText("example3.txt", "200x400px");
                // 200x400
            }).ContinueWith(x => { Console.WriteLine($"200x400px operasyon tamamlandı. durum :{x.IsFaulted}"); });
        }
    }
}