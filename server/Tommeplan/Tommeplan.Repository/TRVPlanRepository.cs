using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Tommeplan.Domene;

namespace Tommeplan.Repository
{
    public class TRVPlanRepository : IPlanRepository
    {
        public async Task<IEnumerable<Address>> GetAddresses(string text, string city)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new List<Address>();
            }

            using (var client = GetHttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("action", "finn_tommeplan_adresser"),
                    new KeyValuePair<string, string>("adr", text),
                    new KeyValuePair<string, string>("is_container", "0")
                });

                var result =
                    await client
                        .PostAsync(
                            "http://trv.no/wp-content/themes/sircon/aj/aj.php",
                            content);

                // avoiding robot redirect
                if (result.RequestMessage.RequestUri.Authority.ToLower().Equals("robots.sircon.net"))
                {
                    var key = HttpUtility.ParseQueryString(result.RequestMessage.RequestUri.Query).Get("key");
                    result =
                        await client
                            .PostAsync(
                                "http://trv.no/wp-content/themes/sircon/aj/aj.php?unlockkey=" + key,
                                content);
                }

                var html = await result.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(html))
                {
                    throw new HttpException((int)HttpStatusCode.NotFound, "Street not found");
                }
                
                return MapToAddress(html, city);
            }
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

        private List<Address> MapToAddress(string html, string city)
        {
            try
            {
                var document = new HtmlDocument();
                document.LoadHtml(html);
                return 
                    document.DocumentNode
                        .Descendants()
                        .Where(x =>
                            x.HasAttributes &&
                            x.Attributes["data-adrid"] != null)
                        .Select(
                            x =>
                                new Address(
                                    x.InnerText, 
                                    city,
                                    int.Parse(x.Attributes["data-adrid"].Value)))
                        .ToList();
            }
            catch (Exception)
            {
                return new List<Address>();
            }
        }
        
        public Plan GetPlan(Address address)
        {
            if(address == null)
            {
                throw new ArgumentNullException("Need address to find plan");
            }

            throw new NotImplementedException();
        }
    }
}
