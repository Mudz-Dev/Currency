using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Data.ExchangeAPI.Data
{
    public class ConversionAPICall
    {
        public string result { get; set; }
        public string documentation { get; set; }
        public string terms_of_use { get; set; }
        public string time_zone { get; set; }
        public string time_last_update { get; set; }
        public string time_next_update { get; set; }
        public ConversionRate conversion_rates { get; set; }

        public Double GetRate(string code)
        {

            var prop = conversion_rates.GetType().GetProperty(code);

            return (double) prop.GetValue(conversion_rates);

        }

        public List<string> GetSupportedCountryCodes()
        {
            return conversion_rates.GetType().GetProperties().Select(p => p.Name).ToList();
        }
    }
}
