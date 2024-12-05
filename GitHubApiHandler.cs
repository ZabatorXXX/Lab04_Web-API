using System.Net.Http;
using System.Text.Json;

public class GitHubApiHandler
{
    HttpClient client = new()
    {
        BaseAddress = new Uri("https://api.github.com/")
    };

    // Add the necessary headers for GitHub API
    client.DefaultRequestHeaders.Add("User-Agent", "C# Lab4App");
client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");


Console.WriteLine("Hämtar repositories");
var repositories = await GetRepositoriesAsync(client);

    Console.WriteLine(client);

Console.WriteLine("\n\nHämta alla repositories:");
var posts = await GetRepositoriesAsync(client);
/* Display repositories in console
foreach (var repo in repositories)
{
    Console.WriteLine(repo);
    Console.WriteLine();
}
*/

for (int i = 0; i< 5; i++)
{
    Console.WriteLine(repositories[i]);
    Console.WriteLine();
}

Console.Write("\n\nPress any key to close the application...");
Console.ReadKey();

// Methods to fetch data from the GitHub API
static async Task<List<Repository>> GetRepositoriesAsync(HttpClient client)
{
    // Fetch data from the GitHub API
    await using Stream stream = await client.GetStreamAsync("orgs/dotnet/repos");
    var result = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);

    return result ?? new();
}
}
