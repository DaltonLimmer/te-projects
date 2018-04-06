using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Tests.DAL
{
    class DALTests
    {
        [TestClass()]
        public class NationalParkSqlDalTests
        {
            private TransactionScope tran;
            private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=park;Integrated Security = True";
            private int numberOfParks = 0;
            private int newPark = 0;

            [TestInitialize]
            public void Initialize()
            {
                tran = new TransactionScope();


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd;
                    conn.Open();

                    cmd = new SqlCommand("Insert Into park(parkCode, parkName, state, acreage, elevationInFeet, " +
                    "milesOfTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount, inspirationalQuote," +
                    " inspirationalQuoteSource, parkDescription, entryFee, numberOfAnimalSpecies) Values('abc', 'def', 'Ohio'," +
                    " 12345, 40, 450, 4, 'mild', 1900, 12334556, 'parks are cool', 'me', 'sweet park', 5, 100); Select" +
                    " entryFee FROM park Where parkCode='abc'", conn);
                    newPark = (int)cmd.ExecuteScalar();

                    cmd = new SqlCommand("Select COUNT(*) From park", conn);
                    numberOfParks = (int)cmd.ExecuteScalar();

                }
            }

            [TestMethod()]
            public void PostOneSurvey()
            {
                NationalParkSqlDal nationalParkDAL = new NationalParkSqlDal(connectionString);

                SurveyModel surveyTest = new SurveyModel
                {
                    Email = "test@test.com",
                    ActivityLevel = "sedentary",
                    ParkName = "Grand Teton National Park",
                    StateOfResidence = "Ohio"
                };

                bool testPass = nationalParkDAL.AddSurvey(surveyTest);

                Assert.AreEqual(true, testPass);
            }


            [TestMethod()]
            public void GetAllParksTest()
            {
                NationalParkSqlDal nationalParkDAL = new NationalParkSqlDal(connectionString);

                List<NationalPark> nationalParks = nationalParkDAL.GetAllParks();

                Assert.AreEqual(11, nationalParks.Count);

            }

            [TestMethod()]
            public void GetOneParkTest()
            {
                NationalParkSqlDal nationalParkDAL = new NationalParkSqlDal(connectionString);

                List<NationalPark> nationalParks = new List<NationalPark>();

                nationalParks.Add(nationalParkDAL.GetOnePark("abc"));

                Assert.AreEqual(1, nationalParks.Count);

            }

            [TestCleanup]
            public void Cleanup()
            {
                tran.Dispose();
            }
        }

    }
}
