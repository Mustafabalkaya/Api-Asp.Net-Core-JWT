using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                List<BookingApiLocationSearchViewModel> model = new List<BookingApiLocationSearchViewModel>();

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityName}&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "8d080ff47cmsh2ef0fc27a094026p1e3352jsnf2d8a77987cc" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(model.Take(1).ToList());
                }

            }
            else
            {
                List<BookingApiLocationSearchViewModel> model = new List<BookingApiLocationSearchViewModel>();

                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/locations?name=paris&locale=en-gb"),
                    Headers =
    {
        { "X-RapidAPI-Key", "8d080ff47cmsh2ef0fc27a094026p1e3352jsnf2d8a77987cc" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
                };
                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<List<BookingApiLocationSearchViewModel>>(body);
                    return View(model.Take(1).ToList());
                }
            }
            
        }
    }
}
