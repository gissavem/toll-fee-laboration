﻿using System;
using System.Collections.Generic;

namespace TollFeeCalculatorApp
{
    public class TollFeeCalculator
    {
        public void Run(string filePath)
        {
            var fileReader = new FileReader();
            var dateParser = new DateParser();
            var consoleWriter = new ConsoleWriter();
            var fileContent = fileReader.ReadFileToString(filePath);
            var dates = dateParser.ParseDatesFromString(fileContent);
            var totalFee = CalculateTotalFee(dates);
            consoleWriter.PrintTotalFee(totalFee);
        }

        public int CalculateTotalFee(List<DateTime> dates) {
            int fee = 0;
            DateTime si = dates[0]; //Starting interval
            foreach (var d2 in dates)
            {
                long diffInMinutes = (d2 - si).Minutes;
                if(diffInMinutes > 60) {
                    fee += TollFeePass(d2);
                    si = d2;
                } else {
                    fee += Math.Max(TollFeePass(d2), TollFeePass(si));
                }
            }
            return Math.Max(fee, 60);
        }

        static int TollFeePass(DateTime d)
        {
            if (free(d)) return 0;
            int hour = d.Hour;
            int minute = d.Minute;
            if (hour == 6 && minute >= 0 && minute <= 29) return 8;
            else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
            else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
            else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
            else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 8;
            else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
            else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
            else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
            else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
            else return 0;
        }
        //Gets free dates
        static bool free(DateTime day) {
        return (int)day.DayOfWeek == 5 || (int)day.DayOfWeek == 6 || day.Month == 7;
        }

        public double GetDifferenceInMinutes(DateTime firstDateTime, DateTime secondDateTime)
        {
            var timeSpan = secondDateTime - firstDateTime;
            return timeSpan.TotalMinutes;
        }
    }
}
