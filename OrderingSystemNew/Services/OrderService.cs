using System.Net.Http.Json;
using OrderingSystemNew.Models;

namespace OrderingSystemNew.Services
{
    public class OrderService
    {
        private readonly HttpClient _http;

        public OrderService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            try
            {
                Console.WriteLine($"Fetching from: {_http.BaseAddress}api/orders");
                var result = await _http.GetFromJsonAsync<List<Order>>("api/orders");
                return result ?? new List<Order>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                throw;
            }
        }

        public async Task<Order?> CreateOrderAsync(Order order)
        {
            if (string.IsNullOrWhiteSpace(order.CustomerName))
            {
                throw new ArgumentException("Customer name is required");
            }

            if (order.Total <= 0)
            {
                throw new ArgumentException("Total must be greater than 0");
            }

            var response = await _http.PostAsJsonAsync("api/orders", order);

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Failed to create order: {response.StatusCode} - {content}");
            }

            return await response.Content.ReadFromJsonAsync<Order>();
        }

        public async Task<Order?> UpdateOrderAsync(string id, Order order)
        {
            if (string.IsNullOrWhiteSpace(order.CustomerName))
            {
                throw new ArgumentException("Customer name is required");
            }

            if (order.Total <= 0)
            {
                throw new ArgumentException("Total must be greater than 0");
            }

            var response = await _http.PutAsJsonAsync($"api/orders/{id}", order);

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Failed to update order: {response.StatusCode} - {content}");
            }

            return await response.Content.ReadFromJsonAsync<Order>();
        }

        public async Task DeleteOrderAsync(string id)
        {
            var response = await _http.DeleteAsync($"api/orders/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Failed to delete order: {response.StatusCode} - {content}");
            }
        }

        public async Task<Order?> MarkAsShippedAsync(string id)
        {
            var response = await _http.PatchAsync($"api/orders/{id}/ship", null);

            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Failed to mark order as shipped: {response.StatusCode} - {content}");
            }

            return await response.Content.ReadFromJsonAsync<Order>();
        }
    }
}