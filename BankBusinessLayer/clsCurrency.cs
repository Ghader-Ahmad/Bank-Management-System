using System;
using System.Data;
using BankDataAccessLayer;

namespace BankBusinessLayer
{
    public class clsCurrency
    {

        public int CountryID { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }

        public clsCurrency()
        {
            CountryID = -1;
            Code = "";
            Country = "";
            Rate = 0;
        }

        private clsCurrency(int countryID, string code, string country, string name, double rate)
        {
            CountryID = countryID;
            Code = code;
            Country = country;
            Name = name; 
            Rate = rate;
        }

        public static DataTable GetAllCurrencies()
        {
            return clsCurrencyData.GetAllCurrencies();
        }

        public static clsCurrency Find(string Code)
        {
            string Country = "", Name = "";
            double Rate = 0;
            int CountryID = 0;

            if (clsCurrencyData.FindCurrency(ref CountryID, Code, ref Country, ref Name, ref Rate))
            {
                return new clsCurrency(CountryID, Code, Country, Name, Rate);
            }
            else
                return null;
        }

        public static bool UpdateRate(string Code, double NewRate)
        {
            return clsCurrencyData.UpdateRate(Code, NewRate);
        }

    }
}
