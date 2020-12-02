using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollFeeCalculatorApp
{
   public class TollRecord
    {
        public TollRecord(DateTime timeStamp, int fee = 0)
        {
            TimeStamp = timeStamp;
            Fee = fee;
        }
        public int Fee {  get;  set; }
        public DateTime TimeStamp { get; set; }
        public bool HasValue { get { return Fee != 0; } }
    }
}
