using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tommeplan
{
    public class Plan
    {
        public Plan(params Week[] weeks)
        {
            Weeks = weeks;
        }

        public IEnumerable<Week> Weeks { get; private set; }

        public static Plan FromTRV(string html)
        {
            var document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            return new Plan(
                document
                    .DocumentNode
                    .SelectNodes("//*[contains(@class, 'tomme-week')]")
                    .Where(x =>
                        x.HasAttributes &&
                        x.Attributes["class"] != null &&
                        x.Attributes["class"].Value.ToLower().Equals("tomme-week"))
                    .Select(x => new Week(GetWeekNumber(x), GetGarbageTypes(x)))
                    .ToArray());
        }

        private static List<string> GetGarbageTypes(HtmlNode node)
        {
            return node
                .Descendants()
                .Where(x =>
                    x.HasAttributes &&
                    x.Attributes["class"] != null &&
                    x.Attributes["class"].Value.ToLower().Equals("tomming-name"))
                .Select(x => x.InnerText)
                .ToList();
        }

        private static int GetWeekNumber(HtmlNode node)
        {
            var numberElement =
                node
                    .Descendants()
                    .First(x =>
                        x.HasAttributes &&
                        x.Attributes["class"] != null &&
                        x.Attributes["class"].Value.ToLower().Equals("tomme-week-title"));
            return int.Parse(
                string.Join(
                    string.Empty,
                    numberElement.InnerText[4],
                    numberElement.InnerText[5]));
        }

        public static int ParseStreetIdFromTRV(string html)
        {
            try
            {
                var document = new HtmlDocument();
                document.LoadHtml(html);
                return int.Parse(
                    document.DocumentNode
                        .Descendants()
                        .First(x =>
                            x.HasAttributes &&
                            x.Attributes["data-adrid"] != null)
                        .Attributes["data-adrid"]
                        .Value);
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}