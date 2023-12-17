using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using System.Diagnostics;
using maui.Models;

namespace maui.Services
{
    public class DataService : IDataService
    {
        // HttpClient for making HTTP requests
        private readonly HttpClient _httpClient;

        // Base address of the API
        private readonly String _baseAddress;

        // Full URL for API requests
        private readonly String _url;

        // Options for JSON serialization
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        // Constructor for initializing the DataService
        public DataService()
        {
            // Initialize HttpClient
            _httpClient = new HttpClient();

            // Set the base address of the API
            _baseAddress = "http://10.10.0.222:8000";

            // Combine base address with "/api" to form the full API URL
            _url = $"{_baseAddress}/api";

            // Configure JSON serialization options
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        // Retrieve a list of sneakers from the API
        public async Task<List<Sneaker>> GetAllSneakerAsync()
        {
            List<Sneaker> sneakers = new();

            // Check for internet connectivity
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return sneakers;
            }

            try
            {
                // Make a GET request to retrieve sneakers
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/shoe");

                if (response.IsSuccessStatusCode)
                {
                    // Read and deserialize the response content
                    String content = await response.Content.ReadAsStringAsync();
                    sneakers = JsonSerializer.Deserialize<List<Sneaker>>(content, _jsonSerializerOptions);
                }
                else
                {
                    // Handle API response errors
                    Console.WriteLine($"API Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Log errors
                Debug.WriteLine(@"\tERROR getting sneakers {0}", ex.Message);
            }

            return sneakers;
        }

        // Add a new sneaker to the API
        public async Task AddSneakerAsync(Sneaker sneakers)
        {
            // Check for internet connectivity
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return;
            }

            try
            {
                // Serialize the sneaker object to JSON
                String jsonProp = JsonSerializer.Serialize<Sneaker>(sneakers, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonProp, Encoding.UTF8, "application/json");

                // Make a POST request to add the sneaker
                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/shoe", content);

                if (response.IsSuccessStatusCode)
                {
                    // Successfully added the sneaker
                }
                else
                {
                    // Handle API response errors
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Error: {response.StatusCode}, Content: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                // Log errors
                Debug.WriteLine(@"\tERROR adding sneaker {1}", ex.Message);
            }

            return;
        }

        // Update an existing sneaker in the API
        public async Task UpdateSneakerAsync(Sneaker sneak)
        {
            // Check for internet connectivity
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return;
            }

            try
            {
                // Serialize the sneaker object to JSON
                String jsonProp = JsonSerializer.Serialize<Sneaker>(sneak, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonProp, Encoding.UTF8, "application/json");

                // Make a PUT request to update the sneaker
                HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/shoe/{sneak.Id}", content);
            }
            catch (Exception ex)
            {
                // Log errors
                Debug.WriteLine(@"\tERROR {2}", ex.Message);
            }

            return;
        }

        // Delete an existing sneaker in the API
        public async Task DeleteSneakerAsync(int id)
        {
            // Check for internet connectivity
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                return;
            }

            try
            {
                // Make a DELETE request to delete the sneaker
                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/shoe/{id}");
            }
            catch (Exception ex)
            {
                // Log errors
                Debug.WriteLine(@"\tERROR {3}", ex.Message);
            }

            return;
        }
    }
}
