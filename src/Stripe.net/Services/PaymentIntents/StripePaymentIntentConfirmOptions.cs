using System.Collections.Generic;
using Newtonsoft.Json;

namespace Stripe
{
    public class StripePaymentIntentConfirmOptions : StripeBaseOptions
    {
        [JsonProperty("receipt_email")]
        public string ReceiptEmail { get; set; }

        [JsonProperty("save_source_to_customer")]
        public bool? SaveSourceToCustomer { get; set; }

        [JsonProperty("source")]
        public string SourceId { get; set; }
    }
}
