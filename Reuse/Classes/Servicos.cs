using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Runtime.Serialization.Json;

namespace Reuse.Classes
{
    public class Servicos
    {
        public static byte[] imageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static Response obterEnderecoDoViaCep(string query)
        {
            try
            {
                var servico = new Servicos();
                string request = servico.CreateRequest(query);
                return servico.MakeRequest(request);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public string CreateRequest(string queryString)
        {
            string UrlRequest = "https://viacep.com.br/ws/"+queryString+"/json/";
            return (UrlRequest);
        }

        public Response MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Response));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    Response jsonResponse = objResponse as Response;
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}