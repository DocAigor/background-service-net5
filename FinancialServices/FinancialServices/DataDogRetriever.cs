using System.Collections.Generic;
using System.Net.Http;

namespace FinancialServices
{
    public class DataDogRetriever : IDataRetriever
    {
        private readonly IDogApiMapper _dogApiMapper;
        private readonly HttpClient _httpclient;
        public DataDogRetriever(IDogApiMapper dogapimapper, HttpClient httpclient)
        {
            _dogApiMapper = dogapimapper;
            _httpclient = httpclient;
        }
        public IEnumerable<string> Retrieve(string apiUrl)
        {
            yield return _dogApiMapper.DecodeApi(_httpclient.GetStringAsync(apiUrl).GetAwaiter().GetResult());
        }
    }

}
