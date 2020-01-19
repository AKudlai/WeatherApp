namespace Weather.ExternalApi.OpenWeather
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using Newtonsoft.Json;

    using Weather.OpenWeather.Models;
    using Weather.OpenWeather;

    public class OpenWeatherApiService : BaseApiService, IOpenWeatherApiService
    {
        private const string OPEN_WEATHER_API_TIMEZONE = "Pacific Standard Time";
        private const string CASES_ENDPOINT = "v1/cases";
        private const string Open_Weather_Api_Url = ""; //To Do get from config
        private const string Open_Weather_Key = "84b533cc970e909fa107b81d729a785d"; //To Do get from config

        private readonly Dictionary<string, string> _headers;
        private readonly TimeZoneInfo _dashApiTimezone;

        public Uri ApiEndpoint { get; }
        public OpenWeatherApiService() 
            : base(new Uri(new Uri(Open_Weather_Api_Url), CASES_ENDPOINT))
        {
            _dashApiTimezone = TimeZoneInfo.FindSystemTimeZoneById(OPEN_WEATHER_API_TIMEZONE);
            _headers = new Dictionary<string, string>
            {
                ["Authorization"] = Open_Weather_Api_Url
            };
        }

        public async Task<(IEnumerable<TodayWeatherViewModel> items, HttpResponseMessage response)> GetListAsync(string city, CancellationToken cancellationToken = default(CancellationToken))
        {
            var parameters = new Dictionary<string, string>
            {
                ["city"] = city
            };

            var link = GenerateQueryLink(ApiUrl, parameters);

            var response = await GetAsync(link, _headers, cancellationToken).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var items = JsonConvert.DeserializeObject<IEnumerable<TodayWeatherViewModel>>(responseContent);
            return (items, response);
        }
    }
}