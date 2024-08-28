using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace Product_WarehouseManagementSystem.Client
{
    public static class WarehouseClient
    {
        public static async Task<bool> Exists(int id)
        {
            using var client = new HttpClient();

            var requestUri = "https://localhost:7198/graphql";

            var requestBody = JsonConvert.SerializeObject(new
            {
                query = "query GetProduct($id: Int!) { existById(id: $id) }",
                variables = new { id }
            });

            var response = client.PostAsync(requestUri, new StringContent(requestBody, Encoding.UTF8, "application/json")).Result;
            string responseJson = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(responseJson);
            bool responceValue = (bool)jObject["data"]["existById"];
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
