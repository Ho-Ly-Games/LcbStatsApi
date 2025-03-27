using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace LcboStatsApi
{
    public static class LcboStatsEndpoints
    {
        public const string BaseUrl = "https://lcbostats.com/api";
        public const string Products = BaseUrl + "/alcohol";
        public const string Product = BaseUrl + "/alcohol/{0}";
    }

    public class LcboStatsClient
    {
        private readonly HttpClient _httpClient;

        public LcboStatsClient(HttpClient? httpClient = null)
        {
            _httpClient = httpClient ?? new HttpClient { BaseAddress = new Uri(LcboStatsEndpoints.BaseUrl) };
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "LcboStatsApi");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<LcboResultList> GetProductsAsync(string? query = null)
        {
            var url = new Uri(
                LcboStatsEndpoints.Products + (query != null ? $"?search={query}" : string.Empty),
                UriKind.Absolute
            );
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<LcboResultList>(
                    await response.Content.ReadAsStreamAsync()
                ) ?? new LcboResultList();
            }

            return new LcboResultList();
        }

        public async Task<Product?> GetProductAsync(string id)
        {
            var response = await _httpClient.GetAsync(string.Format(LcboStatsEndpoints.Product, id));
            if (response.IsSuccessStatusCode)
            {
                return (await JsonSerializer.DeserializeAsync<LcboResultItem>(
                    await response.Content.ReadAsStreamAsync()
                ))?.Product;
            }

            return null;
        }
    }
}