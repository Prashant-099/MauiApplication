using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using MauiAppFB.Models;

namespace MauiAppFB.Services
{
    public class StatesService
    {
        private readonly HttpClient _httpClient;

        public StatesService(HttpClient httpClient)
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
        /// Fetches a paginated list of states from the API.
        /// </summary>
        public async Task<List<States>>GetStatesAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                // Ensure the authorization header is set
                await SetAuthorizationHeaderIfNeeded();

                // Perform the API request
                var response = await _httpClient.GetAsync($"api/States?page={page}&pageSize={pageSize}");
                response.EnsureSuccessStatusCode();  // Ensure the request was successful

                // Read the response content as a string (for logging and debugging)
                var rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw JSON Response: {rawJson}");  // Log the raw JSON

                // Deserialize the JSON response to the AccountsResponse model
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true  // Make property names case-insensitive
                };

                var StatesResponse = await response.Content.ReadFromJsonAsync<List<States>>(options);

                // If the deserialization fails (returns null), throw an exception
                if (StatesResponse == null)
                {
                    throw new Exception("Failed to parse accounts data. The response may have an unexpected structure.");
                }

                return StatesResponse;
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
        /// Adds a new state to the API.
        /// </summary>
        public async Task<States> AddStateAsync(States state)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.PostAsJsonAsync("api/States", state);
                response.EnsureSuccessStatusCode();

                var newState = await response.Content.ReadFromJsonAsync<States>();
                if (newState == null)
                {
                    throw new Exception("Failed to parse the added state data.");
                }

                return newState;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding state: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Updates an existing state in the API.
        /// </summary>
        public async Task UpdateStateAsync(States state)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.PutAsJsonAsync($"api/States/{state.StateId}", state);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating state with ID {state.StateId}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Deletes a state by ID from the API.
        /// </summary>
        public async Task DeleteStateAsync(int stateId)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.DeleteAsync($"api/States/{stateId}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting state with ID {stateId}: {ex.Message}", ex);
            }
        }
    }
}
