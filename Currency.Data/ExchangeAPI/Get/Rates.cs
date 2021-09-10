using Currency.Data.ExchangeAPI.Data;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Data.ExchangeAPI.Get
{
    public static class Rates
    {

        public static ConversionAPICall GetRates(string code)
        {
            try
            {
                RestClient client = new RestClient("https://v6.exchangerate-api.com/v6/b6c261f5fee2dc9f0450e8b2");
                RestRequest request = new RestRequest("latest/" + code, DataFormat.Json);

                var response = client.Get<ConversionAPICall>(request);
                return response.Data;
            }
            catch
            {
                return null;
            }
        }

    }
}
