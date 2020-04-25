using Blockchain.Core;

namespace Blockchain.Tests.Base
{
    public class TestData : IData
    {
        public TestData(string code, int year)
        {
            Code = code;
            Year = year;
        }

        public string Code { get; set; }
        public int Year { get; set; }

        public string Serialize()
        {
            return $"{Code}-{Year}";
        }
    }
}
