using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Refit;
using RestSharp;
using System.Globalization;

namespace CPTool.Services
{
    public interface ICurrencyApi
    {
        public Dictionary<string, double> RateList { get; }

    }
    public class CurrencyApi : ICurrencyApi
    {
        Dictionary<string, double> GetLatest()
        {
            try
            {


                var client = new RestClient("https://api.apilayer.com/exchangerates_data");
                var request = new RestRequest("/latest?base=USD");
                request.AddHeader("apikey", "Ri3pzdLzbqfP8thFWpkQSA9GKmUOczYd");
                var response = client.Execute<ApiResponse<Rates>>(request);
                var rate = response.Content!.FromJson();
                if (rate.Success)
                {
                    return rate.RateList;
                }
                else return null;
            }
            catch (Exception ex)
            {
                string exm = ex.Message;
                return null; ;
            }


        }
        Dictionary<string, double> _RateList = null!;
        public Dictionary<string, double> RateList
        {
            get
            {
                if (_RateList == null)
                {
                    _RateList = GetLatest();

                }
                return _RateList;
            }

        }
    }
    public static class DependencyContainer
    {
        public static IServiceCollection CurrencyService(
            this IServiceCollection services)
        {
            services.AddScoped<ICurrencyApi, CurrencyApi>();



            return services;
        }

    }
    public class Rates
    {
        [JsonProperty("rates")]
        public Dictionary<string, double> RateList { get; set; } = null!;

        [JsonProperty("base")]
        public string Base { get; set; } = null!;

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
    }

    public static class ExtensionRates
    {
        public static Rates FromJson(this string json) => JsonConvert.DeserializeObject<Rates>(json, Converter.Settings)!;
        public static string ToJson(this Rates self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }


    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
