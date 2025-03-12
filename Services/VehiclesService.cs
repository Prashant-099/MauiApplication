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
    public class VehiclesService
    {
  
            private readonly HttpClient _httpClient;

            public VehiclesService(HttpClient httpClient)
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
        /// Fetches a paginated list of vehicles from the API.
        /// </summary>
        public async Task<VehicleResponse> GetVehicleAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();

                var response = await _httpClient.GetAsync($"api/Vehicle?page={page}&pageSize={pageSize}");
                response.EnsureSuccessStatusCode();

                var rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw JSON Response: {rawJson}");  // Log the raw JSON

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // Deserialize JSON response
                var vehicleResponse = await response.Content.ReadFromJsonAsync<VehicleResponse>(options);

                if (vehicleResponse == null)
                {
                    throw new JsonException("The JSON response was null or invalid.");
                }

                return vehicleResponse;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Deserialization error: {ex.Message}");
                throw new Exception("Error deserializing the JSON response. Check the response structure.", ex);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw new Exception("HTTP request failed.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw new Exception("An unexpected error occurred.", ex);
            }
        }



        /// <summary>
        /// Adds a new vehicle to the API.
        /// </summary>
        public async Task<Vehicles> AddVehicleAsync(Vehicles vehicle)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PostAsJsonAsync("api/Vehicle", vehicle);
                    response.EnsureSuccessStatusCode();

                    var newVehicle = await response.Content.ReadFromJsonAsync<Vehicles>();
                    if (newVehicle == null)
                    {
                        throw new Exception("Failed to parse the added vehicle data.");
                    }

                    return newVehicle;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error adding vehicle: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Updates an existing vehicle in the API.
            /// </summary>
            public async Task UpdateVehicleAsync(Vehicles vehicle)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PutAsJsonAsync($"api/Vehicle/{vehicle.VehicleId}", vehicle);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error updating vehicle with ID {vehicle.VehicleId}: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Deletes a vehicle by ID from the API.
            /// </summary>
            public async Task DeleteVehicleAsync(int vehicleId)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.DeleteAsync($"api/Vehicle/{vehicleId}");
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error deleting vehicle with ID {vehicleId}: {ex.Message}", ex);
                }
            }
        // list of Vehicles
        public async Task<VehicleResponse> GetVehiclelistAsync()
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();

                var response = await _httpClient.GetAsync("api/Vehicle/list");
                response.EnsureSuccessStatusCode();

                var rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw JSON Response: {rawJson}");  // Log the raw JSON

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                // Deserialize JSON response
                var vehicleResponse = await response.Content.ReadFromJsonAsync<VehicleResponse>(options);

                if (vehicleResponse == null)
                {
                    throw new JsonException("The JSON response was null or invalid.");
                }

                return vehicleResponse;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Deserialization error: {ex.Message}");
                throw new Exception("Error deserializing the JSON response. Check the response structure.", ex);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw new Exception("HTTP request failed.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw new Exception("An unexpected error occurred.", ex);
            }
        }














    }

    // <summary>
    // Represents the response for fetching vehicles.
    // </summary>





}

