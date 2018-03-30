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
            return View("Index");
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
                parkCode = (string)TempData["parkCode"];
            }

            List<WeatherReport> weatherReports = _dal.GetWeatherReports(parkCode, tempType);
            NationalPark park = _dal.GetOnePark(parkCode);
            DetailModel model = new DetailModel
            {
                NationalPark = park,
                WeatherReports = weatherReports
            };

            return View("Detail", model);
        }

    }
}