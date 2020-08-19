using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestSendSMSByAPI
{
    class Program
    {
        static void Main(string[] args)
        {

            SendSMS("66xxxxxxxxx", "Call API with C#", tokenId: "My token id");


            Console.ReadKey();
        }

        public static void SendSMS(string phoneNumber, string message, string tokenId = "")
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(@"<YOUR-BULK-SMS-API>");
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";

            var hasToken = "true";// string.IsNullOrEmpty(tokenId.Trim()) ? "false" : "true";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string loginjson = @"{
                                        'TokenID':'"+ tokenId + @"',
                                        'SkipToken':" + hasToken + @",
                                        'PhoneNumber':'" + phoneNumber + @"',
                                        'MessageDetail':{
                                                        'Message':'" + message + @"',
                                            'LinkMessage':[
                                                {
                                                    'Name':'linkToGoogle',
                                                    'Link':'http://www.google.com',
                                                    'Display':'Google'
                                                },
                                                {
                                                    'Name':'linkToFacebook',
                                                    'Link':'http://www.Facebook.com',
                                                    'Display':'Facebook'
                                                }
                                            ]
                                        },
                                        'RequestBy':'somebody'
                                    }";

                streamWriter.Write(loginjson);
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JsonSerializer serializer = new JsonSerializer();
                    JToken token = JToken.Parse(result);
                    JObject json = JObject.Parse((string)token);
                    BulkSMSResponse bulkSMSResponse = json.ToObject<BulkSMSResponse>();

                    Console.WriteLine(JsonConvert.SerializeObject(bulkSMSResponse));


                }
            }
        }
    }
}
