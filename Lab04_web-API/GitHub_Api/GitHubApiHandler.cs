using System.Net.Http;
using System.Text.Json;

namespace GitHub_Api
{
    public class GitHubApiHandler
    {
        private readonly HttpClient _client;

        public GitHubApiHandler(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://api.github.com/");
            _client.DefaultRequestHeaders.Add("User-Agent", "C# Lab4App");
            _client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
        }

        public async Task<List<Repository>> GetRepositoriesAsync()
        {

            await using Stream stream = await _client.GetStreamAsync("orgs/dotnet/repos");
            var result = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);
            return result ?? new();
        }

        public void DisplayRepositories(List<Repository> repositories)
        {
            //To display all repositories
            /*foreach (var repo in repositories)
              {
                  Console.WriteLine(repo);
                  Console.WriteLine();
              }
            */

            //To display only the top 5 repositories
            for (int i = 0; i < Math.Min(5, repositories.Count); i++)
            {
                Console.WriteLine(repositories[i]);
                Console.WriteLine();
            }

        }
    }
}