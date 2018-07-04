using Newtonsoft.Json;

namespace Stripe
{
    public class StripePaymentIntentTransferDataOptions : INestedOptions
    {
        [JsonProperty("transfer_data[amount]")]
        public int? Amount { get; set; }
    }
}
