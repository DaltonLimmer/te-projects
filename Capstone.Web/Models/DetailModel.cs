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

    }
}