using Microsoft.VisualStudio.TestTools.UnitTesting;
using TollFeeCalculatorApp;
namespace TollFeeCalculatorTests
{
    [TestClass]
    public class FileReaderTests
    {
        [TestMethod]
        public void Run_FilePathInvalidOrMissing_ShouldHandleException()
        {
            const string missingPath = "missing";
            const string invalidPath = "";
            var fileReader = new FileReader();
            fileReader.ReadFileToString(missingPath);
            fileReader.ReadFileToString(invalidPath);

        }
    }
}
