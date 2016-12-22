using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Tommeplan.Domene
{
    public class Week
    {
        public Week(int weeknumber, IEnumerable<string> types)
        {
            WeekNumber = weeknumber;
            _types = new List<string>();
            _types.AddRange(types);

            if (_types.Count == 0)
            {
                _types.Add("Tømmefri uke");
            }
        }

        public Week(int weeknumber, params string[] types) : this(weeknumber, types.ToList())
        {
        }

        public Week(int weeknumber, int year, IEnumerable<string> types)
            : this(weeknumber, types)
        {
            Year = year;
        }

        public Week(int weeknumber, int year, params string[] types)
            : this(weeknumber, year, types.ToList())
        {
        }

        //public Week(DateTime from, DateTime to, IEnumerable<string> types)
        //    : this(GetIso8601WeekOfYear(from), types)
        //{
        //    Year = from.Year > to.Year ? from.Year : to.Year;
        //    From = from;
        //    To = to;
        //}

        public int WeekNumber { get; private set; }

        private List<string> _types;
        public IEnumerable<string> Types
        {
            get
            {
                if (_types == null)
                {
                    _types = new List<string>();
                }

                return _types;
            }
        }

        public int Year { get; private set; }
        //public DateTime To { get; private set; }
        //public DateTime From { get; private set; }

        public void AddType(string type)
        {
            if (!_types.Any(x => x.ToLower().Equals(type)))
            {
                _types.Add(type);
            }
        }

        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        private static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}