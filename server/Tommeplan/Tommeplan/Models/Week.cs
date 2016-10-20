using System;
using System.Linq;
using System.Collections.Generic;

namespace Tommeplan
{
    public class Week
    {
        public Week(int weeknumber, IEnumerable<string> types)
        {
            WeekNumber = weeknumber;
            _types = new List<string>();
            _types.AddRange(types);

            if(_types.Count == 0)
            {
                _types.Add("Tømmefri uke");
            }
        }

        public Week(int weeknumber, params string[] types) : this(weeknumber, types.ToList())
        {
        }

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

        public void AddType(string type)
        {
            if (!_types.Any(x => x.ToLower().Equals(type)))
            {
                _types.Add(type);
            }
        }
    }
}