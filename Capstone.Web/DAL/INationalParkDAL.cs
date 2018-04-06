using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public interface INationalParkDAL
    {
        List<NationalPark> GetAllParks();

        NationalPark GetOnePark(string parkCode);

        List<WeatherReport> GetWeatherReports(string parkCode, string tempType);

        bool AddSurvey(SurveyModel model);

        List<SurveyPark> GetSurveyParks();

        bool CheckForSurvey(SurveyModel survey);
    }
}