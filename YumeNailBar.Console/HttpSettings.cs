using System.Net.Http.Headers;

namespace YumeNailBar.Console;

public class HttpSettings
{
    private readonly HttpClient _httpClient;

    public HttpSettings(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public HttpClient HttpClient => _httpClient;

    public void Configure(HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri("http://localhost:32768/");
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }
}