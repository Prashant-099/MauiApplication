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
    public class AccountGroupService
    {
      
            private readonly HttpClient _httpClient;

            public AccountGroupService(HttpClient httpClient)
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
            /// Fetches a paginated list of account groups from the API.
            /// </summary>
            public async Task<List<AccountGroup>> GetAccountGroupsAsync(int page = 1, int pageSize = 10)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.GetAsync($"api/AccountGroups");
                    response.EnsureSuccessStatusCode();

                    // Assuming the response contains a list of account groups
                    var accountGroupResponse = await response.Content.ReadFromJsonAsync<List<AccountGroup>>();
                    if (accountGroupResponse == null)
                    {
                        throw new Exception("Failed to parse account group data.");
                    }

                    return accountGroupResponse;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error fetching account groups: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Adds a new account group to the API.
            /// </summary>
            public async Task<AccountGroup> AddAccountGroupAsync(AccountGroup accountGroup)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PostAsJsonAsync("api/AccountGroups", accountGroup);
                    response.EnsureSuccessStatusCode();

                    var newAccountGroup = await response.Content.ReadFromJsonAsync<AccountGroup>();
                    if (newAccountGroup == null)
                    {
                        throw new Exception("Failed to parse the added account group data.");
                    }

                    return newAccountGroup;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error adding account group: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Updates an existing account group in the API.
            /// </summary>
            public async Task UpdateAccountGroupAsync(AccountGroup accountGroup)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.PutAsJsonAsync($"api/AccountGroups/{accountGroup.AccountGroupId}", accountGroup);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error updating account group with ID {accountGroup.AccountGroupId}: {ex.Message}", ex);
                }
            }

            /// <summary>
            /// Deletes an account group by ID from the API.
            /// </summary>
            public async Task DeleteAccountGroupAsync(int accountGroupId)
            {
                try
                {
                    await SetAuthorizationHeaderIfNeeded();
                    var response = await _httpClient.DeleteAsync($"api/AccountGroups/{accountGroupId}");
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error deleting account group with ID {accountGroupId}: {ex.Message}", ex);
                }
            }
        }
    }







