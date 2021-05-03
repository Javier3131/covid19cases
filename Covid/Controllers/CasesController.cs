using Service.Cases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;

namespace Web.Controllers
{
    public class CasesController : ApiController
    {
        [Dependency]
        public ICaseService CaseService { get; set; }

        [HttpGet]
        [ActionName("casestop10")]
        public IHttpActionResult CasesTop10()
        {
            try
            {
                var result = CaseService.GetRegionCasesTop10();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ActionName("casestop10byregion")]
        public IHttpActionResult CasesTop10ByRegion(string region_name)
        {
            try
            {
                var result = CaseService.GetCasesTop10ByRegion(region_name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
