using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net;



namespace WebApp1
{
    public static class RestApi
    {
        public static JToken Execute(string url, string methodName, JToken source)
        {
            //WebApi呼び出し
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = methodName;
            req.ContentType = "application/json";

            var inputJson = JsonConvert.SerializeObject(source);

            byte[] byteArray = Encoding.UTF8.GetBytes(inputJson);
            req.ContentLength = byteArray.Length;
            using (Stream dataStream = req.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();

            var responseJson = "";
            using (var sr = new StreamReader(res.GetResponseStream()))
            {
                responseJson = sr.ReadToEnd();
            }
            var result = JsonConvert.DeserializeObject<JToken>(responseJson);
            return result;
        }
    }
}
