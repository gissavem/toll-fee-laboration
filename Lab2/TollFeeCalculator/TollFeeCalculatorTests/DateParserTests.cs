using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TollFeeCalculatorApp;

namespace TollFeeCalculatorTests
{
    [TestClass]
    public class DateParserTests
    {
        [TestMethod]
        public void CreateTollRecordsForOneDayFromString_ThreeTimeStamps_ShouldReturnListWithThreeTollRecords()
        {
            var dateParser = new DateParser();
            var expectedCount = 3;
            var validInput = "2020-06-30 00:05, 2020-06-30 06:34, 2020-06-30 08:52";
            var parsedRecords = dateParser.CreateTollRecordsForOneDayFromString(validInput);

            Assert.AreEqual(expectedCount, parsedRecords.Count);
        }
        [TestMethod]
        public void CreateTollRecordsForOneDayFromString_DifferentDates_ShouldReturnListWithoutSecondDate()
        {
            var dateParser = new DateParser();
            var expectedCount = 2;
            var validInput = "2020-06-30 00:05, 2020-06-30 06:34, 2020-07-05 08:52";
            var parsedRecords = dateParser.CreateTollRecordsForOneDayFromString(validInput);

            Assert.AreEqual(expectedCount, parsedRecords.Count);
        }
        [TestMethod]
        public void DateParser_InvalidInput_ShouldReturnEmptyList()
        {
            var dateParser = new DateParser();
            var invalidInput = "";
            var expectedCount = 0;
            var parsedRecords = dateParser.CreateTollRecordsForOneDayFromString(invalidInput);

            Assert.AreEqual(expectedCount, parsedRecords.Count);
        }
        [TestMethod]
        public void DateParser_InvalidInput_ShouldHandleException()
        {
            var dateParser = new DateParser();
            var invalidInput = "xasfasxasfas";
            var parsedRecords = dateParser.CreateTollRecordsForOneDayFromString(invalidInput);
        }
        [TestMethod]
        public void GetDifferenceInMinutes_ShouldReturn90()
        {
            var expectedMinutes = 90d;
            var firstTime = new DateTime(1970, 1, 1, 10, 0, 0);
            var secondTime = new DateTime(1970, 1, 1, 11, 30, 0);
            var dateParser = new DateParser();
            
            var actual = dateParser.GetTimeDelta(firstTime, secondTime);

            Assert.AreEqual(expectedMinutes, actual);
        }
    }
}
