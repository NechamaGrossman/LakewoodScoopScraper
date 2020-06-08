using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LakewoodScoop.Web.Scraping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LakewoodScoop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoopController : ControllerBase
    {
        [HttpGet]
        [Route("GetTheScoop")]
        public List<LakewoodScoopResult> GetTheScoop()
        {
            LakewoodScoopScraper scraper = new LakewoodScoopScraper();
            List<LakewoodScoopResult> result = scraper.GetAll();
            return result;
        }
    }
}