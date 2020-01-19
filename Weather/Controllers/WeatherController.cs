namespace Weather.Controllers
{
    using System.Web.Mvc;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Models;

    public class WeatherController : Controller
    {
        private const string ApiKey = "84b533cc970e909fa107b81d729a785d";

        private readonly CancellationToken _cancellationToken = default(CancellationToken);

        private static readonly HttpClient HttpClient = new HttpClient();

        public ActionResult Index()
        {
            return View();
        }

        // GET: Weather
        public async Task<ActionResult> Weather(string city)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://api.openweathermap.org/data/2.5/weather?q={city}&APPID={ApiKey}");
            var response = await HttpClient.SendAsync(request, _cancellationToken).ConfigureAwait(false);
            var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var items = JsonConvert.DeserializeObject<WeatherModel>(responseContent);
            if (items.CityName != null)
            {
                return PartialView(items);
            }
            else
            {
                return View("Index");
            }
        }
    }
}