using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculatorApp
{
    public class DateParser
    {
        public List<DateTime> ParseDatesFromString(string datesString)
        {
            string[] dateStrings = datesString.Split(", ");
            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < dateStrings.Length; i++)
            {
                var date = TryToParseDateFromString(dateStrings[i]);
                if (date == DateTime.MinValue)
                {
                    continue;
                }
                dates.Add(date);
            }
            return dates;
        }
        private DateTime TryToParseDateFromString(string dateString)
        {
            try
            {
                return DateTime.Parse(dateString);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }
    }
}
