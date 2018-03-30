using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class WeatherReport
    {
        public bool isFahrenheit = true;
        public int low;
        public int high;

        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public string Forecast { get; set; }

        public string Low
        {
            get
            {

                string output = low.ToString() + "F";
                if(isFahrenheit == false)
                {
                    output = (((low - 32) * 5) / 9).ToString() + "C"; 
                }
                return output;
            }
        }

        public string High
        {
            get
            {
                string output = high.ToString() + "F";
                if (isFahrenheit == false)
                {
                    output = (((high - 32) * 5) / 9).ToString() + "C";
                }
                return output;
            }
        }

    }
}