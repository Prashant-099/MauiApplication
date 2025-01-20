using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using MauiAppFB.Models;
namespace MauiAppFB.Services
{
    public class CountryService
    {

      
        
            private readonly HttpClient _httpClient;

            public CountryService(HttpClient httpClient)
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
        /// Fetches a paginated list of countries from the API.
        /// </summary>
        public async Task<List<Country>> GetCountriesAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.GetAsync($"api/Country");
                response.EnsureSuccessStatusCode();

                // Assuming the response contains a list of countries
                var countryResponse = await response.Content.ReadFromJsonAsync<List<Country>>();
                if (countryResponse == null)
                {
                    throw new Exception("Failed to parse country data.");
                }

                return countryResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching countries: {ex.Message}", ex);
            }
        }


        /// <summary>
        /// Adds a new country to the API.
        /// </summary>
        public async Task<Country> AddCountryAsync(Country country)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(country.CountryName))
                    throw new ArgumentException("Country name is required.");

                await SetAuthorizationHeaderIfNeeded();
                country.CountryCompanyId = "1";
                country.CountryAddedByUserId = "1";
                country.CountryCreated = DateTime.UtcNow;
                country.CountryUpdated = DateTime.UtcNow;


                var response = await _httpClient.PostAsJsonAsync($"api/Country", country);

                if (!response.IsSuccessStatusCode)
                {
                    var errorDetails = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Error adding country: {response.StatusCode}. Details: {errorDetails}");
                }

                var newCountry = await response.Content.ReadFromJsonAsync<Country>();
                return newCountry ?? throw new Exception("Failed to parse the added country data.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding country: {ex.Message}", ex);
            }
        }


        /// <summary>
        /// Updates an existing country in the API.
        /// </summary>
        public async Task UpdateCountryAsync(Country country)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PutAsJsonAsync($"api/Country/{country.CountryId}", country);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error updating country with ID {country.CountryId}: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Deletes a country by ID from the API.
            /// </summary>
            public async Task DeleteCountryAsync(int countryId)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.DeleteAsync($"api/Country/{countryId}");
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error deleting country with ID {countryId}: {ex.Message}", ex);
                }
            }
        }
    }

