namespace Weather.Models
{
    using Newtonsoft.Json;

    public class Snow
    {
        [JsonProperty("1h")]
        public string SnowAmountForOneHour { get; set; }

        [JsonProperty("3h")]
        public string SnowRainAmountForTreeHours { get; set; }
    }
}