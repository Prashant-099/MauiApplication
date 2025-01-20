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
    public class LRService
    {

        private readonly HttpClient _httpClient;

        public LRService(HttpClient httpClient)
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
        /// Fetches a paginated list of LRs from the API.
        /// </summary>
        public async Task<LRResponse> GetLRsAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.GetAsync($"api/Lr?page={page}&pageSize={pageSize}");
                response.EnsureSuccessStatusCode();

                var lrResponse = await response.Content.ReadFromJsonAsync<LRResponse>();
                if (lrResponse == null)
                {
                    throw new Exception("Failed to parse LR data.");
                }

                return lrResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching LRs: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Adds a new LR to the API.
        /// </summary>
        public async Task<Lr> AddLRAsync(Lr lr)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.PostAsJsonAsync("api/Lr", lr);
                response.EnsureSuccessStatusCode();

                var newLR = await response.Content.ReadFromJsonAsync<Lr>();
                if (newLR == null)
                {
                    throw new Exception("Failed to parse the added LR data.");
                }

                return newLR;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding LR: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Updates an existing LR in the API.
        /// </summary
        public async Task UpdateLRAsync(Lr lr)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.PutAsJsonAsync($"api/Lr/{lr.LRId}", lr);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating LR with ID {lr.LRId}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Deletes an LR by ID from the API.
        /// </summary>
        public async Task DeleteLRAsync(int lrId)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.DeleteAsync($"api/lr/{lrId}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting LR with ID {lrId}: {ex.Message}", ex);
            }
        }
    }

    /// <summary>
    /// Represents the response for fetching LRs.
    /// </summary>
  
    } 
