using cllwx.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace cllwx.Services
{
    public interface IResourceGatheringService
    {
        Task<List<Product>> GetUnsortedProducts();
        Task<List<Cart>> GetShopperHistory();
        Task<int> GetCheapestTotal();
    }
    public class ResourceGatheringService
    {
        private string token = "95ff5f68-f734-4a72-8e81-d2f8c8e983b5";
        public async Task<List<Product>> GetUnsortedProducts()
        {
            var uri = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/Products?Token=" + token;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<Product>>(json);
            }
        }

        public async Task<List<Cart>> GetShopperHistory()
        {
            var uri = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/shopperHistory?Token=" + token;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<Cart>>(json);
            }
        }

        public async Task<string> GetCheapestTotal(string jsonString)
        {
            HttpClient client = new HttpClient();
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var uri = "http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/trolleyCalculator?Token=" + token;
            var response = await client.PostAsync(uri, content);
            var responseString = await response.Content.ReadAsStringAsync();
            return responseString;
        }
    }
}
