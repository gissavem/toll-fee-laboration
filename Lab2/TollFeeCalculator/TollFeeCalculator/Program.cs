using System;

namespace TollFeeCalculatorApp
{
    public static class Program
    {
        public static void Main()
        {
            var tollFeeCalculator = new TollFeeCalculator();
            tollFeeCalculator.CalculateFeeFromRecordsInFile(Environment.CurrentDirectory + "../../../../testData.txt");
        }
    }
}
