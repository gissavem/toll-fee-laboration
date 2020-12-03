using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TollFeeCalculatorApp;

namespace TollFeeCalculatorTests
{
    [TestClass]
    public class TollFeeCalculatorTests
    {
        [TestMethod]
        public void GetHighestFeeInInterval_ShouldReturnHighestFee()
        {
            var expected = 18;
            var tollFeecalulator = new TollFeeCalculator();
            var timeStampCostEigth = new DateTime(2020, 1, 1, 6, 0, 0);
            var timeStampCostThirteen = new DateTime(2020, 1, 1, 6, 45, 0);
            var timeStampCostEighteen = new DateTime(2020, 1, 1, 7, 0, 0);
            var timeStampFree = new DateTime(2020, 1, 1, 19, 0, 0);
            var timeStamps = new List<TollRecord>
            {
                new TollRecord(timeStampCostEigth, 8),
                new TollRecord(timeStampCostThirteen, 13),
                new TollRecord(timeStampCostEighteen, 18),
                new TollRecord(timeStampFree)
            };

            var actual = tollFeecalulator.GetHighestFeeInInterval(timeStamps);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateTotalFee_TwoIntervals_ShouldPayOncePerHourInterval()
        {
            var tollFeecalulator = new TollFeeCalculator();
            var expected = 16;

            var timeStamps = new List<TollRecord>
            {
                new TollRecord(new DateTime(2020, 1, 1, 6, 0, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 6, 15, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 6, 20, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 18, 00, 0), 8)
            };

            var actual = tollFeecalulator.CalculateTotalFee(timeStamps);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateTotalFee_ExceedsMaxFeeAmount_ShouldReturnMaxFee()
        {
            var tollFeecalulator = new TollFeeCalculator();
            var expected = 60;

            var timeStamps = new List<TollRecord>
            {
                new TollRecord(new DateTime(2020, 1, 1, 6, 0, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 7, 0, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 8, 0, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 9, 0, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 10, 0, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 11, 0, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 12, 0, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 13, 0, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 14, 0, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 15, 0, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 16, 0, 0), 8)
            };

            var actual = tollFeecalulator.CalculateTotalFee(timeStamps);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void CalculateTotalFee_BelowMaxFeeAmount_ShouldReturnActualFee()
        {
            var tollFeecalulator = new TollFeeCalculator();
            var expected = 24;

            var timeStamps = new List<TollRecord>()
            {
                new TollRecord(new DateTime(2020, 1, 1, 6, 0, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 7, 0, 0), 8),
                new TollRecord(new DateTime(2020, 1, 1, 8, 0, 0), 8)
            };

            var actual = tollFeecalulator.CalculateTotalFee(timeStamps);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetFee_NormalWeekDay()
        {
            var expectEight = 8;
            var expectThirteen = 13;
            var expectEighteen = 18;
            var expectFree = 0;

            var tollFeecalulator = new TollFeeCalculator();
            var firstTimeSpan = new DateTime(2020, 1, 1, 6, 15, 0);
            var secondTimeSpan = new DateTime(2020, 1, 1, 6, 45, 0);
            var thirdTimeSpan = new DateTime(2020, 1, 1, 7, 29, 0);
            var fourthTimeSpan = new DateTime(2020, 1, 1, 8, 14, 0);
            var fifthTimeSpan = new DateTime(2020, 1, 1, 14, 29, 0);
            var sixthTimeSpan = new DateTime(2020, 1, 1, 15, 15, 0);
            var seventhTimeSpan = new DateTime(2020, 1, 1, 16, 15, 0);
            var eighthTimeSpan = new DateTime(2020, 1, 1, 17, 0, 0);
            var ninthTimeSpan = new DateTime(2020, 1, 1, 18, 15, 0);
            var tenthTimeSpan = new DateTime(2020, 1, 1, 3, 0, 0);
            var eleventhTimeSpan = new DateTime(2020, 1, 1, 12, 0, 0);
            
            var actualOne = tollFeecalulator.GetFee(firstTimeSpan);
            var actualTwo = tollFeecalulator.GetFee(secondTimeSpan);
            var actualThree = tollFeecalulator.GetFee(thirdTimeSpan);
            var actualFour = tollFeecalulator.GetFee(fourthTimeSpan);
            var actualFive = tollFeecalulator.GetFee(fifthTimeSpan);
            var actualSix = tollFeecalulator.GetFee(sixthTimeSpan);
            var actualSeven = tollFeecalulator.GetFee(seventhTimeSpan);
            var actualEight = tollFeecalulator.GetFee(eighthTimeSpan);
            var actualNine = tollFeecalulator.GetFee(ninthTimeSpan);
            var actualTen = tollFeecalulator.GetFee(tenthTimeSpan);
            var actualEleven = tollFeecalulator.GetFee(eleventhTimeSpan);

            Assert.AreEqual(expectEight, actualOne);
            Assert.AreEqual(expectThirteen, actualTwo);
            Assert.AreEqual(expectEighteen, actualThree);
            Assert.AreEqual(expectThirteen, actualFour);
            Assert.AreEqual(expectEight, actualFive);
            Assert.AreEqual(expectThirteen, actualSix);
            Assert.AreEqual(expectEighteen, actualSeven);
            Assert.AreEqual(expectThirteen, actualEight);
            Assert.AreEqual(expectEight, actualNine);
            Assert.AreEqual(expectFree, actualTen);
            Assert.AreEqual(expectEight, actualEleven);
        }

        [TestMethod]
        public void GetFee_SaturdaySundayAndJuly_ShouldReturnZero()
        {
            var expected = 0;

            var tollFeecalulator = new TollFeeCalculator();
            var saturday = new DateTime(2020, 1, 4, 6, 15, 0);
            var sunday = new DateTime(2020, 1, 5, 6, 45, 0);
            var july = new DateTime(2020, 7, 1, 7, 29, 0);

            var actualOne = tollFeecalulator.GetFee(saturday);
            var actualTwo = tollFeecalulator.GetFee(sunday);
            var actualThree = tollFeecalulator.GetFee(july);

            Assert.AreEqual(expected, actualOne);
            Assert.AreEqual(expected, actualTwo);
            Assert.AreEqual(expected, actualThree);
        }

        [TestMethod]
        public void PopulateRecordsWithFees_ShouldPopulateAllRecords()
        {
            var timeStampCostEigth = new DateTime(2020, 1, 1, 6, 0, 0);
            var timeStampCostThirteen = new DateTime(2020, 1, 1, 6, 45, 0);
            var timeStampCostEighteen = new DateTime(2020, 1, 1, 7, 0, 0);
            var timeStampFree = new DateTime(2020, 1, 1, 19, 0, 0);
            var emptyRecords = new List<TollRecord>
            {
                new TollRecord(timeStampCostEigth),
                new TollRecord(timeStampCostThirteen),
                new TollRecord(timeStampCostEighteen),
                new TollRecord(timeStampFree)
            };
            var expectEight = 8;
            var expectThirteen = 13;
            var expectEighteen = 18;
            var expectFree = 0;

            var tollFeeCalculator = new TollFeeCalculator();

            var populatedRecords = tollFeeCalculator.PopulateRecordsWithFees(emptyRecords);

            Assert.AreEqual(expectEight, populatedRecords[0].Fee);
            Assert.AreEqual(expectThirteen, populatedRecords[1].Fee);
            Assert.AreEqual(expectEighteen, populatedRecords[2].Fee);
            Assert.AreEqual(expectFree, populatedRecords[3].Fee);
        }

        [TestMethod]
        public void RemoveFreeRecordsFromCollection_ShouldReturnListWithoutFreeRecords()
        {
            var expectedCount = 3;
            var tollFeecalulator = new TollFeeCalculator();
            var timeStampCostEigth = new DateTime(2020, 1, 1, 6, 0, 0);
            var timeStampCostThirteen = new DateTime(2020, 1, 1, 6, 45, 0);
            var timeStampCostEighteen = new DateTime(2020, 1, 1, 7, 0, 0);
            var timeStampFree = new DateTime(2020, 1, 1, 19, 0, 0);
            var records = new List<TollRecord>
            {
                new TollRecord(timeStampCostEigth, 8),
                new TollRecord(timeStampCostThirteen, 13),
                new TollRecord(timeStampCostEighteen, 18),
                new TollRecord(timeStampFree)
            };

            var actual = tollFeecalulator.RemoveFreeRecords(records);

            Assert.AreEqual(expectedCount, actual.Count);
        }
    }
}