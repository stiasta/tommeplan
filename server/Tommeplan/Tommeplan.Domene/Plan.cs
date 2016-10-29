using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tommeplan.Domene
{
    public class Plan
    {
        public Plan(params Week[] weeks) : this(weeks.ToList())
        {
        }

        public Plan(IEnumerable<Week> weeks)
        {
            _weeks = new List<Week>();
            _weeks.AddRange(weeks);
        }

        private List<Week> _weeks;
        public IEnumerable<Week> Weeks
        {
            get
            {
                if (_weeks == null)
                {
                    _weeks = new List<Week>();
                }

                return _weeks;
            }
        }

        public void SetMissingWeeks()
        {
            for (int i = 1; i <= 52; i++)
            {
                if (!_weeks.Any(x => x.WeekNumber == i))
                {
                    _weeks.Add(new Week(i));
                }
            }

            _weeks = _weeks.OrderBy(x => x.WeekNumber).ToList();
        }

        [Obsolete]
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

        [Obsolete]
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

        [Obsolete]
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

        public static Plan FromHRA(string road, string html)
        {
            if (string.IsNullOrWhiteSpace(road))
            {
                throw new Exception("Mangler vei for uthenting fra HRA.");
            }
            road = road.ToLower();
            var document = new HtmlDocument();
            document.LoadHtml(html);
            return
                GetPlanFromHRARoadNode(
                    document
                        .DocumentNode
                        .Descendants("table")
                        .First()
                        .Descendants("tr")
                        .Skip(1)
                        .First(x => x.InnerText.ToLower().Contains(road)));
        }

        private static Plan GetPlanFromHRARoadNode(HtmlNode htmlNode)
        {
            var node = htmlNode.PreviousSibling;
            while (node != null)
            {
                if (node.InnerText.ToLower().Contains("restavfall"))
                {
                    break;
                }

                node = node.PreviousSibling;
            }

            var plan = new Plan(
                node
                    .Descendants("td")
                    .ToArray()[1]
                    .InnerText
                    .Split(':')[1]
                    .Split(',')
                    .Select(x => new Week(int.Parse(x.Replace("&nbsp;", "")), "Restavfall", "Matavfall")));

            node
                .NextSibling
                .NextSibling
                .Descendants("td")
                .ToArray()[1]
                .InnerText
                .Split(':')[1]
                .Split(',')
                .ToList()
                .ForEach(
                    number => plan.AddTypes(int.Parse(number.Replace("&nbsp;", "")), "Papir", "Plast"));

            plan.SetMissingWeeks();
            return plan;
        }

        public void AddType(int weeknumber, string type)
        {
            Weeks
                .Where(week => week.WeekNumber == weeknumber)
                .ToList()
                .ForEach(week => week.AddType(type));
        }

        public void AddTypes(int weeknumber, params string[] types)
        {
            types
                .ToList()
                .ForEach(x => AddType(weeknumber, x));
        }
    }
}