using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VKR.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {

       /// <summary>
       /// 
       /// </summary>
       /// <param name="_script"></param>
       /// <returns></returns>
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public String Put([FromBody]string _script)
        {

            String clientId = "812d5d1c9205418aad312b2648590d08"; //Replace with your client ID
            String clientSecret = "7c1fc2d0678e08061ddfed6d7703c1eb36133eddca9ab9e7a13ea5bf25fe5665"; //Replace with your client Secret
            String script = _script;
            String language = "java";
            String versionIndex = "0";

            String url = "https://api.jdoodle.com/v1/execute";

            String input = "{\"clientId\": \"" + clientId + "\",\"clientSecret\":\"" + clientSecret +
                           "\",\"script\":\"" + script +
                           "\",\"language\":\"" + language + "\",\"versionIndex\":\"" + versionIndex + "\"} ";
            byte[] dataStream = Encoding.UTF8.GetBytes(input);
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = dataStream.Length;

            Stream outputStream = request.GetRequestStream();
            
            outputStream.Write(dataStream,0,dataStream.Length);
            outputStream.Close();
            WebResponse response = request.GetResponse ();
            outputStream = response.GetResponseStream();
            StreamReader reader = new StreamReader (outputStream);
            string responseFromServer = reader.ReadToEnd ();
            Console.WriteLine (responseFromServer);
            reader.Close ();
            outputStream.Close ();
            response.Close ();

            return responseFromServer;
        }
    }
}