namespace ViajaNet.Test.DataInsert
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;


    public class ApiClient
    {
        private readonly Random random;
        private int count = 0;

        public ApiClient()
        {
            this.random = new Random();
        }

        public void Run()
        {
            while (true)
            {
                var tasks = new List<Task>();
                foreach(var index in Enumerable.Range(0, 10))
                {
                    tasks.Add(Task.Run(async () => await Post()));
                }

                Task.WaitAll(tasks.ToArray());

                Console.Write($"\r{count}");

                Thread.Sleep(10);
            }
        }

        private async Task Post()
        {
            try
            {
                var jsonObj = new JsonContent(new
                {
                    Url = this.GetUrl(),
                    Location = this.GetLocation(),
                    IP = "127.0.0.1",
                    Browser = this.GetBrowser()
                });
                var response = await new HttpClient().PostAsync("http://localhost:56014/api/web-access", jsonObj);
                if(response.IsSuccessStatusCode)
                {
                    Interlocked.Increment(ref this.count);
                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }
                            
            }
            catch (Exception ex)
            {

            }
        }

        private string GetUrl()
        {
            var items = new[] { "www.google.com.br", "www.viajanet.com.br", "www.uol.com.br", "www.facebook.com" };
            return items[random.Next(items.Length)];
        }

        private string GetLocation()
        {
            var items = new[] { "Brasil", "EUA", "UE" };
            return items[random.Next(items.Length)];
        }

        private string GetBrowser()
        {
            var items = new[] { "Chorme", "IE", "Opera", "Safari", "Firefox" };
            return items[random.Next(items.Length)];
        }
    }
}
