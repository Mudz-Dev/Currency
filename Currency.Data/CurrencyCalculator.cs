using Currency.Data.ExchangeAPI.Data;
using Currency.Data.ExchangeAPI.Get;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Data
{
    public class CurrencyCalculator
    {

        public ObservableCollection<Currency> Currencies
        {
            get;
            set;
        }

        public CurrencyCalculator()
        {
            Currencies = new ObservableCollection<Currency>();
            Currencies.Add(new Currency { Country = "New Zealand", Code = "NZD", Amount = 0 });
            Currencies.Add(new Currency { Country = "Australia", Code = "AUD", Amount = 0 });
            Currencies.Add(new Currency { Country = "United States Of America", Code = "USD", Amount = 0 });

            ConversionAPICall call = Rates.GetRates("USD");

            if (call != null)
            {
                List<string> countryCodes = call.GetSupportedCountryCodes();

                foreach(Currency c in Currencies)
                {
                    c.Rate = call.GetRate(c.Code);
                }
            }

        }

    }
}
