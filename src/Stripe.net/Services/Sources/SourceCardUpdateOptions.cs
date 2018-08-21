namespace Stripe
{
    using Newtonsoft.Json;

    public class SourceCardUpdateOptions : INestedOptions
    {
        [JsonProperty("card[exp_month]")]
        public int? ExpirationMonth { get; set; }

        [JsonProperty("card[exp_year]")]
        public int? ExpirationYear { get; set; }
    }
}
