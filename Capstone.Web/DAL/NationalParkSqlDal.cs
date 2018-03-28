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
            string SQL_GetAllParks = @"Select park.acreage, park.annualVisitorCount, park.climate, park.elevationInFeet, 
            park.entryFee, park.inspirationalQuote, park.inspirationalQuoteSource, park.milesOfTrail, park.numberOfAnimalSpecies, 
            park.numberOfCampsites, park.parkCode, park.parkDescription, park.parkName, park.state, park.yearFounded, 
            SUM(survey_result.surveyId) AS surveyCount from park FULL OUTER JOIN survey_result 
            on park.parkCode = survey_result.parkCode Group by park.acreage, park.annualVisitorCount, park.climate, 
            park.elevationInFeet, park.entryFee, park.inspirationalQuote, park.inspirationalQuoteSource, 
            park.milesOfTrail, park.numberOfAnimalSpecies, park.numberOfCampsites, park.parkCode, park.parkDescription, 
            park.parkName, park.state, park.yearFounded";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(SQL_GetAllParks, conn);
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
            throw new NotImplementedException();
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
                NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"])
            };
        }
    }
}