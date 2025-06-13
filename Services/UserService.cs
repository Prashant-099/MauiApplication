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
    public class UserService
    {


         private readonly HttpClient _httpClient;

            public UserService(HttpClient httpClient)
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
            /// Fetches a paginated list of users from the API.
            /// </summary>
            public async Task<UserResponse>GetUsersAsync(int page = 1, int pageSize = 10)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.GetAsync($"api/User?page={page}&pageSize={pageSize}");
                    response.EnsureSuccessStatusCode();

                var rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw JSON Response: {rawJson}");  // Log the raw JSON

                // Deserialize the JSON response to the AccountsResponse model
                // Deserialize the JSON response to the AccountsResponse model
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true  // Make property names case-insensitive
                };
                var data = await response.Content.ReadFromJsonAsync<UserResponse>();
                    if (data == null)
                    {
                        throw new Exception("Failed to parse user data.");
                    }

                    return data;
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
            /// Adds a new user to the API.
            /// </summary>
            public async Task<User> AddUserAsync(User user)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PostAsJsonAsync("api/User", user);
                    response.EnsureSuccessStatusCode();

                    var newUser = await response.Content.ReadFromJsonAsync<User>();
                    if (newUser == null)
                    {
                        throw new Exception("Failed to parse the added user data.");
                    }

                    return newUser;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error adding" +
                        $"" +
                        $" user: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Updates an existing user in the API.
            /// </summary>
            public async Task UpdateUserAsync(User user)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PutAsJsonAsync($"api/User/{user.UserId}", user);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error updating user with ID {user.UserId}: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Deletes a user by ID from the API.
            /// </summary>
            public async Task DeleteUserAsync(int userId)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.DeleteAsync($"api/User/{userId}");
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error deleting user with ID {userId}: {ex.Message}", ex);
                }
            }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.GetAsync($"api/User/{userId}");
                response.EnsureSuccessStatusCode();

                var rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw JSON Response: {rawJson}");  // Debug Log

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var user = await response.Content.ReadFromJsonAsync<User>(options);

                if (user == null)
                {
                    throw new Exception("Failed to parse user data.");
                }

                return user;
            }
            catch (JsonException ex)
            {
                throw new Exception("Error deserializing the JSON response. The structure may not match the expected format.", ex);
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"HTTP request error while fetching user: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error while fetching user: {ex.Message}", ex);
            }
        }

    }

    // <summary>
    // Represents the response for fetching users.
    // </summary>
}


