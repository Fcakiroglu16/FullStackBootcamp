using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Asynchronous.App
{
    internal class SyncExample
    {
        public void Run()
        {
            Console.WriteLine("Synchronous Programming");
            Console.WriteLine("Start");
            Console.WriteLine("Middle");
            Console.WriteLine("End");
        }

        public async Task RunAsync()
        {
            var httpClient = new HttpClient();

            //var resultAsTask = httpClient.GetAsync("https://www.google.com").Result; // 1dk dk

            //var resultAsTask2 = await httpClient.GetAsync("https://www.google.com");


            httpClient.GetAsync("https://www.googleeeddf.com").ContinueWith(x =>
            {
                if (x.IsFaulted)
                {
                }

                Console.WriteLine($"result:{x.Result.IsSuccessStatusCode}");
            }); //10dk


            //db 1 dk


            // var result = await resultAsTask3;


            //var result2 = await httpClient.GetAsync("https://www.hepsiburada.com");


            //if (result.IsSuccessStatusCode)
            //{
            //    return true;
            //}

            //if (result2.IsSuccessStatusCode)
            //{
            //    return true;
            //}
        }


        public async Task Save()
        {
            //  log start 10sn

            // await db  50 sn


            //  log finish  20 sn
        }

        public async Task<bool> MakeToRequest()
        {
            var httpClient = new HttpClient();
            var result1 = await httpClient.GetAsync("https://www.hepsiburada.com"); // 10sn
            var result2 = await httpClient.GetAsync("https://www.google.com"); // 10sn
            var result3 = await httpClient.GetAsync("https://www.sahibinden.com"); // 10sn


            if (result1.IsSuccessStatusCode && result2.IsSuccessStatusCode && result3.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }


        public async Task<bool> MakeToRequest2()
        {
            var httpClient = new HttpClient();
            var result1 = httpClient.GetAsync("https://www.hepsiburada.com"); // 15sn
            var result2 = httpClient.GetAsync("https://www.google.com"); // 10sn
            var result3 = httpClient.GetAsync("https://www.sahibinden.com"); // 10sn


            var resultAll = await Task.WhenAll(result1, result2, result3);


            if (resultAll.All(x => x.IsSuccessStatusCode == true))
            {
                return true;
            }


            return false;
        }

        public async Task<bool> MakeToRequest3()
        {
            var httpClient = new HttpClient();
            var result1 = httpClient.GetAsync("https://www.hepsiburada.com"); // 15sn
            var result2 = httpClient.GetAsync("https://www.google.com"); // 10sn
            var result3 = httpClient.GetAsync("https://www.sahibinden.com"); // 10sn


            Task.WaitAll(result1, result2, result3);


            if (result1.Result.IsSuccessStatusCode && result2.Result.IsSuccessStatusCode &&
                result3.Result.IsSuccessStatusCode)
            {
                return true;
            }


            return false;
        }
    }
}