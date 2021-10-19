using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

public class JokeService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private const string JokeApiUrl = "https://karljoke.herokuapp.com/jokes/programming/random";

    public JokeService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<string> GetJokeAsync()
    {
        try
        {
            var jokes = await _httpClient.GetFromJsonAsync<Joke[]>(JokeApiUrl, _options);
            var joke = jokes?[0];
            return joke is not null
                ? $"{joke.Setup}{Environment.NewLine}{joke.Punchline}"
                : "No joke here...";
        }
        catch (Exception ex)
        {
            return $"That's not funny! {ex}";
        }
    }
}

