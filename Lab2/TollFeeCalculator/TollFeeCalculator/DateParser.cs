using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculatorApp
{
    public class DateParser
    {
        public List<TollRecord> CreateTollRecordsFromString(string datesString)
        {
            string[] dateStrings = datesString.Split(", ");
            List<TollRecord> records = new List<TollRecord>();
            for (int i = 0; i < dateStrings.Length; i++)
            {
                var date = TryToParseDateFromString(dateStrings[i]);
                if (date == DateTime.MinValue)
                {
                    continue;
                }
                records.Add(new TollRecord(date));
            }
            return records;
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

        public double GetTimeDelta(DateTime firstDateTime, DateTime secondDateTime)
        {
            var timeSpan = secondDateTime - firstDateTime;
            return timeSpan.TotalMinutes;
        }
    }
}
