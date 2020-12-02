using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollFeeCalculatorApp;

namespace TollFeeCalculatorTests
{
    [TestClass]
    public class ConsoleWriterTests
    {
        [TestMethod]
        public void PrintTotalFee_ShouldPrintFeeInCorrectFormat()
        {
            var correctOutput = "The total fee for the inputfile is: 60";
            var totalFee = 60;
            var consoleWriter = new ConsoleWriter();
            string result;
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                consoleWriter.PrintTotalFee(totalFee);
                result = stringWriter.ToString();
            }
            Assert.AreEqual(correctOutput, result);
        }
    }
}
