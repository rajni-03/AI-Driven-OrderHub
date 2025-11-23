using System.Net.Http.Json;
using OrderingSystem.Shared.Models;

namespace OrderingSystem.Services
{
    public class OrderService
    {
        private readonly HttpClient _http;
        public OrderService(HttpClient http) => _http = http;

        public async Task<List<Order>> GetOrdersAsync() =>
            await _http.GetFromJsonAsync<List<Order>>("api/Orders") ?? new List<Order>();

        public async Task<Order?> CreateOrderAsync(Order order)
        {
            var response = await _http.PostAsJsonAsync("api/orders", order);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Order>();
        }
    }
}
