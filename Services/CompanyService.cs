using MauiAppFB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiAppFB.Services
{
    public class CompanyService
    {

        private readonly HttpClient _httpClient;

        public CompanyService(HttpClient httpClient)
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
        /// Fetches a paginated list of companies from the API.
        /// </summary>
        public async Task<List<Company>>GetCompanyAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                // Ensure the authorization header is set
                await SetAuthorizationHeaderIfNeeded();

                // Perform the API request
                var response = await _httpClient.GetAsync("api/Company");
                response.EnsureSuccessStatusCode();  // Ensure the request was successful

                // Read the response content as a string (for logging and debugging)
                var rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw JSON Response: {rawJson}");  // Log the raw JSON

                // Deserialize the JSON response to the AccountsResponse model
                // Deserialize the JSON response to the AccountsResponse model
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true  // Make property names case-insensitive
                };

                var CompanyResponse = await response.Content.ReadFromJsonAsync<List<Company>>(options);

                // If the deserialization fails (returns null), throw an exception
                if (CompanyResponse == null)
                {
                    throw new Exception("Failed to parse accounts data. The response may have an unexpected structure.");
                }

                return CompanyResponse;
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
        /// Adds a new company to the API.
        /// </summary>
        public async Task<Company> AddCompanyAsync(Company company)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.PostAsJsonAsync("api/Company", company);
                response.EnsureSuccessStatusCode();

                var newCompany = await response.Content.ReadFromJsonAsync<Company>();
                if (newCompany == null)
                {
                    throw new Exception("Failed to parse the added company data.");
                }

                return newCompany;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding company: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Updates an existing company in the API.
        /// </summary>
        public async Task UpdateCompanyAsync(Company company)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.PutAsJsonAsync($"api/Company/{company.CompanyId}", company);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating company with ID {company.CompanyId}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Deletes a company by ID from the API.
        /// </summary>
        public async Task DeleteCompanyAsync(int companyId)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.DeleteAsync($"api/Company/{companyId}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting company with ID {companyId}: {ex.Message}", ex);
            }
        }
    }

    /// <summary>
    /// Represents the response for fetching companies.
    /// </summary>
}







