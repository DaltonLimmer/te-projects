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
                message += "Pack snowshoes!";
            }
            if(weatherReport.Forecast == "rain")
            {
                message = "Pack rain gear and waterproof shoes!";
            }
            if (weatherReport.Forecast == "thunderstorms")
            {
                message = "Seek shelter! Avoid hiking on exposed ridges!";
            }
            if (weatherReport.Forecast == "sun")
            {
                message = "Pack sunblock!";
            }
            if (weatherReport.high > 75)
            {
                message = "Bring extra water!";
            }
            if ((weatherReport.high - weatherReport.low) > 20)
            {
                message = "Wear breathable layers!";
            }
            if (weatherReport.low < 20)
            {
                message = "Extended time spent in frigid temperatures is not advised!";
            }

            return message;
        }

    }
}