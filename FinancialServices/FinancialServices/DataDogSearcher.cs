using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FinancialServices
{
    public class DataDogSearcher : IDataDogSearcher
    {
        public IEnumerable<string> Retrieve(string source)
        {
            if(File.Exists(source))
                return File.ReadAllLines(source).ToList();
            return Enumerable.Empty<string>();
        }

        public bool Search(IEnumerable<string> dogList, string dogUrl) => 
            dogList.Any(x => x == dogUrl);
    }
}
