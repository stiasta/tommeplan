using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Tommeplan.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PlanController : ApiController
    {
        public Plan Get(string city, string road)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                // thats fine. defaulting to trondheim for the heck of it.
                city = "trondheim";
            }

            if (string.IsNullOrWhiteSpace(road))
            {
                throw new HttpException((int)HttpStatusCode.NotFound, "Street not found");
            }

            road = road.Trim('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ');

            if (city.ToLower().Equals("jevnaker") || 
                (road.Split(';').Length == 2))
            {
                var split = road.Split(';');
                if (split[1].ToLower().Trim().Equals("jevnaker"))
                {
                    road = split[0].Trim();
                    return GetPlanJevnaker(road);
                }
            }
            
            var id = GetRoadId(road);
            if (id == -1)
            {
                throw new HttpException((int)HttpStatusCode.NotFound, "Street not found");
            }
            
            return GetPlan(id, road);
        }

        private Plan GetPlanJevnaker(string road)
        {
            using (var client = new HttpClient())
            {
                var html = client.GetStringAsync("http://www.hra.no/index.php/tommeruter/tommeruter-for-jevnaker").Result;
                return Plan.FromHRA(road, html);
            }
        }

        private FormUrlEncodedContent GetPostContentForPlan(string road, int id)
        {
            return new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("action", "get_tommeplan_year"),
                new KeyValuePair<string, string>("target_adress", road),
                new KeyValuePair<string, string>("is_container", "0"),
                new KeyValuePair<string, string>("id", id.ToString())
            });
        }

        private Plan GetPlan(int roadId, string road)
        {
            var client = GetHttpClient();
            var result = 
                client
                    .GetAsync(
                        string.Format(
                            "http://trv.no/plan/{0}",
                            roadId))
                    .Result;
            // avoiding robot redirect
            if (result.RequestMessage.RequestUri.Authority.ToLower().Equals("robots.sircon.net"))
            {
                client.Dispose();
                client = GetHttpClient();
                var key = HttpUtility.ParseQueryString(result.RequestMessage.RequestUri.Query).Get("key");
                result = 
                    client
                        .PostAsync(
                            "http://trv.no/wp-content/themes/sircon/aj/aj.php?unlockkey=" + key,
                            GetPostContentForPlan(road, roadId))
                        .Result;
            }

            var html = result.Content.ReadAsStringAsync().Result;
            if (string.IsNullOrWhiteSpace(html))
            {
                throw new HttpException((int)HttpStatusCode.NotFound, "Street not found");
            }

            client.Dispose();
            return Plan.FromTRV(html);
        }

        private FormUrlEncodedContent GetPostRoadIdContent(string road)
        {
            return new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("action", "finn_tommeplan_adresser"),
                new KeyValuePair<string, string>("adr", road),
                new KeyValuePair<string, string>("is_container", "0")
            });
        }

        private int GetRoadId(string road)
        {
            var client = GetHttpClient();
            var result =
                client
                    .GetAsync(
                        string.Format(
                            "http://trv.no/wp-json/wasteplan/v1/BINS/?s={0}",
                            road))
                    .Result;
            // avoiding robot redirect
            if (result.RequestMessage.RequestUri.Authority.ToLower().Equals("robots.sircon.net"))
            {
                client.Dispose();
                client = GetHttpClient();
                var key = HttpUtility.ParseQueryString(result.RequestMessage.RequestUri.Query).Get("key");
                result = 
                    client
                        .PostAsync(
                            "http://trv.no/wp-content/themes/sircon/aj/aj.php?unlockkey=" + key, 
                            GetPostRoadIdContent(road))
                        .Result;
            }

            var html = result.Content.ReadAsStringAsync().Result;
            if (string.IsNullOrWhiteSpace(html))
            {
                throw new HttpException((int)HttpStatusCode.NotFound, "Street not found");
            }

            client.Dispose();
            return Plan.ParseStreetIdFromTRV(html);
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Host = "trv.no";
            client.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident / 6.0)");

            return client;
        }
    }
}