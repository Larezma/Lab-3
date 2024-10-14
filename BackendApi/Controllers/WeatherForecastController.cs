using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    public class WeatherDate
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Degree { get; set; }
        public string Location { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastContoller : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Frezing","Bracing","Chilly","Cool","Mild","Warm","Balmy","Hot","Sqeltering","Scorching"
        };

        public static List<WeatherDate> weatherDates = new()
        {
            new WeatherDate() {Id=1,Date="21.01.2024",Degree=10,Location="Мурмарнск" },
            new WeatherDate() {Id=23,Date="22.01.2024",Degree=20,Location="Пермь" },
            new WeatherDate() {Id=24,Date="23.01.2024",Degree=15,Location="Омск" },
            new WeatherDate() {Id=25,Date="24.01.2024",Degree=0,Location="Мда да" },
            new WeatherDate() {Id=30,Date="25.01.2024",Degree=3,Location="Москва" },
        };

        [HttpGet]

        public List<WeatherDate> GetALL()
        {
            return weatherDates;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            for (int i = 0; i < weatherDates.Count; i++)
            {
                if (weatherDates[i].Id < 0)
                {
                    return BadRequest("поле id не может быть меньше нуля!");
                }
                if (weatherDates[i].Id == id)
                {
                    return Ok(weatherDates[i]);
                }
            }
            return BadRequest("Нету такой записи!");
        }

        [HttpPost]
        public IActionResult Add(WeatherDate date)
        {
            for (int i = 0; i < weatherDates.Count; i++)
            {
                if (weatherDates[i].Id < 0)
                {
                    return BadRequest("поле id не может быть меньше нуля!");
                }
                if (weatherDates[i].Id == date.Id)
                {
                    return BadRequest("такая запись уже сущеуствует!");
                }
            }
            weatherDates.Add(date);
            return Ok();
        }

        [HttpPut]

        public IActionResult Put(WeatherDate date)
        {
            for (int i = 0; i < weatherDates.Count; i++)
            {
                if (weatherDates[i].Id < 0)
                {
                    return BadRequest("поле id не может быть меньше нуля!");
                }
                if (weatherDates[i].Id == date.Id)
                {
                    weatherDates[i] = date;
                    return Ok();
                }
            }
            return BadRequest("Нету такой записи!");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            for (int i = 0; i < weatherDates.Count; i++)
            {
                if (weatherDates[i].Id < 0)
                {
                    return BadRequest("поле id не может быть меньше нуля!");
                }
                if (weatherDates[i].Id == id)
                {
                    weatherDates.RemoveAt(i);
                    return Ok();
                }
            }
            return BadRequest("Нету такой записи!");
        }

        [HttpGet("find-by-city")]
        public IActionResult GetLocationn(string location)
        {
            for (int i = 0; i < weatherDates.Count; i++)
            {
                if (weatherDates[i].Location == location)
                {
                    return Ok("Запись с указанным городом имеется в нашем списке");
                }
            }
            return BadRequest("Запись с указанным городом не обнаружено!!!");
        }
    }
}
