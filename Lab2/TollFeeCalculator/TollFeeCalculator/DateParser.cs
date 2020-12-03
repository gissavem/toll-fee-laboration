using System;
using System.Collections.Generic;

namespace TollFeeCalculatorApp
{
    public class DateParser
    {
        public List<TollRecord> CreateTollRecordsFromString(string datesString)
        {
            var dateStrings = datesString.Split(", ");
            var records = new List<TollRecord>();
            foreach (var dateString in dateStrings)
            {
                var date = TryToParseDateFromString(dateString);
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
