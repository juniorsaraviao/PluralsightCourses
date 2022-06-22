using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PluralsightPractice.Localization.Models
{
   public class ExchangeRate
   {
      [JsonProperty("disclaimer")]
      public string Disclaimer { get; set; }

      [JsonProperty("license")]
      public Uri License { get; set; }

      [JsonProperty("timestamp")]
      public long Timestamp { get; set; }

      [JsonProperty("base")]
      public string Base { get; set; }

      [JsonProperty("rates")]
      public Dictionary<string, double> Rates { get; set; }

      public static ExchangeRate FromJson(string json) => JsonConvert.DeserializeObject<ExchangeRate>(json);
   }
}
