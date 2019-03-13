using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curs27Homework
{
    public class MyCalendar
    {
        public List<KeyValuePair<int, int>> Booked = new List<KeyValuePair<int, int>>();

        public bool Book(int start, int end)
        {
            var booking = new KeyValuePair<int, int>(start, end);

            while (CountStartOverlaps(start) < 2 && CountEndOverlaps(end) < 2)
            {
                Booked.Add(booking);
                return true;
            }
            return false;
        }

        public int CountStartOverlaps(int start)
        {
            int counter = 0;
            foreach (var alreadyBooked in Booked)
            {
                if (start > alreadyBooked.Key && start < alreadyBooked.Value)
                    counter++;
            }
            return counter;
        }

        public int CountEndOverlaps(int end)
        {
            int counter = 0;
            foreach (var alreadyBooked in Booked)
            {
                if (end > alreadyBooked.Key && end < alreadyBooked.Value)
                    counter++;
            }
            return counter;
        }
    }
}
