using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Weather.OpenWeather.Models;

namespace Weather.OpenWeather
{
    public interface IOpenWeatherApiService
    {
        /// <summary>
        /// Api endpoint
        /// </summary>
        Uri ApiEndpoint { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<(IEnumerable<TodayWeatherViewModel> items, HttpResponseMessage response)> GetListAsync(
            string city, CancellationToken cancellationToken = default(CancellationToken));

    }
}