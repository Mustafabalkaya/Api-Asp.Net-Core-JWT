using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace HotelProject.WebUI.ViewComponents.DashBoard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //INSTAGRAM
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/mustafaabalkaya"),
                Headers =
    {
        { "X-RapidAPI-Key", "a1344756bdmshecfbb03c696481cp1e74e3jsnd4e38a321dd0" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
               // response.EnsureSuccessStatusCode();
                if (ViewBag.v1 == null && ViewBag.v2 == null)
                {
                    ViewBag.v1 = 290;
                    ViewBag.v2 = 190;

                }
                else
                {
                    var body = await response.Content.ReadAsStringAsync();
                    ResultInsFollowersDto resultInsFollowersDto = JsonConvert.DeserializeObject<ResultInsFollowersDto>(body);
                    ViewBag.v1 = resultInsFollowersDto.followers;
                    ViewBag.v2 = resultInsFollowersDto.following;
                }
            }



            //TWİTTER


            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter135.p.rapidapi.com/AutoComplete/?q=mustafaabalkaya"),
                Headers =
    {
        { "X-RapidAPI-Key", "a1344756bdmshecfbb03c696481cp1e74e3jsnd4e38a321dd0" },
        { "X-RapidAPI-Host", "twitter135.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                //response2.EnsureSuccessStatusCode();
                if (ViewBag.t1 == null && ViewBag.t2 == null)
                {
                    ViewBag.t1 = 350;
                    ViewBag.t2 = 200;
                }
                else
                {
                    var body2 = await response2.Content.ReadAsStringAsync();

                    if (response2.StatusCode == HttpStatusCode.TooManyRequests) // 429 hatası kontrolü
                    {
                        // Hata durumunda bekleme süresini al
                        if (response2.Headers.TryGetValues("Retry-After", out IEnumerable<string> values))
                        {
                            int retryAfterSeconds = Convert.ToInt32(values.First());
                            await Task.Delay(TimeSpan.FromSeconds(retryAfterSeconds)); // Belirtilen süre kadar bekle
                                                                                       // İstekleri yeniden denemek için gerekli kodu buraya ekleyebilirsiniz
                        }
                        else
                        {
                            // Retry-After başlığı yoksa varsayılan olarak belirli bir süre bekleyebilirsiniz.
                            await Task.Delay(TimeSpan.FromSeconds(60)); // Varsayılan 60 saniye bekleme
                                                                        // İstekleri yeniden denemek için gerekli kodu buraya ekleyebilirsiniz
                        }
                    }
                    else
                    {
                        ResultTwFollowersDto resultTwFollowersDto = JsonConvert.DeserializeObject<ResultTwFollowersDto>(body2);
                        ViewBag.t1 = resultTwFollowersDto.data.user_info.followers_count;
                        ViewBag.t2 = resultTwFollowersDto.data.user_info.friends_count;
                    }
                }
            }



            //LINKEDIN
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fmustafabalkaya%2F"),
                Headers =
    {
        { "X-RapidAPI-Key", "8d080ff47cmsh2ef0fc27a094026p1e3352jsnf2d8a77987cc" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                
                //response3.EnsureSuccessStatusCode();
                if (ViewBag.l1 == null)
                {
                    ViewBag.l1 = 500;
                }
                else
                {
                    var body3 = await response3.Content.ReadAsStringAsync();
                    ResultLnFollowersDto resultLnFollowersDto = JsonConvert.DeserializeObject<ResultLnFollowersDto>(body3);
                    ViewBag.l1 = resultLnFollowersDto.data.followers_count;
                }
            }
            return View();
        }
    }
}
