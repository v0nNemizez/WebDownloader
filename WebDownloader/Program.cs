using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace WebDownloader
{
     class Program
    {
         static void Main(string[] args)
        {
            string path = @"c:\temp\MyTest.html";

            WebRequest request = WebRequest.Create("http://www.vg.no");
            request.Credentials = CredentialCache.DefaultCredentials;
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            Console.WriteLine(response.StatusDescription);
           
            Stream dataStream = response.GetResponseStream();
            
            StreamReader reader = new StreamReader(dataStream);
            
            string responseFromServer = reader.ReadToEnd();


            using (FileStream fs = File.Create(path))
            {
                File.WriteAllText(path, responseFromServer);
            }

            Console.WriteLine(responseFromServer);
            
            reader.Close();
            dataStream.Close();
            response.Close();
          



            Console.ReadKey();

            
        }



    }
      
}
