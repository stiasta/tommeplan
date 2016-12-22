using HtmlAgilityPack;
using Newtonsoft.Json;
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
        public async Task<IEnumerable<Address>> GetAddressesAsync(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                return new List<Address>();
            }

            using (var client = GetHttpClient())
            {
                var result =
                    await client
                        .GetAsync("http://trv.no/wp-json/wasteplan/v1/BINS/?s=" + address);

                // avoiding robot redirect
                if (result.RequestMessage.RequestUri.Authority.ToLower().Equals("robots.sircon.net"))
                {
                    var key = HttpUtility.ParseQueryString(result.RequestMessage.RequestUri.Query).Get("key");
                    result =
                        await client
                            .GetAsync(
                                "http://trv.no/wp-json/wasteplan/v1/BINS/?s=" + address +
                                "&unlockkey=" + key);
                }

                var json = await result.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(json))
                {
                    throw new HttpException((int)HttpStatusCode.NotFound, "Street not found");
                }

                return MapToAddress(json, "Trondheim");
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

        private async Task<IEnumerable<Address>> GetForContainers(string address)
        {
            throw new NotImplementedException();
        }

        private List<Address> MapToAddress(string html, string city)
        {
            try
            {
                return
                    JsonConvert
                        .DeserializeObject<List<AddressTRVDTO>>(html)
                        .Select(x => new Address(x.Name, city, x.Id))
                        .ToList();
            }
            catch (Exception)
            {
                return new List<Address>();
            }
        }

        public Plan GetPlan(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException("Must have address to find the plan.");
            }

            using (var client = GetHttpClient())
            {
                var result =
                    client
                        .GetAsync("http://trv.no/plan/" + address.Id).Result;

                // avoiding robot redirect
                if (result.RequestMessage.RequestUri.Authority.ToLower().Equals("robots.sircon.net"))
                {
                    var key = HttpUtility.ParseQueryString(result.RequestMessage.RequestUri.Query).Get("key");
                    result =
                        client
                            .GetAsync(
                                "http://trv.no/plan/" + address.Id +
                                "&unlockkey=" + key).Result;
                }

                var html = result.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrWhiteSpace(html))
                {
                    throw new HttpException((int)HttpStatusCode.NotFound, "Street not found");
                }

                return new TRVMapper(html).ToPlan();
            }
        }

        public IEnumerable<Address> GetAddresses(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
            {
                return new List<Address>();
            }

            using (var client = GetHttpClient())
            {
                var result =
                    client
                        .GetAsync("http://trv.no/wp-json/wasteplan/v1/BINS/?s=" + address).Result;

                // avoiding robot redirect
                if (result.RequestMessage.RequestUri.Authority.ToLower().Equals("robots.sircon.net"))
                {
                    var key = HttpUtility.ParseQueryString(result.RequestMessage.RequestUri.Query).Get("key");
                    result =
                        client
                            .GetAsync(
                                "http://trv.no/wp-json/wasteplan/v1/BINS/?s=" + address +
                                "&unlockkey=" + key).Result;
                }

                var json = result.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrWhiteSpace(json))
                {
                    throw new HttpException((int)HttpStatusCode.NotFound, "Street not found");
                }

                return MapToAddress(json, "Trondheim");
            }
        }

        internal class AddressTRVDTO
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public string Type { get; set; }
        }

        internal class TRVMapper
        {
            private readonly HtmlDocument _document;

            public TRVMapper(string html)
            {
                _document = new HtmlAgilityPack.HtmlDocument();
                _document.LoadHtml(html);
            }

            internal Plan ToPlan()
            {
                return 
                    new Plan(
                        LagUker(
                            HentAlleUker()));
            }

            private IEnumerable<Week> LagUker(HtmlNodeCollection uker)
            {
                return
                    uker
                        .Select(x =>
                            new Week(HentUke(x), HentÅr(x), HentTypes(x)));
            }

            private int HentUke(HtmlNode node)
            {
                var weeknumber = node.SelectSingleNode("./td[contains(@class, 'week')]").InnerText;
                return int.Parse(weeknumber);
            }
            
            private int HentÅr(HtmlNode node)
            {
                var year = node.Attributes.First(x => x.Value.ToLower().StartsWith("year")).Value.Split('-')[1];
                return int.Parse(year.Substring(0, 4));
            }

            private IEnumerable<string> HentTypes(HtmlNode node)
            {
                return
                    node
                        .SelectNodes("./td[contains(@class, 'wastetype')]")
                        .Select(x => x.InnerText);
            }

            private HtmlNodeCollection HentAlleUker()
            {
                return 
                    _document
                        .DocumentNode
                        .SelectNodes("//*[contains(@class, 'year-')]");
            }
        }
    }
}
