using MauiAppFB.Models;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiAppFB.Services
{
    public class CompanyService
    {

        private readonly HttpClient _httpClient;

        public CompanyService(HttpClient httpClient)
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
        /// Fetches a paginated list of companies from the API.
        /// </summary>
        public async Task<List<Company>>GetCompanyAsync(int page = 1, int pageSize = 10)
        {
            try
            {
                // Ensure the authorization header is set
                await SetAuthorizationHeaderIfNeeded();

                // Perform the API request
                var response = await _httpClient.GetAsync("api/Company");
                response.EnsureSuccessStatusCode();  // Ensure the request was successful

                // Read the response content as a string (for logging and debugging)
                var rawJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Raw JSON Response: {rawJson}");  // Log the raw JSON

                // Deserialize the JSON response to the AccountsResponse model
                // Deserialize the JSON response to the AccountsResponse model
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true  // Make property names case-insensitive
                };

                var CompanyResponse = await response.Content.ReadFromJsonAsync<List<Company>>(options);

                // If the deserialization fails (returns null), throw an exception
                if (CompanyResponse == null)
                {
                    throw new Exception("Failed to parse accounts data. The response may have an unexpected structure.");
                }

                return CompanyResponse;
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
        /// Adds a new company to the API.
        /// </summary>
        public async Task<Company> AddCompanyAsync(Company company)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();

                using var content = new MultipartFormDataContent();

                // ✅ Add text fields as form-data
                content.Add(new StringContent(company.CompanyName ?? ""), "CompanyName");
                content.Add(new StringContent(company.CompanyPrintName ?? ""), "CompanyPrintName");
                content.Add(new StringContent(company.CompanyRegNo ?? ""), "CompanyRegNo");
                content.Add(new StringContent(company.CompanyCode ?? ""), "CompanyCode");
                content.Add(new StringContent(company.CompanyEmail ?? ""), "CompanyEmail");
                content.Add(new StringContent(company.CompanyMobile ?? ""), "CompanyMobile");
                content.Add(new StringContent(company.CompanyGstin ?? ""), "CompanyGstin");
                content.Add(new StringContent(company.CompanyPanNo ?? ""), "CompanyPanNo");
                content.Add(new StringContent(company.CompanyIsGstApplicable.ToString()), "CompanyIsGstApplicable");
                content.Add(new StringContent(company.CompanyGstApplicableFrom ?? ""), "CompanyGstApplicableFrom");
                content.Add(new StringContent(company.CompanyIsLutBond.ToString()), "CompanyIsLutBond");
                content.Add(new StringContent(company.CompanyLutBondNo ?? ""), "CompanyLutBondNo");
                content.Add(new StringContent(company.CompanyLutBondTo ?? ""), "CompanyLutBondTo");
                content.Add(new StringContent(company.CompanyIsEWayBill.ToString()), "CompanyIsEWayBill");
                content.Add(new StringContent(company.CompanyEWayBillFrom ?? ""), "CompanyEWayBillFrom");
                content.Add(new StringContent(company.CompanyAddedByUserId ?? ""), "CompanyAddedByUserId");
                content.Add(new StringContent(company.CompanyAddress1 ?? ""), "CompanyAddress");
                content.Add(new StringContent(company.CompanyStateId ?? ""), "CompanyStateId");
                content.Add(new StringContent(company.CompanyPincode ?? ""), "CompanyPincode");
                content.Add(new StringContent(company.CompanyContactPerson ?? ""), "CompanyContactPerson");
                content.Add(new StringContent(company.CompanyTelephone ?? ""), "CompanyTelephone");
                content.Add(new StringContent(company.CompanyFax ?? ""), "CompanyFax");
                content.Add(new StringContent(company.CompanyWebsite ?? ""), "CompanyWebsite");
                content.Add(new StringContent(company.CompanyAddress2 ?? ""), "CompanyAddress2");
                content.Add(new StringContent(company.CompanyAddress3 ?? ""), "CompanyAddress3");
                content.Add(new StringContent(company.CompanyStateCode ?? ""), "CompanyStateCode");
                content.Add(new StringContent(company.CompanyCurrency ?? ""), "CompanyCurrency");
                content.Add(new StringContent(company.CompanyEWayBillLimit.ToString()), "CompanyEWayBillLimit");
                content.Add(new StringContent(company.CompanyBeginningDate.ToString()), "CompanyBeginningDate");
                content.Add(new StringContent(company.CompanyDecimal ?? ""), "CompanyDecimal");

                //if (file != null)
                //{
                //    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.Name)}"; // Unique naam de diya
                //    var fileStream = file.OpenReadStream(10485760); // Max 10MB
                //    var fileContent = new StreamContent(fileStream);
                //    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

                //    content.Add(fileContent, "CompanyLogo", fileName);

                //    company.CompanyLogo = fileName;
                //}

                var response = await _httpClient.PostAsync("api/Company", content);
                // ✅ Print Response Content (Debugging)
                string responseJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine("⬅️ Response JSON:\n" + responseJson);
                response.EnsureSuccessStatusCode();
                var newCompany = await response.Content.ReadFromJsonAsync<Company>();
                if (newCompany == null)
                {
                    throw new Exception("Failed to parse the added company data.");
                }

                //Console.WriteLine($"Company added successfully: {newCompany.CompanyId}, Logo: {newCompany.CompanyLogo}");
                return newCompany;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding company: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Updates an existing company in the API.
        /// </summary>
        public async Task UpdateCompanyAsync(Company company)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                string currentUserId = await SecureStorage.GetAsync("userId");

                if (string.IsNullOrEmpty(currentUserId))
                {
                    currentUserId = "DefaultUser";
                }

                company.CompanyUpdatedByUserId = currentUserId;

                using var content = new MultipartFormDataContent();

                // ✅ Add text fields as form-data
                content.Add(new StringContent(company.CompanyUpdatedByUserId), "CompanyUpdatedByUserId");
                content.Add(new StringContent(company.CompanyName ?? ""), "CompanyName");
                content.Add(new StringContent(company.CompanyPrintName ?? ""), "CompanyPrintName");
                content.Add(new StringContent(company.CompanyId.ToString()), "CompanyId");
                content.Add(new StringContent(company.CompanyRegNo ?? ""), "CompanyRegNo");
                content.Add(new StringContent(company.CompanyCode ?? ""), "CompanyCode");
                content.Add(new StringContent(company.CompanyEmail ?? ""), "CompanyEmail");
                content.Add(new StringContent(company.CompanyMobile ?? ""), "CompanyMobile");
                content.Add(new StringContent(company.CompanyGstin ?? ""), "CompanyGstin");
                content.Add(new StringContent(company.CompanyPanNo ?? ""), "CompanyPanNo");
                content.Add(new StringContent(company.CompanyIsGstApplicable.ToString()), "CompanyIsGstApplicable");
                content.Add(new StringContent(company.CompanyGstApplicableFrom ?? ""), "CompanyGstApplicableFrom");
                content.Add(new StringContent(company.CompanyIsLutBond.ToString()), "CompanyIsLutBond");
                content.Add(new StringContent(company.CompanyLutBondNo ?? ""), "CompanyLutBondNo");
                content.Add(new StringContent(company.CompanyLutBondTo ?? ""), "CompanyLutBondTo");
                content.Add(new StringContent(company.CompanyIsEWayBill.ToString()), "CompanyIsEWayBill");
                content.Add(new StringContent(company.CompanyEWayBillFrom ?? ""), "CompanyEWayBillFrom");
                content.Add(new StringContent(company.CompanyAddedByUserId ?? ""), "CompanyAddedByUserId");
                content.Add(new StringContent(company.CompanyAddress1 ?? ""), "CompanyAddress");
                content.Add(new StringContent(company.CompanyStateId ?? ""), "CompanyStateId");
                content.Add(new StringContent(company.CompanyPincode ?? ""), "CompanyPincode");
                content.Add(new StringContent(company.CompanyContactPerson ?? ""), "CompanyContactPerson");
                content.Add(new StringContent(company.CompanyTelephone ?? ""), "CompanyTelephone");
                content.Add(new StringContent(company.CompanyFax ?? ""), "CompanyFax");
                content.Add(new StringContent(company.CompanyWebsite ?? ""), "CompanyWebsite");
                content.Add(new StringContent(company.CompanyAddress2 ?? ""), "CompanyAddress2");
                content.Add(new StringContent(company.CompanyAddress3 ?? ""), "CompanyAddress3");
                content.Add(new StringContent(company.CompanyStateCode ?? ""), "CompanyStateCode");
                content.Add(new StringContent(company.CompanyCurrency ?? ""), "CompanyCurrency");
                content.Add(new StringContent(company.CompanyEWayBillLimit.ToString()), "CompanyEWayBillLimit");
                content.Add(new StringContent(company.CompanyBeginningDate.ToString()), "CompanyBeginningDate");
                content.Add(new StringContent(company.CompanyDecimal ?? ""), "CompanyDecimal");

                // ✅ File Upload Logic
                //if (file != null)
                //{
                //    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.Name)}"; // Unique naam de diya
                //    var fileStream = file.OpenReadStream(10485760); // Max 10MB
                //    var fileContent = new StreamContent(fileStream);
                //    fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(file.ContentType);

                //    content.Add(fileContent, "CompanyLogo", fileName);

                //    company.CompanyLogo = fileName; // ✅ Database me file ka naam store hoga
                //}

                var response = await _httpClient.PutAsync($"api/Company/{company.CompanyId}", content);

                string responseJson = await response.Content.ReadAsStringAsync();
                //Console.WriteLine("⬅️ Response JSON:\n" + responseJson);

                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating company with ID {company.CompanyId}: {ex.Message}", ex);
            }

        }

        /// <summary>
        /// Deletes a company by ID from the API.
        /// </summary>
        public async Task DeleteCompanyAsync(int companyId)
        {
            try
            {
                await SetAuthorizationHeaderIfNeeded();
                var response = await _httpClient.DeleteAsync($"api/Company/{companyId}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting company with ID {companyId}: {ex.Message}", ex);
            }
        }




        public async Task<Company> GetCompanyByIdAsync(int companyId)
        {
            var company = await _httpClient.GetFromJsonAsync<Company>($"api/Company/{companyId}");

            if (company != null && !string.IsNullOrEmpty(company.CompanyLogo) && !company.CompanyLogo.StartsWith("data:image"))
            {
                company.CompanyLogo = $"data:image/jpeg;base64,{company.CompanyLogo}";
            }

            return company;
        }
   
    
    }

    /// <summary>
    /// Represents the response for fetching companies.
    /// </summary>
}







