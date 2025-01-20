using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using MauiAppFB.Models;
 
namespace MauiAppFB.Services
{
    public class AccountsService
    {
        private readonly HttpClient _httpClient;

        public AccountsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Ensures the Authorization header is set with the token from secure storage.
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
        /// Retrieves a paginated list of accounts.
        /// </summary>


        public async Task<AccountsResponse> GetAccountsAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                // Ensure the authorization header is set
                await SetAuthorizationHeaderIfNeeded();

                // Perform the API request
                var response = await _httpClient.GetAsync($"api/Accounts");
                response.EnsureSuccessStatusCode();  // Ensure the request was successful

                // Read the response content as a string (for logging and debugging)
                var rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw JSON Response: {rawJson}");  // Log the raw JSON

                // Deserialize the JSON response to the AccountsResponse model
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true  // Make property names case-insensitive
                };

                var accountsResponse = await response.Content.ReadFromJsonAsync<AccountsResponse>(options);

                // If the deserialization fails (returns null), throw an exception
                if (accountsResponse == null)
                {
                    throw new Exception("Failed to parse accounts data. The response may have an unexpected structure.");
                }

                return accountsResponse;
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
        /// Adds a new account.
        /// </summary>
        public async Task<Account> AddAccountsAsync(Account account)
        {
            
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.PostAsJsonAsync($"api/Accounts", account);
                response.EnsureSuccessStatusCode();
                var Account = await response.Content.ReadFromJsonAsync<Account>();
                if (Account == null)
                {
                    throw new Exception("Failed to parse the added company data.");
                }

                return Account;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding company: {ex.Message}", ex);
            }
        }
        

        /// <summary>
        /// Updates an existing account.
        /// </summary>
        public async Task UpdateAccountsAsync(Account account)
        {
            await SetAuthorizationHeaderIfNeeded();

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/Accounts/{account.AccountId}", account);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error updating account with ID {account.AccountId}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error while updating account with ID {account.AccountId}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Deletes an account by ID.
        /// </summary>
        public async Task DeleteAccountsAsync(int accountId)
        {
            await SetAuthorizationHeaderIfNeeded();

            try
            {
                var response = await _httpClient.DeleteAsync($"api/Accounts/{accountId}");
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Error deleting account with ID {accountId}: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error while deleting account with ID {accountId}: {ex.Message}", ex);
            }
        }




        //list of Accounts

        public async Task<AccountsResponse> GetAccountslistAsync()
        {
            try
            {
                // Ensure the authorization header is set
                await SetAuthorizationHeaderIfNeeded();

                // Perform the API request
                var response = await _httpClient.GetAsync("api/Accounts/list");
                response.EnsureSuccessStatusCode();  // Ensure the request was successful

                // Read the response content as a string (for logging and debugging)
                var rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw JSON Response: {rawJson}");  // Log the raw JSON

                // Deserialize the JSON response to the AccountsResponse model
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true  // Make property names case-insensitive
                };

                var accountsResponse = await response.Content.ReadFromJsonAsync<AccountsResponse>(options);

                // If the deserialization fails (returns null), throw an exception
                if (accountsResponse == null)
                {
                    throw new Exception("Failed to parse accounts data. The response may have an unexpected structure.");
                }

                return accountsResponse;
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






    }
}
