using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AngularNetCoreApi
{
    public class MemberService
    {

        private string token = null;

        public MemberService()
        {
            token = GetToken().Result;
        }

       private async Task<string> GetToken()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    ////httpClient.BaseAddress = new Uri("https://handson-apim.azure-api.net/");
                    httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "ce654f4a1eac441c86dafa08aa9cde46");
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var data = new
                    {
                        userName = "google",
                        password = "google"

                    };

                    var credential = JsonConvert.SerializeObject(data);
                    var httpContent = new StringContent(credential, Encoding.UTF8, "application/json");

                    var httpResponseMessage = await httpClient.PostAsync("https://handson-apim.azure-api.net/v1/Member/authentication", httpContent);

                    if (httpResponseMessage.Content != null)
                    {
                        string responseContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        responseContent = responseContent.Substring(responseContent.IndexOf("\"") + 1, responseContent.LastIndexOf("\"") - 1);
                        return responseContent;
                    }
                    else
                    {
                        return null;
                    }


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
       public async Task<List<MemberEntity>> GetAllMembers()
        {
            if (token == null)
            {
                return null;

            }

            try
            {
                var uri = new Uri("https://handson-apim.azure-api.net/v1/Member/GetAllMembers");
            using (var httpClient = new HttpClient())
                {
                    //httpClient.BaseAddress = new Uri("https://handson-apim.azure-api.net/");
                    httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "ce654f4a1eac441c86dafa08aa9cde46");
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    string response = await httpClient.GetStringAsync(uri);

                    if(response != null)
                    {
                        List<MemberEntity> memberEntities = JsonConvert.DeserializeObject<List<MemberEntity>>(response);
                        return memberEntities;
                    }
                    else
                    {
                        return null;
                    }


                }

        }
            catch(Exception ex)
            {
                throw ex;
            }

}


    }
}
