using System.Collections.Generic;

namespace FinancialServices
{
    public interface ISearcher
    {
        bool Search(IEnumerable<string> dogList, string dogUrl);
    }
}
