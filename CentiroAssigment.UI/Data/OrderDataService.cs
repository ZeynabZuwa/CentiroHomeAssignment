using CentiroAssignment.Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CentiroAssigment.UI.Data
{
    public class OrderDataService : IOrderDataService
    {
        private readonly HttpClient _httpClient;

        public OrderDataService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<OrderResponse>> GetAllOrders()
        {

            var order = await _httpClient.GetAsync("Orders");
            return await order.Content.ReadFromJsonAsync<List<OrderResponse>>();

        }

        public async Task ImportOrders(string filePath)
        {
            var jsonOrder = new StringContent(JsonSerializer.Serialize(filePath), Encoding.UTF8, "application/json");

            var test = await _httpClient.PostAsync("Orders", jsonOrder);

        }
    }
}
