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
        public Currency BaseCurrency
        {
            get
            {
                return Currencies.Where(c => c.IsBaseCurrency = true).FirstOrDefault();
            }
        }
        public ObservableCollection<Currency> Currencies
        {
            get;
            set;
        }

        public string BaseCode
        {
            get;
            set;
        }

        public CurrencyCalculator(string code)
        {
            this.BaseCode = code;
            LoadRates();
        }

        public void LoadRates()
        {

            Currencies = new ObservableCollection<Currency>();
            Currencies.Add(new Currency { Country = "United States Of America", Code = BaseCode, Amount = 1, Rate = 1, IsBaseCurrency = true }); ;
            Currencies.Add(new Currency { Country = "New Zealand", Code = "NZD", Amount = 0 });
            Currencies.Add(new Currency { Country = "Australia", Code = "AUD", Amount = 0 });


            ConversionAPICall call = Rates.GetRates(BaseCode);

            if (call != null)
            {
                List<string> countryCodes = call.GetSupportedCountryCodes();

                foreach (Currency c in Currencies)
                {
                    c.Rate = call.GetRate(c.Code);
                }
            }

            CalculateAmounts();
        }

        public void ChangeBaseCode(string code)
        {
            this.BaseCode = code;
            LoadRates();
        }

        public void CalculateAmounts()
        {

            foreach(Currency c in Currencies)
            {
                c.Amount = BaseCurrency.Amount * c.Rate;
            }
        }

    }
}
