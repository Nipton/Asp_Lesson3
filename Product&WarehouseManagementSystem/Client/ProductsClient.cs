using HotChocolate.Language;
using System.Text.Json;
using System.Text;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Product_WarehouseManagementSystem.Client
{
    public static class ProductsClient 
    {
        public static async Task<bool> Exists(int id)
        {
            using var client = new HttpClient();

            var requestUri = "https://localhost:7017/graphql";

            var requestBody = JsonConvert.SerializeObject(new
            {
                query = "query GetProduct($id: Int!) { product(id: $id) }",
                variables = new { id }
            });

            var response =  client.PostAsync(requestUri, new StringContent(requestBody, Encoding.UTF8, "application/json")).Result;
            string responseJson = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(responseJson);
            bool responceValue = (bool)jObject["data"]["product"];
            if (responceValue)
            {
                return true;
            }
            else if (!responceValue)
            {
                return false;
            }
            throw new Exception("Неизвестное значение: " + responceValue);
        }
    }
}