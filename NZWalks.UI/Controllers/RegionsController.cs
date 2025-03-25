using Microsoft.AspNetCore.Mvc;
using NZWalks.UI.Models;
using NZWalks.UI.Models.DTO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NZWalks.UI.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public RegionsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<RegionDTO> regions = new List<RegionDTO>();
            try
            {

                //Get all regions from web api
                var client = httpClientFactory.CreateClient();
                var httpResponseMessage = await client.GetAsync("https://localhost:3030/api/regions");

                httpResponseMessage.EnsureSuccessStatusCode();

                regions.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<RegionDTO>>());
            }
            catch (Exception ex)
            {
                //Log Exception
            }
            return View(regions);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRegionViewModel model)
        {
            var client = httpClientFactory.CreateClient();
            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:3030/api/regions"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDTO>();

            if (response is not null)
                return RedirectToAction("Index");
            else
                return View();              
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid ID) 
        {
            var client = httpClientFactory.CreateClient();
            var response = await client.GetFromJsonAsync<RegionDTO>($"https://localhost:3030/api/regions/{ID}");
            
            if(response is not null)
                return View(response);
            else 
                return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionDTO request) 
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:3030/api/regions/{request.ID}"),
                Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<RegionDTO>();

            if (response is not null) 
                return RedirectToAction("Index");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete (RegionDTO request)
        {
            try
            {
                var client = httpClientFactory.CreateClient();
                var httpResponseMessage = await client.DeleteAsync($"https://localhost:3030/api/regions/{request.ID}");
                httpResponseMessage.EnsureSuccessStatusCode();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                //
            }
            return View();

        }
    }
}
