using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        private INationalParkDAL _dal;

        public HomeController(INationalParkDAL dal)
        {
            _dal = dal;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<NationalPark> parks = _dal.GetAllParks();

            return View("ParkList", parks);
        }

        public ActionResult ParkList()
        {
            List<NationalPark> parks = _dal.GetAllParks();

            return View(parks);
        }


        public ActionResult Detail(string parkCode, string tempType)
        {
            if (parkCode == null)
            {
                parkCode = "ENP";
            }

            if (tempType == null)
            {
               tempType = Session["tempChoice"] as string;
            }

            Session["tempChoice"] = tempType;

            List<WeatherReport> weatherReports = _dal.GetWeatherReports(parkCode, tempType);
            NationalPark park = _dal.GetOnePark(parkCode);
            DetailModel model = new DetailModel
            {
                NationalPark = park,
                WeatherReports = weatherReports
            };

            return View("Detail", model);
        }

        public ActionResult Survey()
        {
            SurveyModel model = new SurveyModel();
            return View("Survey", model);
        }

        [HttpPost]
        public ActionResult FavoriteParks(SurveyModel model)
        {
            if(model.Email == null)
            {
                TempData["errorStringEmail"] = "You must enter an email address";
                return View("Survey", model);
            }
           
            if (Session["survey"] as string == model.ParkName)
            {
                TempData["errorString"] = "You cannot post more than one survey for this park";
                return RedirectToAction("Survey");
            }

            Session["survey"] = model.ParkName;

            _dal.AddSurvey(model);

            List<SurveyPark> surveyParks = _dal.GetSurveyParks();

            TempData["surveys"] = surveyParks;

            return RedirectToAction("FavoriteParks");
        }

        public ActionResult FavoriteParks()
        {
            List<SurveyPark> surveyParks = TempData["surveys"] as List<SurveyPark>;
            return View("FavoriteParks", surveyParks);
        }
    }
}