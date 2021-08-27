using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using WizeGo.APi.Interfaces;
using WizeGo.APi.Models;

namespace WizeGo.APi.Services
{
    public class JokesService : IJokesService
    {
        public async Task<Jokes> GetJoke(string category)
        {
            var url = "https://official-joke-api.appspot.com/jokes/programming/random";
            if (!string.IsNullOrEmpty(category))
            {
                url = url.Replace("programming",category);
            }
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (!response.IsSuccessful || string.IsNullOrEmpty(response.Content) || response.Content.Equals("[]") )
                return new Jokes{Id = 0};
  
            List<Jokes> jokes = System.Text.Json.JsonSerializer.Deserialize<List<Jokes>>(response.Content);            
            return jokes[0];
        }
    }
}