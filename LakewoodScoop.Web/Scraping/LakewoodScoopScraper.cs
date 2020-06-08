using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace LakewoodScoop.Web.Scraping
{
    public class LakewoodScoopScraper
    {

        public List<LakewoodScoopResult> GetAll()
        {
            var result = new List<LakewoodScoopResult>();
            var html = GetScoopHtml();
            var parser = new HtmlParser();
            IHtmlDocument htmlDocument = parser.ParseDocument(html);
            var divs = htmlDocument.QuerySelectorAll("div .post");
            foreach (var div in divs)
            {
                var Post = ParseResult(div);
                if (Post != null)
                {
                    result.Add(Post);
                }
            }

            return result;

        }
        public static LakewoodScoopResult ParseResult(IElement div)
        {
            var titleSpan = div.QuerySelector("h2 a");
            var title = titleSpan.TextContent;
            if (title == null)
            {
                return null;
            }

            var imageSpan = div.QuerySelector("p a");
            var image = imageSpan.Attributes["href"].Value;
            if (image == null)
            {
                return null;
            }

            var titleurl = titleSpan.Attributes["href"].Value;
            if (titleurl == null)
            {
                return null;
            }

            var comments = div.QuerySelector("div .backtotop");
            var commentCount = comments.TextContent;
            if (commentCount == null)
            {
                commentCount = "0";
            }

            var blurb = div.QuerySelector("p");
            var blurbText = blurb.TextContent;
            if (commentCount == null)
            {
                return null;
            }

            var lakewoodScoopResult = new LakewoodScoopResult
            {
                NumberOfComments = commentCount,
                Title = title, 
                Image = image, 
                Url = titleurl, 
                Blurb= blurbText
            };

            return lakewoodScoopResult;
        }

        static string GetScoopHtml()
        {
                var client = new HttpClient();
                return client.GetStringAsync($"https://www.thelakewoodscoop.com/").Result;
        }
    }
}
