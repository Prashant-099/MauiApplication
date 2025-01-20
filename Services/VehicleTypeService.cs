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
    public class VehicleTypeService
    {

     
            private readonly HttpClient _httpClient;

            public VehicleTypeService(HttpClient httpClient)
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
            /// Fetches a paginated list of vehicle types from the API.
            /// </summary>
            public async Task<VehicleTypeResponse> GetVehicleTypesAsync(int page = 1, int pageSize = 10)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();

                    var response = await _httpClient.GetAsync($"api/VehicleType?page={page}&pageSize={pageSize}");
                    response.EnsureSuccessStatusCode();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var vehicleTypeResponse = await response.Content.ReadFromJsonAsync<VehicleTypeResponse>(options);

                    if (vehicleTypeResponse == null)
                    {
                        throw new Exception("Failed to parse vehicle type data. The response may have an unexpected structure.");
                    }

                    return vehicleTypeResponse;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"JSON Deserialization Error: {ex.Message}");
                    throw new Exception("Error deserializing the JSON response. The structure may not match the expected format.", ex);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"HTTP Request Error: {ex.Message}");
                    throw new Exception($"Error fetching vehicle types: {ex.Message}", ex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected Error: {ex.Message}");
                    throw new Exception($"Unexpected error while fetching vehicle types: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Adds a new vehicle type to the API.
            /// </summary>
            public async Task<VehicleType> AddVehicleTypeAsync(VehicleType vehicleType)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PostAsJsonAsync("api/VehicleType", vehicleType);
                    response.EnsureSuccessStatusCode();

                    var newVehicleType = await response.Content.ReadFromJsonAsync<VehicleType>();
                    if (newVehicleType == null)
                    {
                        throw new Exception("Failed to parse the added vehicle type data.");
                    }

                    return newVehicleType;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error adding vehicle type: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Updates an existing vehicle type in the API.
            /// </summary>
            public async Task UpdateVehicleTypeAsync(VehicleType vehicleType)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PutAsJsonAsync($"api/VehicleType/{vehicleType.VehicleTypeId}", vehicleType);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error updating vehicle type with ID {vehicleType.VehicleTypeId}: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Deletes a vehicle type by ID from the API.
            /// </summary>
            public async Task DeleteVehicleTypeAsync(int vehicleTypeId)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.DeleteAsync($"api/VehicleType/{vehicleTypeId}");
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error deleting vehicle type with ID {vehicleTypeId}: {ex.Message}", ex);
                }
            }
        }

    }


