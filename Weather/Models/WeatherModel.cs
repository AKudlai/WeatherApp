namespace Weather.Models
{
    using Newtonsoft.Json;

    [JsonObject]
    public class WeatherModel
    {
        [JsonProperty("name")]
        public string CityName { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("rain")]
        public Rain Rain { get; set; }

        [JsonProperty("snow")]
        public Snow Snow { get; set; }
    }
}