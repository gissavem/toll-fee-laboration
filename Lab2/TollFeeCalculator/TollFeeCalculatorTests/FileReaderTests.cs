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
            const string MissingPath = "missing";
            const string InvalidPath = "";
            var fileReader = new FileReader();
            fileReader.ReadFileToString(MissingPath);
            fileReader.ReadFileToString(InvalidPath);

        }
    }
}
