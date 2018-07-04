using Newtonsoft.Json;

namespace Stripe
{
    public class StripePaymentIntentTransferData : StripeEntity
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }
    }
}
