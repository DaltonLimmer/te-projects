using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class DetailModel
    {
        public NationalPark NationalPark { get; set; }
        public List<WeatherReport> WeatherReports { get; set; }


        public string AdvisoryMessage(WeatherReport weatherReport)
        {
            string message = "";

            if(weatherReport.Forecast == "snow")
            {
                message = "Pack snowshoes!";
            }
            else if(weatherReport.Forecast == "rain")
            {
                message = "Pack rain gear and waterproof shoes!";
            }
            else if (weatherReport.Forecast == "thunderstorms")
            {
                message = "Seek shelter! Avoid hiking on exposed ridges!";
            }
            else if (weatherReport.Forecast == "sun")
            {
                message = "Pack sunblock!";
            }
            else if (weatherReport.High > 75)
            {
                message = "Bring extra water!";
            }
            else if ((weatherReport.High - weatherReport.Low) > 20)
            {
                message = "Wear breathable layers!";
            }
            else if (weatherReport.Low < 20)
            {
                message = "Extended time spent in frigid temperatures is not advised!";
            }

            return message;
        }

    }
}