using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class NationalPark
    {
        public string ParkName { get; set; }
        public string ParkCode { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int Elevation { get; set; }
        public double MilesOfTrail { get; set; }
        public int NumberOfCampsites { get; set; }
        public string Climate { get; set;}
        public int YearFounded { get; set; }
        public int AnnualVisitorCount { get; set; }
        public string InspirationalQuote { get; set; }
        public string InspirationalQuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public int EntryFee { get; set; }
        public int NumberOfAnimalSpecies { get; set; }
        public List<int> FiveDayForecastLow { get; set; }
        public List<int> FiveDayForecastHigh { get; set; }
        public List<string> ForecastDescription { get; set; }
        public int SurveyCount { get; set; }
    }
}