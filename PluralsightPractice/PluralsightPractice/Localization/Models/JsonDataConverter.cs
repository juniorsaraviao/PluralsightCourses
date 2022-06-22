﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace PluralsightPractice.Localization.Models
{
   internal static class JsonDataConverter
   {
      public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
      {
         MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
         DateParseHandling = DateParseHandling.None,
         Converters = 
         {
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
         },
      };
   }
}
