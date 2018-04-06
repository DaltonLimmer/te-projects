using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class NationalParkSqlDal : INationalParkDAL
    {
        private string connectionString;

        public NationalParkSqlDal(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<NationalPark> GetAllParks()
        {
            List<NationalPark> nationalParks = new List<NationalPark>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(_getAllParksSQLString, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    nationalParks.Add(MapRowToPark(reader));
                }
            }

            return nationalParks;
        }

        public NationalPark GetOnePark(string parkCode)
        {
            NationalPark onePark = new NationalPark();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(_singleParkSQLString, conn);
                cmd.Parameters.AddWithValue("@parkCode", parkCode);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    onePark = MapRowToPark(reader);
                }

            }
            return onePark;
        }

        public bool CheckForSurvey(SurveyModel survey)
        {
            bool surveyExists = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(_checkForSurveySQLString, conn);

                cmd.Parameters.AddWithValue("@parkName", survey.ParkName);
                cmd.Parameters.AddWithValue("@emailAddress", survey.Email);

                object result = cmd.ExecuteScalar();

                if(result != null)
                {
                    surveyExists = true;
                }

                return surveyExists;
            }
        }

        public bool AddSurvey(SurveyModel survey)
        {
            bool surveyPost = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(_addSurvey, conn);

                cmd.Parameters.AddWithValue("@parkName", survey.ParkName);
                cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                cmd.Parameters.AddWithValue("@state", survey.StateOfResidence);
                cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                if(cmd.ExecuteNonQuery() > 0)
                {
                    surveyPost = true;
                }
            }
            return surveyPost;
        }

        public List<SurveyPark> GetSurveyParks()
        {
            List<SurveyPark> surveyParks = new List<SurveyPark>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(_getSurveyParks, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    surveyParks.Add(MapRowToParkSurvey(reader));
                }
            }

            return surveyParks;
        }

        private NationalPark MapRowToPark(SqlDataReader reader)
        {
            return new NationalPark
            {
                ParkName = Convert.ToString(reader["parkName"]),
                ParkCode = Convert.ToString(reader["parkCode"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["acreage"]),
                Elevation = Convert.ToInt32(reader["elevationInFeet"]),
                MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]),
                Climate = Convert.ToString(reader["climate"]),
                YearFounded = Convert.ToInt32(reader["yearFounded"]),
                AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]),
                InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]),
                InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]),
                ParkDescription = Convert.ToString(reader["parkDescription"]),
                EntryFee = Convert.ToInt32(reader["entryFee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]),
            };
        }

    
        private SurveyPark MapRowToParkSurvey(SqlDataReader reader)
        {
            return new SurveyPark
            {
                ParkName = Convert.ToString(reader["parkName"]),
                TotalSurveys = Convert.ToInt32(reader["totalSurveys"]),
                ParkCode = Convert.ToString(reader["parkCode"])
            };
        }

        private WeatherReport MapRowToWeatherReport(SqlDataReader reader, string tempType)
        {
            if(tempType == null)
            {
                tempType = "fahrenheit";
            }
            return new WeatherReport
            {
                isFahrenheit = (tempType == "fahrenheit"),

                ParkCode = Convert.ToString(reader["parkCode"]),
                FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                high = Convert.ToInt32(reader["high"]),
                low = Convert.ToInt32(reader["low"]),
                Forecast = Convert.ToString(reader["forecast"])

            };
        }

        public List<WeatherReport> GetWeatherReports(string parkCode, string tempType)
        {
            List<WeatherReport> weatherReports = new List<WeatherReport>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(_getAllWeatherReportsSQLString, conn);
                cmd.Parameters.AddWithValue("@parkCode", parkCode);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    weatherReports.Add(MapRowToWeatherReport(reader, tempType));
                }
            }

            return weatherReports;
        }


        private string _addSurvey = "Insert into survey_result(parkCode, emailAddress, state, activityLevel) " +
            "VALUES((select park.parkCode from park where parkName = @parkName), @emailAddress, @state, @activityLevel)";

        private string _getSurveyParks = "select park.parkName, park.parkCode, COUNT(park.parkName) as totalSurveys from park " +
            "FULL OUTER JOIN survey_result on park.parkCode = survey_result.parkCode " +
            "WHERE surveyId IS NOT NULL " +
            "Group by park.parkName, park.parkCode " +
            "Order by totalSurveys DESC, park.parkName ASC";

        private string _singleParkSQLString = "Select park.acreage, park.annualVisitorCount, park.climate, " +
            "park.elevationInFeet, park.entryFee, park.inspirationalQuote, park.inspirationalQuoteSource," +
            " park.milesOfTrail, park.numberOfAnimalSpecies, park.numberOfCampsites, park.parkCode," +
            " park.parkDescription, park.parkName, park.state, park.yearFounded" +
            " from park" +
            " WHERE park.parkCode = @parkCode Group by park.acreage, park.annualVisitorCount, park.climate," +
            " park.elevationInFeet, park.entryFee, park.inspirationalQuote, park.inspirationalQuoteSource," +
            " park.milesOfTrail, park.numberOfAnimalSpecies, park.numberOfCampsites, park.parkCode, park.parkDescription," +
            " park.parkName, park.state, park.yearFounded";

        private string _getAllParksSQLString = "Select park.acreage, park.annualVisitorCount, park.climate, " +
            "park.elevationInFeet, park.entryFee, park.inspirationalQuote, park.inspirationalQuoteSource," +
            " park.milesOfTrail, park.numberOfAnimalSpecies, park.numberOfCampsites, park.parkCode," +
            " park.parkDescription, park.parkName, park.state, park.yearFounded, COUNT(survey_result.parkCode)" +
            " AS surveyCount from park FULL OUTER JOIN survey_result on park.parkCode = survey_result.parkCode" +
            " Group by park.acreage, park.annualVisitorCount, park.climate," +
            " park.elevationInFeet, park.entryFee, park.inspirationalQuote, park.inspirationalQuoteSource," +
            " park.milesOfTrail, park.numberOfAnimalSpecies, park.numberOfCampsites, park.parkCode, park.parkDescription," +
            " park.parkName, park.state, park.yearFounded";

        private string _getAllWeatherReportsSQLString = "Select * from weather where parkCode = @parkCode";

        private string _checkForSurveySQLString = "Select park.parkName, survey_result.emailAddress from park " +
            "JOIN survey_result on park.parkCode = survey_result.parkCode " +
            "WHERE park.parkName = @parkName AND survey_result.emailAddress = @emailAddress";
    }
}