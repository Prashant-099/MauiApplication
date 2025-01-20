using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MauiAppFB.Models;

namespace MauiAppFB.Services
{
    public class CurrenciesService
    {


       
            private readonly HttpClient _httpClient;

            public CurrenciesService(HttpClient httpClient)
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
        /// Fetches a paginated list of currencies from the API.
        /// </summary>

        public async Task<List<Currencies>>GetCurrenciesAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                // Ensure the authorization header is set
                await SetAuthorizationHeaderIfNeeded();

                // Perform the API request
                var response = await _httpClient.GetAsync($"api/Currencies");
                response.EnsureSuccessStatusCode();  // Ensure the request was successful

                // Read the response content as a string (for logging and debugging)
                var rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw JSON Response: {rawJson}");  // Log the raw JSON

                // Deserialize the JSON response to the AccountsResponse model
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true  // Make property names case-insensitive
                };

                var Currencies = await response.Content.ReadFromJsonAsync<List<Currencies>>(options);

                // If the deserialization fails (returns null), throw an exception
                if (Currencies == null)
                {
                    throw new Exception("Failed to parse accounts data. The response may have an unexpected structure.");
                }

                return Currencies;
            }
            catch (JsonException ex)
            {
                // Handle JSON-specific deserialization issues
                throw new Exception("Error deserializing the JSON response. The structure may not match the expected format.", ex);
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request errors (e.g., network issues, 4xx/5xx responses)
                throw new Exception($"HTTP request error while fetching accounts: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                // Catch any other unexpected errors
                throw new Exception($"Unexpected error while fetching accounts: {ex.Message}", ex);
            }
        }



        /// <summary>
        /// Adds a new currency to the API.
        /// </summary>
        public async Task<Currencies> AddCurrencyAsync(Currencies currency)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PostAsJsonAsync($"api/Currencies", currency);
                    response.EnsureSuccessStatusCode();

                    var newCurrency = await response.Content.ReadFromJsonAsync<Currencies>();
                    if (newCurrency == null)
                    {
                        throw new Exception("Failed to parse the added currency data.");
                    }

                    return newCurrency;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error adding currency: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Updates an existing currency in the API.
            /// </summary>
            public async Task UpdateCurrencyAsync(Currencies currency)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PutAsJsonAsync($"api/Currencies/{currency.CurrencyId}", currency);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error updating currency with ID {currency.CurrencyId}: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Deletes a currency by ID from the API.
            /// </summary>
            public async Task DeleteCurrencyAsync(int currencyId)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.DeleteAsync($"api/Currencies/{currencyId}");
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error deleting currency with ID {currencyId}: {ex.Message}", ex);
                }
            }
        }
    }


