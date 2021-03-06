using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sh.Labs.BlazorApp.Data
{
    public class RegistrationService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<List<WeatherForecast>> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToList());
        }


        public Task Submit(RegistrationData data)
        {
            return Task.Run(()=>
            {
            });
        }
    }
}
