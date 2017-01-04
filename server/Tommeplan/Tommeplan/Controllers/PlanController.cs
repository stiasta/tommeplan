using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Tommeplan.Application;
using Tommeplan.Domene;

namespace Tommeplan.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PlanController : ApiController
    {
        private readonly PlanService _service;

        public PlanController(PlanService service)
        {
            _service = service;
        }

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

        [Route("~/api/plan/{city}/{id}")]
        public Plan GetWithId(string city, string id)
        {
            return _service.GetPlan(new Address(city, id));
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
            return _service.GetPlan(new Address("Trondheim", roadId.ToString()));
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
            var addresses = _service.GetAddresses(road);
            if (!addresses.Any() || addresses.Count() != 1) return -1;
            return int.Parse(addresses.First().Id);
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