using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace SendDiscordWebhook
{
    class SendWeebhook
    {
        private readonly WebClient dWebClient = new WebClient();
        private static NameValueCollection discord = new NameValueCollection();
        public string WebHook = "https://discord.com/api/webhooks/1034920586822033479/2brRLAa752rKuzHMbMWOiqhVhjK3xCvEEt3wGlN9OzJL-B7CJVwkIORVh5lLYBAFZ3PE";

        public void SendMessage(string msgSend, string title)
        {
            WebRequest wr = (HttpWebRequest)WebRequest.Create(WebHook);

            wr.ContentType = "application/json";
            wr.Method = "POST";

            using (var sw = new StreamWriter(wr.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    embeds = new[]
                    {
                        new
                        {
                            title = title,
                            description = msgSend
                        }
                    }
                });
                sw.Write(json);
            }
            var response = (HttpWebResponse)wr.GetResponse();
        }
        
        public void SendFile(string filepath, string filename)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                MultipartFormDataContent form = new MultipartFormDataContent();
                var file_bytes = System.IO.File.ReadAllBytes(filepath);
                form.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), filename, filename);
                httpClient.PostAsync(WebHook, form).Wait();
                httpClient.Dispose();
            }
        }
    }
}
