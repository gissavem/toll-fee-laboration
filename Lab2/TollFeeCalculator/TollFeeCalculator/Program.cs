using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculatorApp
{
    public class Program
    {
        public static void Main()
        {
            var tollFeeCalculator = new TollFeeCalculator();
            tollFeeCalculator.Run(Environment.CurrentDirectory + "../../../../testData.txt");
        }
    }
}
