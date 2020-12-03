using System;
using System.Collections.Generic;
using System.Linq;

namespace TollFeeCalculatorApp
{
    public class DateParser
    {
        public List<TollRecord> CreateTollRecordsForOneDayFromString(string datesString)
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
            var recordsForSingleDay = records.Where(r => r.TimeStamp.Date == records[0].TimeStamp.Date).ToList();
            return recordsForSingleDay;
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
