using Newtonsoft.Json;
using PluralsightPractice.Localization.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightPractice.Localization.Services
{
   public class DataService
   {
      private readonly string ResourcePath = typeof(DataService).Namespace;
      private Assembly ThisAssembly = typeof(DataService).GetTypeInfo().Assembly;

      public async Task<ExchangeRate> GetExchangeRate()
      {
         string jsonData = "";

         var stream = ThisAssembly.GetManifestResourceStream($"{ResourcePath}.exchange.json");

         using (var reader = new StreamReader(stream))
         {
            jsonData = await reader.ReadToEndAsync();
         }

         var exchangeRates = ExchangeRate.FromJson(jsonData);

         return exchangeRates;
      }

      public async Task<ExchangeRate> GetExchangeRate(HttpClient client)
      {
         var jsonData = await client.GetStringAsync("https://openexchangerates.org/api/latest.json?app_id=YOUR_API_KEY");

         var exchangeRates = ExchangeRate.FromJson(jsonData);

         return exchangeRates;
      }

      private static string GetClosestLanguage(string locale)
      {
         var langs = new[] { "es", "de", "zh-cn", "zh-tw", "pt-br", "pt-pt" };
         var result = "";

         foreach (var lang in langs)
         {
            if (locale.StartsWith(lang, StringComparison.CurrentCultureIgnoreCase))
            {
               result = $"{lang}";
               break;
            }
         }

         return result;
      }

      public List<CurrencyName> GetExchangeCurrencies(string locale)
      {
         var language = GetClosestLanguage(locale);
         var json = "";

         var stream = ThisAssembly.GetManifestResourceStream($"{ResourcePath}.currencies-{language}.json") ??
                      ThisAssembly.GetManifestResourceStream($"{ResourcePath}.currencies.json");

         using (var reader = new StreamReader(stream))
         {
            json = reader.ReadToEnd();
         }

         return JsonConvert.DeserializeObject<List<CurrencyName>>(json);
      }

      public async Task<List<CurrencyName>> GetExchangeCurrencies(HttpClient client)
      {
         var json = await client.GetStringAsync("https://openexchangerates.org/api/currencies.json");

         return JsonConvert.DeserializeObject<List<CurrencyName>>(json);
      }

      public List<CurrencySymbol> GetCurrencySymbols()
      {
         var json = "";

         var stream = ThisAssembly.GetManifestResourceStream($"{ResourcePath}.currencysymbols.json");

         using (var reader = new StreamReader(stream))
         {
            json = reader.ReadToEnd();
         }

         return JsonConvert.DeserializeObject<List<CurrencySymbol>>(json);
      }
   }
}
