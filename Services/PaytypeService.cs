using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MauiAppFB.Models;

namespace MauiAppFB.Services
{
    public class PaytypeService
    {
        private readonly HttpClient _httpClient;

        public PaytypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Sets the Authorization header if an auth token exists in secure storage.
        /// </summary>
        private async Task SetAuthorizationHeaderIfNeeded()
        {
            var token = await SecureStorage.GetAsync("authToken");

            if (!string.IsNullOrEmpty(token) &&
                (_httpClient.DefaultRequestHeaders.Authorization == null ||
                 _httpClient.DefaultRequestHeaders.Authorization.Parameter != token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        /// <summary>
        /// Fetches a paginated list of pay types from the API.
        /// </summary>
        public async Task<PaytypeResponse> GetPaytypesAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.GetAsync($"api/PayType/list?page={page}&pageSize={pageSize}");
                response.EnsureSuccessStatusCode();

                var paytypeResponse = await response.Content.ReadFromJsonAsync<PaytypeResponse>();
                if (paytypeResponse == null)
                {
                    throw new Exception("Failed to parse pay type data.");
                }

                return paytypeResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching pay types: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Adds a new pay type to the API.
        /// </summary>
        public async Task<Paytype> AddPaytypeAsync(Paytype paytype)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.PostAsJsonAsync("api/PayType/list", paytype);
                response.EnsureSuccessStatusCode();

                var newPaytype = await response.Content.ReadFromJsonAsync<Paytype>();
                if (newPaytype == null)
                {
                    throw new Exception("Failed to parse the added pay type data.");
                }

                return newPaytype;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding pay type: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Updates an existing pay type in the API.
        /// </summary>
        public async Task UpdatePaytypeAsync(Paytype paytype)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.PutAsJsonAsync($"api/PayType/list/{paytype.PayTypeId}", paytype);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating pay type with ID {paytype.PayTypeId}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Deletes a pay type by ID from the API.
        /// </summary>
        public async Task DeletePaytypeAsync(int paytypeId)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.DeleteAsync($"api/PayType/list/{paytypeId}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting pay type with ID {paytypeId}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Fetches a list of all pay types from the API.
        /// </summary>
        public async Task<PaytypeResponse> GetPaytypesListAsync()
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.GetAsync("api/PayType/list");
                response.EnsureSuccessStatusCode();

                var paytypeResponse = await response.Content.ReadFromJsonAsync<PaytypeResponse>();
                if (paytypeResponse == null)
                {
                    throw new Exception("Failed to parse pay type data.");
                }

                return paytypeResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching pay types: {ex.Message}", ex);
            }
        }
    }
}
