using System;
using System.IO;

namespace TollFeeCalculatorApp
{
    public class FileReader
    {
        public string ReadFileToString(string filePath)
        {
            try
            {
                return File.ReadAllText(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return string.Empty;
            }
        }
    }
}
