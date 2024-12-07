using System.Text.Json;
using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace API.Services;

public class OmdbService(HttpClient httpClient, IOptions<OmdbSettings> options, IMapper mapper) : IOmdbService
{
    private readonly HttpClient httpClient = httpClient;
    private readonly OmdbSettings settings = options.Value;

    public async Task<MovieMetadata?> GetMovieDetailsAsync(string title)
    {
        var url = $"{settings.BaseUrl}?apikey={settings.ApiKey}&t={Uri.EscapeDataString(title)}";

        var response = await httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, 
        };

        var movieDetails = JsonSerializer.Deserialize<OmdbApiResponse>(jsonResponse, options);

        return mapper.Map<MovieMetadata>(movieDetails);
    }
}
