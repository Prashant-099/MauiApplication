using MauiAppFB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppFB.Services
{
    public class LocationService
    {


       
            private readonly HttpClient _httpClient;

            public LocationService(HttpClient httpClient)
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

            
            /// list of locations
            public async Task<LocationResponse> GetLocationslistAsync()
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.GetAsync("api/Location/list");
                    response.EnsureSuccessStatusCode();

                    var locationResponse = await response.Content.ReadFromJsonAsync<LocationResponse>();
                    if (locationResponse == null)
                    {
                        throw new Exception("Failed to parse location data.");
                    }

                    return locationResponse;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error fetching locations: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Adds a new location to the API.
            /// </summary>
            public async Task<Locations> AddLocationAsync(Locations location)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PostAsJsonAsync("api/Location", location);
                    response.EnsureSuccessStatusCode();

                    var newLocation = await response.Content.ReadFromJsonAsync<Locations>();
                if (newLocation == null)
                {
                    throw new Exception("Failed to parse the added vehicle type data.");
                }

                return newLocation;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding vehicle type: {ex.Message}", ex);
            }
        }



        /// <summary>
        /// Updates an existing location in the API.
        /// </summary>
        public async Task UpdateLocationAsync(Locations location)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PutAsJsonAsync($"api/Location/{location.LocationId}", location);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error updating location with ID {location.LocationId}: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Deletes a location by ID from the API.
            /// </summary>
            public async Task DeleteLocationAsync(int locationId)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.DeleteAsync($"api/location/{locationId}");
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error deleting location with ID {locationId}: {ex.Message}", ex);
                }
            }


        public async Task<LocationResponse> GetLocationsAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.GetAsync($"api/location?page={page}&pageSize={pageSize}");
                response.EnsureSuccessStatusCode();

                var locationResponse = await response.Content.ReadFromJsonAsync<LocationResponse>();
                if (locationResponse == null)
                {
                    throw new Exception("Failed to parse location data.");
                }

                return locationResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching locations: {ex.Message}", ex);
            }
        }







    }

        // <summary>
        // Represents the response for fetching locations.
        // </summary>
    }



