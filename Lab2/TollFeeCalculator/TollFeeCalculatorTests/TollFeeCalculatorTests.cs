using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using TollFeeCalculatorApp;

namespace TollFeeCalculatorTests
{
    [TestClass]
    public class TollFeeCalculatorTests
    {
        [TestMethod]
        public void CalculateTotalFee_ShouldPrintResultInCorrectFormat()
        {

        }

        [TestMethod]
        public void GetDifferenceInMinutes_ShouldReturn90()
        {
            var expectedMinutes = 90d;
            var tenAm = new DateTime(1970, 1, 1, 10, 0, 0);
            var elevenThirtyAm = new DateTime(1970,1,1,11,30,0);
            var tollFeeCalculator = new TollFeeCalculator();
            

            var actual =tollFeeCalculator.GetDifferenceInMinutes(tenAm, elevenThirtyAm);

            Assert.AreEqual(expectedMinutes, actual);
        }

        //Row: 27 diffInMinutes will always be between -59_59

        //Row: 28. Largest amount within the last hour does not work

        //Row: 32. remove lowest payment if within the same hour does not work

        //Row: 35. Will always return 60 if fee is lower than 60.

        //Row: 47. Minutes between 00-29 will never return a value

        //Row: 56. Friday is free instead of sunday

    }
}
