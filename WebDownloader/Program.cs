using System;
using System.IO;
using System.Net;
using System.Text;


namespace WebDownloader
{
     class Program
    {
         static void Main(string[] args)
        {
            string path = @"c:\temp\MyTest.html";
            string url;

            Console.WriteLine("Enter url of website: http://blabla.com");
            url = Console.ReadLine();


            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
         
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            Console.WriteLine(response.StatusDescription);
           
            Stream dataStream = response.GetResponseStream();
            
            StreamReader reader = new StreamReader(dataStream);
            
            string responseFromServer = reader.ReadToEnd();


            using (FileStream fs = File.Create(path))
            {
             
                string dataasstring = responseFromServer; 
                byte[] info = new UTF8Encoding(true).GetBytes(dataasstring);
                fs.Write(info, 0, info.Length);

     
                byte[] data = new byte[] { 0x0 };
                fs.Write(data, 0, data.Length);
                fs.Close();
            }

            Console.WriteLine(responseFromServer);
            Console.ReadKey();


            reader.Close();
            dataStream.Close();
            response.Close();
            
          



            

            
        }



    }
      
}
