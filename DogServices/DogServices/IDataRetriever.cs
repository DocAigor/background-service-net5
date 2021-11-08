using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinancialServices
{
    public interface IDataRetriever
    {
        IEnumerable<string> Retrieve(string source);
    }
}
