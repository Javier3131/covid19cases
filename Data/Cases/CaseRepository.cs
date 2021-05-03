using Domain;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Cases
{
    public class CaseRepository : ICaseRepository
    {
        public List<Report> GetRegionCasesTop10()
        {
            try
            {
                var reports = new List<Report>();
                var response = Utility.API.Get("reports");
                if (response.IsSuccessStatusCode)
                {
                    JObject obj = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    JArray arr = (JArray)obj["data"];
                    var data = arr.ToObject<List<Report>>();

                    reports = data.OrderByDescending(x => x.confirmed).ThenByDescending(x => x.deaths).Take(10).ToList();
                }
                return reports;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Report> GetCasesTop10ByRegion(string regionName)
        {
            try
            {
                var reports = new List<Report>();
                var response = Utility.API.Get(string.Format("reports?region_name={0}", regionName));
                if (response.IsSuccessStatusCode)
                {
                    JObject obj = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    JArray arr = (JArray)obj["data"];
                    var data = arr.ToObject<List<Report>>();

                    reports = data.OrderByDescending(x => x.confirmed).ThenByDescending(x => x.deaths).Take(10).ToList();
                }
                return reports;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
