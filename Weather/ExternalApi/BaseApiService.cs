using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Weather.ExternalApi
{
    public abstract class BaseApiService
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        protected readonly Uri ApiUrl;

        protected BaseApiService(string apiUrl)
        {
            ApiUrl = new Uri(apiUrl);
        }

        protected BaseApiService(Uri apiUrl)
        {
            ApiUrl = apiUrl;
        }

        protected BaseApiService()
        {

        }

        public async Task<HttpResponseMessage> GetAsync(Uri url, Dictionary<string, string> headers = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            AddHeadersToRequest(request, headers);

            var response = await HttpClient.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return response;
        }

        protected void AddHeadersToRequest(HttpRequestMessage request, Dictionary<string, string> headers)
        {
            if (headers != null && headers.Any())
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
        }

        protected Uri GenerateQueryLink(Uri link, IDictionary<string, string> parameters)
        {
            if (parameters != null && parameters.Any())
            {
                var urlParams = "?" + string.Join("&", parameters.Select(p => string.IsNullOrEmpty(p.Value) ? p.Key : $"{p.Key}={p.Value}"));
                return new Uri(link.AbsoluteUri + urlParams);
            }

            return link;
        }
    }
}