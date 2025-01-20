using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MauiAppFB.Models;
namespace MauiAppFB.Services
{
    public class CargoService
    {
        private readonly HttpClient _httpClient;

        public CargoService(HttpClient httpClient)
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
        /// Fetches a paginated list of cargos from the API.
        /// </summary>
        public async Task<CargoResponse> GetCargosAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.GetAsync($"api/cargo?page={page}&pageSize={pageSize}");
                response.EnsureSuccessStatusCode();

                var cargoResponse = await response.Content.ReadFromJsonAsync<CargoResponse>();
                if (cargoResponse == null)
                {
                    throw new Exception("Failed to parse cargo data.");
                }

                return cargoResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching cargos: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Adds a new cargo to the API.
        /// </summary>
        public async Task<Cargo> AddCargoAsync(Cargo cargo)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.PostAsJsonAsync("api/cargo", cargo);
                response.EnsureSuccessStatusCode();

                var newCargo = await response.Content.ReadFromJsonAsync<Cargo>();
                if (newCargo == null)
                {
                    throw new Exception("Failed to parse the added cargo data.");
                }

                return newCargo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding cargo: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Updates an existing cargo in the API.
        /// </summary>
        public async Task UpdateCargoAsync(Cargo cargo)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.PutAsJsonAsync($"api/cargo/{cargo.CargoId}", cargo);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating cargo with ID {cargo.CargoId}: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Deletes a cargo by ID from the API.
        /// </summary>
        public async Task DeleteCargoAsync(int cargoId)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.DeleteAsync($"api/cargo/{cargoId}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting cargo with ID {cargoId}: {ex.Message}", ex);
            }
        }


        //list of cargo

        public async Task<CargoResponse> GetCargoslistAsync()
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.GetAsync("api/Cargo/list");
                response.EnsureSuccessStatusCode();

                var cargoResponse = await response.Content.ReadFromJsonAsync<CargoResponse>();
                if (cargoResponse == null)
                {
                    throw new Exception("Failed to parse cargo data.");
                }

                return cargoResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching cargos: {ex.Message}", ex);
            }
        }




    }

    // <summary>
    // Represents the response for fetching cargos.
    // </summary>

}
