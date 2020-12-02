using System;

namespace TollFeeCalculatorApp
{
    public class ConsoleWriter
    {
        public void PrintTotalFee(int totalFee)
        {
            Console.Write("The total fee for the inputfile is: " + totalFee);
        }
    }
}