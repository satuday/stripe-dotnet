using Newtonsoft.Json;

namespace Stripe
{
    public class StripePaymentIntentSourceActionAuthorizeWithUrl : StripeEntity
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
