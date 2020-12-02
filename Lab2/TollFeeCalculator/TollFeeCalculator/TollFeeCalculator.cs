using System;
using System.Collections.Generic;
using System.Linq;

namespace TollFeeCalculatorApp
{
    public class TollFeeCalculator
    {
        private const int MAX_FEE = 60;
        private const int ONE_HOUR = 60;
        private FileReader _fileReader;
        private DateParser _dateParser;
        private ConsoleWriter _consoleWriter;

        public TollFeeCalculator()
        {
           _fileReader = new FileReader();
           _dateParser = new DateParser();
           _consoleWriter = new ConsoleWriter();
        }
        public void Run(string filePath)
        {
            var fileContent = _fileReader.ReadFileToString(filePath);
            var records = _dateParser.CreateTollRecordsFromString(fileContent);
            var populatedRecords = PopulateRecordsWithFees(records);
            var filteredRecords = RemoveFreeRecords(populatedRecords);
            var totalFee = CalculateTotalFee(filteredRecords);
            _consoleWriter.PrintTotalFee(totalFee);
        }

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

        public int GetHighestFeeInInterval(List<TollRecord> records)
        {
            var feeToKeep = 0;
            foreach (var record in records)
            {
                if (record.Fee > feeToKeep)
                {
                    feeToKeep = record.Fee;
                }
            }
            return feeToKeep;
        }

        public List<TollRecord> RemoveFreeRecords(List<TollRecord> records) => records.Where(record => record.HasValue).ToList();
        

        public int GetFee(DateTime timeStamp)
        {
            if (FreeDate(timeStamp)) 
                return 0;
            var hour = timeStamp.Hour;
            var minute = timeStamp.Minute;
            if (DoesCostEigth(hour, minute))
                return 8;
            else if (DoesCostThirteen(hour, minute))
                return 13;
            else if (DoesCostEighteen(hour, minute))
                return 18;
            else 
                return 0;
        }

        private bool DoesCostEigth(int hour, int minute)
        {
            if (hour == 6 &&  minute <= 29)
                return true;
            else if ((hour == 8 && minute >= 30) || hour == 14 )
                return true;
            else if (hour == 18 && minute <= 29)
                return true;
            else
                return false;
        }
       

        private bool DoesCostThirteen(int hour, int minute)
        {

            if (hour == 6 && minute >= 30)
                return true;
            else if (hour == 8 && hour <= 29)
                return true;
            else if (hour == 15 && minute <= 29)
                return true;
            else if (hour == 17)
                return true;
            else
                return false;
        }

        private bool DoesCostEighteen(int hour, int minute)
        {

            if (hour == 7)
                return true;
            else if ((hour == 15 && minute >= 30) || hour == 16 )
                return true;
            else
                return false;
        }
      
        private bool FreeDate(DateTime timeStamp) 
        {
            const int sunday = 0;
            const int saturday = 6;
            const int july = 7;
            return (int)timeStamp.DayOfWeek == saturday 
                || (int)timeStamp.DayOfWeek == sunday 
                || timeStamp.Month == july;
        }

        private void ResetInterval(List<TollRecord> currentInterval, TollRecord currentRecord)
        {
            currentInterval.Clear();
            currentInterval.Add(currentRecord);
        }


    }
}
