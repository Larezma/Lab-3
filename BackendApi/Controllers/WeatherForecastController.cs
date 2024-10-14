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
            new WeatherDate() {Id=1,Date="21.01.2024",Degree=10,Location="���������" },
            new WeatherDate() {Id=23,Date="22.01.2024",Degree=20,Location="�����" },
            new WeatherDate() {Id=24,Date="23.01.2024",Degree=15,Location="����" },
            new WeatherDate() {Id=25,Date="24.01.2024",Degree=0,Location="��� ��" },
            new WeatherDate() {Id=30,Date="25.01.2024",Degree=3,Location="������" },
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
                    return BadRequest("���� id �� ����� ���� ������ ����!");
                }
                if (weatherDates[i].Id == id)
                {
                    return Ok(weatherDates[i]);
                }
            }
            return BadRequest("���� ����� ������!");
        }

        [HttpPost]
        public IActionResult Add(WeatherDate date)
        {
            for (int i = 0; i < weatherDates.Count; i++)
            {
                if (weatherDates[i].Id < 0)
                {
                    return BadRequest("���� id �� ����� ���� ������ ����!");
                }
                if (weatherDates[i].Id == date.Id)
                {
                    return BadRequest("����� ������ ��� �����������!");
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
                    return BadRequest("���� id �� ����� ���� ������ ����!");
                }
                if (weatherDates[i].Id == date.Id)
                {
                    weatherDates[i] = date;
                    return Ok();
                }
            }
            return BadRequest("���� ����� ������!");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            for (int i = 0; i < weatherDates.Count; i++)
            {
                if (weatherDates[i].Id < 0)
                {
                    return BadRequest("���� id �� ����� ���� ������ ����!");
                }
                if (weatherDates[i].Id == id)
                {
                    weatherDates.RemoveAt(i);
                    return Ok();
                }
            }
            return BadRequest("���� ����� ������!");
        }

        [HttpGet("find-by-city")]
        public IActionResult GetLocationn(string location)
        {
            for (int i = 0; i < weatherDates.Count; i++)
            {
                if (weatherDates[i].Location == location)
                {
                    return Ok("������ � ��������� ������� ������� � ����� ������");
                }
            }
            return BadRequest("������ � ��������� ������� �� ����������!!!");
        }
    }
}
