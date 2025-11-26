using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Konsumera_web_API
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("GitHub .NET Foundation Repositories\n");
            await FetchGitHubRepos();

            Console.WriteLine("\nVG: Postal Code Information\n");
            await FetchPostalCodeInfo();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static async Task FetchGitHubRepos()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "DotNetRepoViewer");

            try
            {
                var json = await client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
                var repos = JsonSerializer.Deserialize<List<Repository>>(json);

                Console.WriteLine($"Found {repos.Count} repositories\n");

                foreach (var repo in repos)
                {
                    string formattedWatchers = repo.Watchers.ToString("N0", new CultureInfo("sv-SE"));

                    string formattedDate = "N/A";
                    if (DateTime.TryParse(repo.PushedAt, out DateTime pushedDate))
                    {
                        formattedDate = pushedDate.ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    Console.WriteLine($"Name: {repo.Name}");
                    Console.WriteLine($"Homepage: {repo.Homepage ?? "N/A"}");
                    Console.WriteLine($"GitHub: {repo.HtmlUrl}");
                    Console.WriteLine($"Description: {repo.Description ?? "N/A"}");
                    Console.WriteLine($"Watchers: {formattedWatchers}");
                    Console.WriteLine($"Last push: {formattedDate}\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        static async Task FetchPostalCodeInfo()
        {
            using var client = new HttpClient();

            try
            {
                var json = await client.GetStringAsync("https://api.zippopotam.us/us/nj/montvale");
                var info = JsonSerializer.Deserialize<PostalCodeInfo>(json);

                Console.WriteLine($"Country: {info.Country}");
                Console.WriteLine($"State: {info.State} ({info.StateAbbreviation})");

                foreach (var place in info.Places)
                {
                    Console.WriteLine($"\nPlace: {place.PlaceName}");
                    Console.WriteLine($"Post Code: {place.PostCode}");
                    Console.WriteLine($"Latitude: {place.Latitude}");
                    Console.WriteLine($"Longitude: {place.Longitude}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

        [JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        [JsonPropertyName("pushed_at")]
        public string PushedAt { get; set; }
    }

    public class PostalCodeInfo
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("state abbreviation")]
        public string StateAbbreviation { get; set; }

        [JsonPropertyName("places")]
        public List<Place> Places { get; set; }
    }

    public class Place
    {
        [JsonPropertyName("place name")]
        public string PlaceName { get; set; }

        [JsonPropertyName("post code")]
        public string PostCode { get; set; }

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
    }
}