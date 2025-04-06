
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppFB.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", new { Email = email, Password = password });
            try
            {
                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Login failed: {error}");
                }
                else
                {
                   // var result = await response.Content.ReadFromJsonAsync<AuthResult>();
                   // return result.Token;
                }
            }
            catch (Exception e) {
                Console.WriteLine($"Error:{e.Message}");
            }
            var result = await response.Content.ReadFromJsonAsync<AuthResult>();
            return result.Token;
        }
       
        public async Task LogoutAsync()
        {
            // Remove the token from secure storage
            SecureStorage.Remove("authToken");
        }
        private class AuthResult
        {
            public string Token { get; set; }
        }
    }
}
