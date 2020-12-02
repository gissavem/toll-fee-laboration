using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using TollFeeCalculatorApp;

namespace TollFeeCalculatorTests
{
    [TestClass]
    public class DateParserTests
    {
        [TestMethod]
        public void DateParser_ThreeDates_ShouldReturnArrayWithThreeDates()
        {
            var dateParser = new DateParser();
            var expectedCount = 3;
            var validInput = "2020-06-30 00:05, 2020-06-30 06:34, 2020-06-30 08:52";
            var dates = dateParser.ParseDatesFromString(validInput);

            Assert.AreEqual(expectedCount, dates.Count);
        }
        [TestMethod]
        public void DateParser_InvalidInput_ShouldReturnEmptyArray()
        {
            var dateParser = new DateParser();
            var invalidInput = "";
            var expectedCount = 0;
            var dates = dateParser.ParseDatesFromString(invalidInput);

            Assert.AreEqual(expectedCount, dates.Count);
        }
        [TestMethod]
        public void DateParser_InvalidInput_ShouldHandleException()
        {
            var dateParser = new DateParser();
            var invalidInput = "xasfasxasfas";
            var dates = dateParser.ParseDatesFromString(invalidInput);
        }

    }
}
