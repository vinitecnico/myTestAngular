using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using mvcUploadFile.Models;
using Microsoft.AspNetCore.Mvc;

namespace myTestAngular.Controllers {
    [Route ("api/[controller]")]
    public class SampleDataController : Controller {
        private static string[] Summaries = new [] {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        [HttpGet ("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts () {
            var rng = new Random ();
            return Enumerable.Range (1, 5).Select (index => new WeatherForecast {
                DateFormatted = DateTime.Now.AddDays (index).ToString ("d"),
                    TemperatureC = rng.Next (-20, 55),
                    Summary = Summaries[rng.Next (Summaries.Length)]
            });
        }

        [HttpPost ("[action]"), DisableRequestSizeLimit]
        public async Task<IEnumerable<CustomerModel>> UploadFile () {
            var file = Request.Form.Files[0];

            List<CustomerModel> customers = new List<CustomerModel> ();
            using (var reader = new StreamReader (file.OpenReadStream ())) {
                while (reader.Peek () >= 0) {
                    var result = await reader.ReadLineAsync ();
                    customers.Add (new CustomerModel {
                        Id = Convert.ToInt32 (result.Split (';') [0]),
                            Name = result.Split (';') [1]
                    });
                }
            }

            return customers;
        }

        public class WeatherForecast {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF {
                get {
                    return 32 + (int) (TemperatureC / 0.5556);
                }
            }
        }
    }
}