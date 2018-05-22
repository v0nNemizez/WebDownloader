using System;
using System.Net.Http;

namespace WebDownloader
{
     class Program
    {
         static async void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Starting HTTP Client");
            HttpClient client = new HttpClient(); 

            try
            {
                HttpResponseMessage response = await client.GetAsync("http://google.com");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                Console.WriteLine("Press a key to Exit");
                Console.ReadKey();

            }

            client.Dispose();
        }



    }
      
}
