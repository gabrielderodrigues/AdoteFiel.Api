using AdoteFiel.Api.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AdoteFiel.Api.Services;

public class LocationApiService
{
    private readonly string urlLocation = "https://viacep.com.br/ws/code/json/";

    public async Task<Location>? GetLocationByCepAsync(string cep)
    {
        if (cep.IsNullOrEmpty())
        {
            return new Location();
        }

        var concatUrl = urlLocation.Replace("code", cep);

        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Get, concatUrl);

            var responseMessage = await client.SendAsync(request);

            if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new Location();
            }

            var endpointResponse = await responseMessage.Content.ReadAsStringAsync();
            var jsonSerialized = JsonConvert.DeserializeObject<Location>(endpointResponse);

            return jsonSerialized!; 
        }
    }
}
