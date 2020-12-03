using System;
using System.Collections.Generic;
using System.Linq;

namespace TollFeeCalculatorApp
{
    public class TollFeeCalculator
    {
        private const int MAX_FEE = 60;
        private const int ONE_HOUR = 60;
        private readonly FileReader _fileReader;
        private readonly DateParser _dateParser;
        private readonly ConsoleWriter _consoleWriter;
        public TollFeeCalculator()
        {
           _fileReader = new FileReader();
           _dateParser = new DateParser();
           _consoleWriter = new ConsoleWriter();
        }
        public void CalculateFeeFromRecordsInFile(string filePath)
        {
            var fileContent = _fileReader.ReadFileToString(filePath);
            var records = _dateParser.CreateTollRecordsForOneDayFromString(fileContent);
            var populatedRecords = PopulateRecordsWithFees(records);
            var filteredRecords = RemoveFreeRecords(populatedRecords);
            var totalFee = CalculateTotalFee(filteredRecords);
            _consoleWriter.PrintTotalFee(totalFee);
        }
        public List<TollRecord> RemoveFreeRecords(List<TollRecord> records) => records.Where(record => record.HasFee).ToList();
        public int GetHighestFeeInInterval(List<TollRecord> records) => records.Select(record => record.Fee).Max();
        public int CalculateTotalFee(List<TollRecord> records) 
        {
            var totalFee = 0;
            var initialRecord = records[0];
            var currentInterval = new List<TollRecord>();
            foreach (var record in records)
            {
                var timeDelta = _dateParser.GetTimeDelta(initialRecord.TimeStamp, record.TimeStamp);
                if(timeDelta < ONE_HOUR)
                {
                    currentInterval.Add(record);
                }
                else 
                {
                    totalFee += GetHighestFeeInInterval(currentInterval);
                    initialRecord = record;
                    ResetInterval(currentInterval, record);
                }
            }
            totalFee += GetHighestFeeInInterval(currentInterval);
            return Math.Min(totalFee, MAX_FEE);
        }
        public List<TollRecord> PopulateRecordsWithFees(List<TollRecord> records)
        {
            foreach (var record in records)
            {
                record.Fee = GetFee(record.TimeStamp);
            }
            return records;
        }
        public int GetFee(DateTime timeStamp)
        {
            var hour = timeStamp.Hour;
            var minute = timeStamp.Minute;
            if (IsFreeDate(timeStamp)) 
                return 0;
            if (DoesCostEight(hour, minute))
                return 8;
            else if (DoesCostThirteen(hour, minute))
                return 13;
            else if (DoesCostEighteen(hour, minute))
                return 18;
            else 
                return 0;
        }
        private bool DoesCostEight(int hour, int minute)
        {
            switch (hour)
            {
                case 6 when minute <= 29:
                case 8 when minute >= 30:
                case >= 9 when hour <= 14:
                case 18 when minute <= 29:
                    return true;
                default:
                    return false;
            }
        }
        private bool DoesCostThirteen(int hour, int minute)
        {
            switch (hour)
            {
                case 6 when minute >= 30:
                case 8 when minute <= 29:
                case 15 when minute <= 29:
                case 17:
                    return true;
                default:
                    return false;
            }
        }
        private bool DoesCostEighteen(int hour, int minute)
        {
            switch (hour)
            {
                case 7:
                case 15 when minute >= 30:
                case 16:
                    return true;
                default:
                    return false;
            }
        }
        private bool IsFreeDate(DateTime timeStamp) 
        {
            const int sunday = 0;
            const int saturday = 6;
            const int july = 7;
            return (int)timeStamp.DayOfWeek == saturday 
                || (int)timeStamp.DayOfWeek == sunday 
                || timeStamp.Month == july;
        }
        private void ResetInterval(ICollection<TollRecord> currentInterval, TollRecord currentRecord)
        {
            currentInterval.Clear();
            currentInterval.Add(currentRecord);
        }
    }
}
