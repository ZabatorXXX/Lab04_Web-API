using System.Text.Json.Serialization;

namespace GitHub_Api
{
    public class Repository
    {
        [property: JsonPropertyName("name")]
        public string Name { get; set; }

        [property: JsonPropertyName("description")]
        public string Description { get; set; }

        [property: JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        [property: JsonPropertyName("homepage")]
        public string Homepage { get; set; }

        [property: JsonPropertyName("watchers")]
        public int Watchers { get; set; }

        [property: JsonPropertyName("pushed_at")]
        public DateTime PushedAt { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nDescription: {Description}\nURL: {HtmlUrl}\nHomepage: {Homepage}\nWatchers: {Watchers}\nLast Pushed: {PushedAt}";
        }
    }
}
