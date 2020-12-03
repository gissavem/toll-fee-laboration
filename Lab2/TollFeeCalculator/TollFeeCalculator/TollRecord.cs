using System;

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
        public DateTime TimeStamp { get; }
        public bool HasFee => Fee != 0;
    }
}
