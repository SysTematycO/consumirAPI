using Newtonsoft.Json;
using System.Net;

namespace API
{
    internal class Program
    {
        public static string Post(string url)
        {
            string result = "";
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.PreAuthenticate = true;
            request.ContentType = "application/json;charset=UTF-8";
            request.Timeout = 6000;

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                string json = "{\"GP\":[{\"Name\":\"USR\",\"Value\":\"taxi\"}," +
                                      "{\"Name\":\"PASS\",\"Value\":\"taxi\"}," +
                                      "{\"Name\":\"CLIENTEID\",\"Value\":\"51776\"}," +
                                      "{\"Name\":\"METHOD\",\"Value\":\"GETVEHICLETYPE\"}]}";

                writer.Write(json);
                writer.Flush();
                writer.Close();
            }
 
            WebResponse response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                result = reader.ReadToEnd().Trim();
            }

                return result;
        }

        static void Main(string[] args)
        {
            string url = "http://taxisws.widetech.co/API/rest/CabSimpleResponse";

            string result = Post(url);

            Console.WriteLine(result);
        }
    }

}
