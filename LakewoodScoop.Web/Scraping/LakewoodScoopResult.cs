using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LakewoodScoop.Web.Scraping
{
    public class LakewoodScoopResult
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string NumberOfComments { get; set; }
        public string Blurb { get; set; }
        public string Url { get; set; }
    }
}
