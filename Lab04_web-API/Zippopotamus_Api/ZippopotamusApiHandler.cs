using System.Net.Http;
using System.Text.Json;

namespace Zippopotamus_Api
{
    public class ZippopotamusApiHandler
    {
        private readonly HttpClient _client;

        public ZippopotamusApiHandler(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://api.zippopotam.us/");
        }

        public async Task<ZipCode?> GetZipCodeAsync(string zipCode)
        {
            Console.WriteLine($"\nFetching ZIP code details for {zipCode}...");
            try
            {
                // Correct endpoint for the given ZIP code
                var response = await _client.GetAsync($"US/{zipCode}");

                if (response.IsSuccessStatusCode)
                {
                    await using Stream stream = await response.Content.ReadAsStreamAsync();
                    var result = await JsonSerializer.DeserializeAsync<ZipCode>(stream);
                    return result;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return null;
        }

        public void DisplayZipCodeDetails(ZipCode zipCode)
        {
            Console.WriteLine($"Postal Code: {zipCode.PostCode}");
            Console.WriteLine($"Country: {zipCode.Country}");
            Console.WriteLine($"Place Name: {zipCode.Places[0].PlaceName}");
            Console.WriteLine($"State: {zipCode.Places[0].State}");
            Console.WriteLine($"Latitude: {zipCode.Places[0].Latitude}");
            Console.WriteLine($"Longitude: {zipCode.Places[0].Longitude}");
        }
    }
}
