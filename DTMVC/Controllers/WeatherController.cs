using DTMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DTMVC.Controllers
{
    public class WeatherController : Controller
    {
        private readonly string apiKey = "b1980fb939e89edee0bd4a3a23af5254";

        public IActionResult Index()
        {
            return View(new WeatherModel { Ciudad = "Guatemala City", Pais = "Guatemala" });
        }

        [HttpPost]
        public async Task<IActionResult> GetWeather(WeatherModel model)
        {
            if (string.IsNullOrEmpty(model.Ciudad)) model.Ciudad = "Guatemala City";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={model.Ciudad}&appid={apiKey}&units=metric&lang=es";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<dynamic>(response);

                if (data?.cod == "200")
                {
                    model.Temperatura = data.main.temp;
                    model.Descripcion = data.weather[0].description;
                    model.Humedad = data.main.humidity;
                    model.Viento = data.wind.speed;
                }
                else
                {
                    ViewBag.Error = "Ciudad no encontrada. Intenta con otro nombre.";
                }
            }

            return View("Index", model);
        }
    }
}
