using System.Collections.Generic;

namespace Tommeplan
{
    public class Week
    {
        public Week(int v, List<string> list)
        {
            WeekNumber = v;
            Types = list;
        }

        public int WeekNumber { get; private set; }
        public IEnumerable<string> Types;
    }
}