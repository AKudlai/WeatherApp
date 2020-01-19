namespace Weather.Models
{
    using Newtonsoft.Json;
    public class Main
    {
        [JsonProperty("temp_min")]
        public string TemperatureMin { get; set; }

        [JsonProperty("temp_max")]
        public string TemperatureMax { get; set; }
    }
}