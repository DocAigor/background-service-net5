using System;
using System.Linq;

namespace FinancialServices
{
    public class DogSitter
    {
        private readonly IDataRetriever _dataretriever;
        private readonly IWriter _writer;
        private readonly IDataDogSearcher _searcher;

        public DogSitter(IDataDogSearcher searcher, 
            IWriter writer, 
            IDataRetriever dataretriever)
        {
            _searcher = searcher;
            _writer = writer;
            _dataretriever = dataretriever;
        }

        public void EsciIlCane(string url,string source)
        {
            var funziona = _dataretriever.Retrieve(url).Single();
            var actualList = _searcher.Retrieve(source);
            if (!_searcher.Search(actualList, funziona)) 
                _writer.Write(source, funziona);
            Console.WriteLine(funziona);
        }
    }
}
