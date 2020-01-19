namespace Weather.Models
{
    using Newtonsoft.Json;

    public class Rain
    {
        [JsonProperty("1h")]
        public string RainAmountForOneHour { get; set; }

        [JsonProperty("3h")]
        public string RainAmountForTreeHours { get; set; }
    }
}