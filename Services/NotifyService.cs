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
    public class NotifyService
    {

            private readonly HttpClient _httpClient;

            public NotifyService(HttpClient httpClient)
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


        public async Task<NotifyResponse>GetNotifyAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                // Ensure the authorization header is set
                await SetAuthorizationHeaderIfNeeded();

                // Perform the API request
                var response = await _httpClient.GetAsync($"api/Notify?page={page}&pageSize={pageSize}");
                response.EnsureSuccessStatusCode();  // Ensure the request was successful

                // Read the response content as a string (for logging and debugging)
                var rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw JSON Response: {rawJson}");  // Log the raw JSON

                // Deserialize the JSON response to the AccountsResponse model
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true  // Make property names case-insensitive
                };

                var NotifyResponse = await response.Content.ReadFromJsonAsync<NotifyResponse>(options);

                // If the deserialization fails (returns null), throw an exception
                if (NotifyResponse == null)
                {
                    throw new Exception("Failed to parse accounts data. The response may have an unexpected structure.");
                }

                return NotifyResponse;
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
        /// Adds a new notification to the API.
        /// </summary>
        public async Task<Notify> AddNotifyAsync(Notify notification)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PostAsJsonAsync("api/Notify", notification);
                    response.EnsureSuccessStatusCode();

                    var newNotification = await response.Content.ReadFromJsonAsync<Notify>();
                    if (newNotification == null)
                    {
                        throw new Exception("Failed to parse the added notification data.");
                    }

                    return newNotification;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error adding notification: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Updates an existing notification in the API.
            /// </summary>
            public async Task UpdateNotifyAsync(Notify notification)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PutAsJsonAsync($"api/Notify/{notification.NotifyId}", notification);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error updating notification with ID {notification.NotifyId}: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Deletes a notification by ID from the API.
            /// </summary>
            public async Task DeleteNotifyAsync(int notifyId)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.DeleteAsync($"api/Notify/{notifyId}");
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error deleting notification with ID {notifyId}: {ex.Message}", ex);
                }
            }
        }

        /// <summary>
        /// Represents the response for fetching notifications.
        /// </summary>
      
        /// <summary>
        /// Represents a single notification.
        /// </summary>
       
    }
 


