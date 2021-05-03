using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Web.Controllers;

namespace Web.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCasesTop10_ShouldReturn10Cases()
        {
            var testData = GetTestData();
            var controller = new CasesController();

            var result = controller.CasesTop10() as OkNegotiatedContentResult<List<Report>>;
            Assert.AreEqual(testData.Count, result.Content.Count);
        }

        private List<Report> GetTestData()
        {
            var testData = new List<Report>();

            testData.Add(new Report { date = "2021-05-01", confirmed = 4055, deaths = 86 });
            testData.Add(new Report { date = "2021-05-01", confirmed = 4051, deaths = 86 });
            testData.Add(new Report { date = "2021-05-01", confirmed = 4052, deaths = 86 });
            testData.Add(new Report { date = "2021-05-01", confirmed = 4053, deaths = 86 });
            testData.Add(new Report { date = "2021-05-01", confirmed = 4054, deaths = 86 });
            testData.Add(new Report { date = "2021-05-01", confirmed = 4056, deaths = 86 });
            testData.Add(new Report { date = "2021-05-01", confirmed = 4057, deaths = 86 });
            testData.Add(new Report { date = "2021-05-01", confirmed = 4058, deaths = 86 });
            testData.Add(new Report { date = "2021-05-01", confirmed = 4059, deaths = 86 });
            testData.Add(new Report { date = "2021-05-01", confirmed = 4060, deaths = 86 });

            return testData;
        }
    }
}
