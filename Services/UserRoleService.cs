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
    public class USerRoleService
    {
      
            private readonly HttpClient _httpClient;

            public USerRoleService(HttpClient httpClient)
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
        /// Fetches a paginated list of user roles from the API.
        /// </summary>

        public async Task<UserRolesResponse>GetUserRolesAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                // Ensure the authorization header is set
                await SetAuthorizationHeaderIfNeeded();

                // Perform the API request
                var response = await _httpClient.GetAsync($"api/UserRole?page={page}&pageSize={pageSize}");
                response.EnsureSuccessStatusCode();  // Ensure the request was successful

                // Read the response content as a string (for logging and debugging)
                var rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw JSON Response: {rawJson}");  // Log the raw JSON

                // Deserialize the JSON response to the AccountsResponse model
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true  // Make property names case-insensitive
                };

                var accountsResponse = await response.Content.ReadFromJsonAsync<UserRolesResponse>();

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
        /// Adds a new user role to the API.
        /// </summary>
        public async Task<UserRoles> AddUserRoleAsync(UserRoles userRole)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PostAsJsonAsync("api/UserRole", userRole);
                    response.EnsureSuccessStatusCode();

                    var newUserRole = await response.Content.ReadFromJsonAsync<UserRoles>();
                    if (newUserRole == null)
                    {
                        throw new Exception("Failed to parse the added user role data.");
                    }

                    return newUserRole;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error adding user role: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Updates an existing user role in the API.
            /// </summary>
            public async Task UpdateUserRoleAsync(UserRoles userRole)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PutAsJsonAsync($"api/UserRole/{userRole.RoleUuid}", userRole);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error updating user role with ID {userRole.RoleUuid}: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Deletes a user role by ID from the API.
            /// </summary>
            public async Task DeleteUserRoleAsync(string roleUuid)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.DeleteAsync($"api/UserRole/{roleUuid}");
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error deleting user role with ID {roleUuid}: {ex.Message}", ex);
                }
            }
        }
    }
