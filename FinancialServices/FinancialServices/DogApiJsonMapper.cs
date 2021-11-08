using Newtonsoft.Json;

namespace FinancialServices
{
    public class DogApiJsonMapper : IDogApiMapper
    {
        internal class DataDog
        {
            public string message { get; set; }
            public string status { get; set; }
        }
        public string DecodeApi(string apiresult)
        {
            var dog = JsonConvert.DeserializeObject<DataDog>(apiresult);
            return dog.message;
        }
    }

}
